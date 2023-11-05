using Microsoft.EntityFrameworkCore;
using WebPOCHub.Models;

namespace WebPOCHub.DataAccessLayer
{
    public class DbContextClass : DbContext
    {
        public DbContextClass()
        {

        }
        public DbContextClass(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=VAISHNAVI-WARAN\\SQLEXPRESS;Initial Catalog=MyFirstWebAPI;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeName = "UserA",
                    Address = "Address A",
                    City = "City A",
                    Country = "Country A",
                    ZipCode = "ZIP0001",
                    Phone = "+091 9000000009",
                    Email = "usera@gmail.com",
                    Skillsets = "DBA",
                    Avatar = "/images/imagea.png"
                },
                new Employee()
                {
                    EmployeeId = 2,
                    EmployeeName = "UserB",
                    Address = "Address B",
                    City = "City B",
                    Country = "Country B",
                    ZipCode = "ZIP0002",
                    Phone = "+091 9000000008",
                    Email = "userb@gmail.com",
                    Skillsets = "MVC",
                    Avatar = "/images/imageb.png"
                },
                new Employee()
                {
                    EmployeeId = 3,
                    EmployeeName = "UserB",
                    Address = "Address B",
                    City = "City B",
                    Country = "Country B",
                    ZipCode = "ZIP0003",
                    Phone = "+091 9000000007",
                    Email = "userb@gmail.com",
                    Skillsets = "Sql",
                    Avatar = "/images/imagec.png"
                });
            modelbuilder.Entity<Role>().HasData(
                new Role()
                {
                    RoleId = 1,
                    RoleName = "Employee",
                    RoleDescription = "Employee of WebPOCHub Company"
                },
                new Role() { 
                RoleId = 2,
                    RoleName = "HR",
                    RoleDescription = "HR of WebPOCHub Company"
                });
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}