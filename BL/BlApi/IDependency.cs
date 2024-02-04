using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    /// <summary>
    /// dependency
    /// </summary>
    public interface IDependency
    {
        public int Create(BO.Dependency item);
        public void Delete(int id);

        public BO.Dependency? Read(int id);


        public IEnumerable<BO.Dependency?> ReadAll(Func<BO.Dependency, bool>? filter = null);


        public void Update(BO.Dependency item);


        public BO.Dependency? Read(Func<BO.Dependency, bool> filter);

    }
}
