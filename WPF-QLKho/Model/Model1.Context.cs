﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_QLKho.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLKhoEntities : DbContext
    {
        public QLKhoEntities()
            : base("name=QLKhoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Img> Imgs { get; set; }
        public virtual DbSet<Input> Inputs { get; set; }
        public virtual DbSet<InputInfo> InputInfoes { get; set; }
        public virtual DbSet<OutputInfo> OutputInfoes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tObject> tObjects { get; set; }
        public virtual DbSet<tOutput> tOutputs { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}