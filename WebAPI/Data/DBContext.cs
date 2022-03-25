using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Models.Department> Department { get; set; }

        public DbSet<WebAPI.Models.Employee> Employee { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Employee>()
    //        .HasKey<Department>(e => e.CurrentGrade)
    //    .WithMany(dep => dep.Employees) // Nav Property in Department Class
    //    .HasForeignKey<int>(e => e.DepartmentId); // FK Property		
    //}

   /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // configures one-to-many relationship
        modelBuilder.Entity<Student>()
            .HasRequired<Grade>(s => s.CurrentGrade)
            .WithMany(g => g.Students)
            .HasForeignKey<int>(s => s.CurrentGradeId);
    }
     */
}



