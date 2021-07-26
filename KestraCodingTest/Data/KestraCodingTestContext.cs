using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KestraCodingTest.Models;

namespace KestraCodingTest.Data
{
    public class KestraCodingTestContext : DbContext
    {
        public KestraCodingTestContext (DbContextOptions<KestraCodingTestContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<KestraCodingTest.Models.PetFormModel> PetFormModel { get; set; }
    }
}
