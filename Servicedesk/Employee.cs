using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicedesk
{
    public class Employee
    {
        public static int BusinessEntityID { get; set; }
        public static int NationalIDNumber { get; set; }
        public static string Password { get; set; }
        public static string LoginID { get; set; }
        public int OrganizationNode { get; set; }
        public int OrganizationLevel { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
        public int SalariedFlag { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public int CurrentFlag { get; set; }
        public int Rowguid { get; set; }
        public static int DepartmentID { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
