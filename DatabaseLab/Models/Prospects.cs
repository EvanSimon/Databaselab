using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DatabaseLab.Models
{
    public class Prospects
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pos { get; set; }
        public float Avg { get; set; }
        
    }
    public class ProspectsDBContext : DbContext
    {
        public DbSet<Prospects> Users { get; set; }
    }

}