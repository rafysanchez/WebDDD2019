using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Configuracao
{
    public class Contexto : DbContext
    {


        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produto> Produto { set; get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {

            // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyWebApi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
           // string conn = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DDD2019;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
          
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DDD2019;Integrated Security=true;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            string strCon = conn;

            return strCon;
        }

    }
}
