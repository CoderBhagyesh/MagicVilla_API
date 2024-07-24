using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAGICVILLA_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Villa> Villas { get; set; }
    }
}