using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
   public  class WebAppContext  : DbContext
    {
        public WebAppContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<LaptopModel> LaptopModel { get; set; }

        public DbSet<OrdersModel> OrdersModel { get; set; }


    }
}
