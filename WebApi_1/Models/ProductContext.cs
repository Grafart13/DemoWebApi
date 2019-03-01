﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_1.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
