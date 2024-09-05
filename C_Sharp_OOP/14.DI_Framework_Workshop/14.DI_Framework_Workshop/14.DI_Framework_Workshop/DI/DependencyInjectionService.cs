using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop.DI
{
    using _14.DI_Framework_Workshop.Renderers.Contracts;
    using Drawers;
    using Drawers.Contracts;
    using Renderers;

    public class DependencyInjectionService
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            //our code
            serviceCollection.AddTransient<IShapeDrawer, BasicShapeDrawer>();
            serviceCollection.AddTransient<Engine, Engine>();
            serviceCollection.AddTransient<IRenderer, ConsoleRenderer>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
