using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Dependency
    {

        public int Id { get; init; }
        public int IdTask { get; set; }
        public int DependsOnTask { get; set; }
    }
}
