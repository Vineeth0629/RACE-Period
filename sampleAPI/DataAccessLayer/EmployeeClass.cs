using System;
using DataAccessLayer.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeClass: IEmployeeClass 
    {
        public async Task<IList<Employe>> GetEmployee()
        {
            var dbcontext = new EmployeDBContext();  //Local variable
            List<Employe> lst = (from Employe in dbcontext.Employes  //linq query 
                                 select new Employe
                                 {
                                     Empid = Employe.Empid,
                                     Empname = Employe.Empname,
                                     Empage = Employe.Empage,
                                     Departmentid = Employe.Departmentid
                                 }).ToList<Employe>();  //list of data
            return lst;


        }

    }
}
