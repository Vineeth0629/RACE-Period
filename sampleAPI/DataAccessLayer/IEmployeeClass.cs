using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IEmployeeClass
    {
         Task<IList<Employe>> GetEmployee();
    }
}
