using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBecoffe.Models;

    public class MyBecoffeContext : DbContext
    {
        public MyBecoffeContext (DbContextOptions<MyBecoffeContext> options)
            : base(options)
        {
        }

        public DbSet<MyBecoffe.Models.Becoffe> Becoffe { get; set; } = default!;
    }
