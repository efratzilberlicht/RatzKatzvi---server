﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RatzhKatzviEntities1 : DbContext
    {
        public RatzhKatzviEntities1()
            : base("name=RatzhKatzviEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookPages> BookPages { get; set; }
        public virtual DbSet<Kinds> Kinds { get; set; }
        public virtual DbSet<LastLocation> LastLocation { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<ItemsSubject> ItemsSubject { get; set; }
        public virtual DbSet<PreSearches> PreSearches { get; set; }
        public virtual DbSet<WordLocation> WordLocation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
