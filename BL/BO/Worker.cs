using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Worker
    {
        public int Id { get; set; }


        public double Cost { get; set; }
        public Expirience Level { get; set; }
        public string? Name { get; set; } = null;
        public string? Email { get; set; } = null;
    }
}
