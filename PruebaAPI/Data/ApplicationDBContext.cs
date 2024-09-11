using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaAPI.Models;
using System.Collections.Generic;

namespace PruebaAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        //Entidades (Modelos)
        public DbSet<Trabajador> Trabajador { get; set; }
    }
}
