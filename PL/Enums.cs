using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{ 
internal class WorkerLevel : IEnumerable
{
    static readonly IEnumerable<BO.ExpiriencePl> s_enums =
(Enum.GetValues(typeof(BO.ExpiriencePl)) as IEnumerable<BO.ExpiriencePl>)!;

    public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
}
internal class Level : IEnumerable
    {
        static readonly IEnumerable<BO.Expirience> s_enums =
    (Enum.GetValues(typeof(BO.Expirience)) as IEnumerable<BO.Expirience>)!;

        public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
    }
};