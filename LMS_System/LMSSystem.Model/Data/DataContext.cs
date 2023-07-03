using LMS_System.LMSSystem.Model.Models;
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
        public DbSet<Class> Classes { get; set; }
        public DbSet<Anwser> Anwsers { get; set; }
        public DbSet<User_Class> User_Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Roles)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RolesId)
                .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<User_Class>()
                .HasKey(uc => new { uc.UserId, uc.ClassId });

            modelBuilder.Entity<User_Class>()
                .HasOne(uc => uc.User)
                .WithMany(uc => uc.User_Class)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Exam)
                .WithMany(e => e.Questions)
                .HasForeignKey(q => q.ExamId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
