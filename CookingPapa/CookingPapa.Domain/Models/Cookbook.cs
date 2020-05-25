using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class Cookbook
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
