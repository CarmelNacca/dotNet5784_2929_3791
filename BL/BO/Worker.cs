using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Worker
{
    public int Id { get; set; }

    public string Name { get; set; } ="";
    public string Email { get; set; } = "";
    public Expirience Level { get; set; }

    public double Cost { get; set; }

    public TaskInWorker? Task { get; set; } = null;

    public override string ToString()
    { 
        return ("id=" +Id + ", name=" + Name + ", email=" + Email + ", level=" + Level + ", cost=" + Cost);
    }



}
