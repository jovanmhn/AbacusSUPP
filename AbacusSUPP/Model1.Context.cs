﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AbacusSUPP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AbacusSUPEntities : DbContext
    {
        public AbacusSUPEntities()
            : base("name=AbacusSUPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Partneri> Partneri { get; set; }
        public virtual DbSet<Prioritet> Prioritet { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Sektor> Sektor { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<VezaLT> VezaLT { get; set; }
    }
}
