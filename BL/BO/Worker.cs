using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Worker
    {
        int Id { get; set; }


        double Cost { get; set; }
        Expirience Level { get; set; }
        string? Name { get; set; } = null;
        string? Email { get; set; } = null;
    }
}
