using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Framework.Database
{
    public class FrameworkDBContext : DbContext
    {
        private readonly string strConnection = string.Empty;

        public FrameworkDBContext(string connection)
        {
            strConnection = connection;
        }

        public FrameworkDBContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(strConnection);
        }

    }
}
