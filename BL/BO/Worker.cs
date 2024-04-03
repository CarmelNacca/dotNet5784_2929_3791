using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Worker
{
    public int Id { get; set; }

    public string Name { get; set; } ="";//NN
    public string Email { get; set; } = "";//NN
    public Expirience Level { get; set; }//NN

    public double Cost { get; set; }//NN

    public TaskInWorker? Task { get; set; } = null;

    public override string ToString()
    { 
        return ("id=" +Id + ", name=" + Name + ", email=" + Email + ", level=" + Level + ", cost=" + Cost);
    }



}
