using Microsoft.EntityFrameworkCore;
using EmployeeMgtAPI.Models;


namespace EmployeeMgtAPI.Data
{
    public class ApplicationDbCtx: DbContext
    {
        public ApplicationDbCtx(DbContextOptions<ApplicationDbCtx> options):base(options)
        {}

        public DbSet<Employee> Employees { get; set;}

    }
}
