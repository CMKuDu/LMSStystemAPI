using LMS_System.LMSSystym.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS_System.LMSSystym.Model.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
       : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PersionalDocument> PersionalDocuments { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }


    }
}
