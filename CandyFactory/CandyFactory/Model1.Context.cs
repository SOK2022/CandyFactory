﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CandyFactory
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CandyFactoryEntities : DbContext
    {
        public CandyFactoryEntities()
            : base("name=CandyFactoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Boxes> Boxes { get; set; }
        public virtual DbSet<Candies> Candies { get; set; }
        public virtual DbSet<ComponentOrders> ComponentOrders { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<Compositions> Compositions { get; set; }
        public virtual DbSet<Counterparties> Counterparties { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
