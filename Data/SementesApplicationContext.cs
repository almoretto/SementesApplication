using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SementesApplication;

namespace SementesApplication.Data
{
    public class SementesApplicationContext : DbContext
    {
        public SementesApplicationContext (DbContextOptions<SementesApplicationContext> options)
            : base(options)
        {
        }

       

      
    }
}
