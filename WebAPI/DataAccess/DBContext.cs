using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess;

public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

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



