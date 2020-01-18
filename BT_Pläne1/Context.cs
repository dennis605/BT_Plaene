using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Pläne1
{
    public class Context :DbContext

    {
        public DbSet<Person> Personen { get; set; }
        public DbSet <Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlite(@"Data Source=.\BTPlan.db");  
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Applikation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //Server=(localdb)\MyInstance;Integrated Security=true;
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Integrated Security=true;AttachDbFileName=C:\MyFolder\MyData.mdf;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.Vorname, p.Nachname, p.Rolle });

            modelBuilder.Entity<PersonenEvent>()
                .HasKey(t => new { t.PersonId, t.EventId });

            modelBuilder.Entity<PersonenEvent>()
                .HasOne(p => p.Person)
                .WithMany(p => p.PersonenEvents)
                .HasForeignKey(p => p.PersonId)
                ;
            modelBuilder.Entity<PersonenEvent>()
                .HasOne(e => e.Event)
                .WithMany(e => e.PersonenEvents)
                .HasForeignKey(e => e.EventId)
                ;
        }
    }
}
