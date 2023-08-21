using Agenda_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AgendaCRUD.Models
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }
        public DbSet<Agenda> Agenda { get; set; }
    }
}

