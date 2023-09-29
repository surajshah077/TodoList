using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Todos is a mapping of Todo model with Todo table in database.
        /// </summary>
        /// <returns>It returns something I am not familiar with.</returns>
        public DbSet<Todo> Todos { get; set; }
    }
}
