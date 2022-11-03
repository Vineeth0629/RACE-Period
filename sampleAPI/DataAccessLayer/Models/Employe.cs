using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class Employe
    {
        public int? Empid { get; set; }
        public string Empname { get; set; }
        public int? Empage { get; set; }
        public int? Departmentid { get; set; }
    }
}
