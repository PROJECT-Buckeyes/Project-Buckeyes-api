﻿using Buckeyes.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Buckeyes.Data{
public class StoreContext: DbContext{

    public StoreContext CreateDBContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<StoreContext>()
            .UseSqlite("Data Source=../Registrar.sqlite")
               
        return new StoreContext(options);
    }
    public StoreContext(DbContextOptions<StoreContext> options): base(options){ }
    public DbSet<Item> Items {get; set;}
    public DbSet<Order> Orders {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}