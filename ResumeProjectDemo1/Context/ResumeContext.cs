using Microsoft.EntityFrameworkCore;
using ResumeProjectDemo1.Entities;

namespace ResumeProjectDemo1.Context
{
    public class ResumeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BMACQ1D\\SQLEXPRESS; initial catalog= Project1ResumeDB;integrated security=true; trust server certificate=true");
        }
       public DbSet<About> Abouts { get; set; }   
       public DbSet<Category> Categories { get; set; }   
       public DbSet<Contact> Contacts { get; set; }   
       public DbSet<Experience> Experiences { get; set; } 
       public DbSet<Message> Messages{ get; set; } 
       public DbSet<Portfolio> Portfolios { get; set; } 
       public DbSet<Service> Services { get; set; } 
       public DbSet<Testimonial> Testimonials { get; set; } 
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Admin> Admins { get; set; }




    }
}
