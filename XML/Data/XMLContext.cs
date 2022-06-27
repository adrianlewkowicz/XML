using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XML.Domain;

namespace XML.Data
{
    public class XMLContext : DbContext
    {
        public XMLContext (DbContextOptions<XMLContext> options)
            : base(options)
        {
        }

        public DbSet<XML.Domain.Reference>? Reference { get; set; }
    }
}
