using EntityFrameworkIntroLab.Data;
using EntityFrameworkIntroLab.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkIntroLab
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var judgeProject = await context.Projects
                    .FirstOrDefaultAsync(p => p.Name == "Judge Updated");

                if (judgeProject != null)
                {
                    context.Projects
                        .Remove(judgeProject);
                    
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}