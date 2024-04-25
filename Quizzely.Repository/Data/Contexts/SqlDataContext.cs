using Microsoft.EntityFrameworkCore;
using Quizzely.Core.Models;

namespace Quizzely.Repository.Data.Contexts
{
    public class SqlDataContext : DbContext
    {
        public SqlDataContext(DbContextOptions<SqlDataContext> options) : base(options) 
        {

        }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<McqQuestion> Mcqs { get; set; }
        public DbSet<TofQuestion> TofQuestions { get; set; }
    }
}
