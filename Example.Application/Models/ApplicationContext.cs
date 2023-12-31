﻿using Example.Application.Models.Entities;
using Example.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Domain.Models
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryAdditionalField> CategoryAdditionalFields { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAdditionalField> ProductAdditionalFields { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
