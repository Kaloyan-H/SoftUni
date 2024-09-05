
namespace _14.DI_Framework_Workshop
{
    using _14.DI_Framework_Workshop.DI;
    using Drawers;
    using Drawers.Contracts;

    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider diProvider = DependencyInjectionService.ConfigureServices();

            Engine engine = (Engine)diProvider.GetService(typeof(Engine));

            engine.Run();
        }
    }
}