using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext() : base("EmployeeContext")
        {

        }
        //for adding configurations--eg foreign keys
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            //modelBuilder.Configurations.Add(new EmployeeEntityConfiguration());
            //modelBuilder.Configurations.Add(new DepartmentEntityConfiguration());

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<People> People { get; set; }

        
    }
}




    ////using fluent API--used for putting keys and columns
    //public class EmployeeEntityConfiguration : EntityTypeConfiguration<Employee>
    //{
    //    public EmployeeEntityConfiguration()
    //    {
    //        this.ToTable("Employee");

    //        this.HasKey<int>(s => s.EID);

    //        this.Property(p => p.Ename)
    //                .HasMaxLength(50);

    //        this.Property(p => p.Salary);

    //        this.Property(p => p.DeptID);


    //    }

    //    public class DepartmentEntityConfiguration : EntityTypeConfiguration<Department>
    //    {
    //        public DepartmentEntityConfiguration()
    //        {
    //            this.ToTable("Department");

    //            this.HasKey<int>(s => s.DeptID);

    //            this.Property(p => p.DeptName)
    //                .HasMaxLength(50);
    //        }
    //    }
    
