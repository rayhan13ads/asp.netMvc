using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string ContactNumber { get; set; }
        public string EmengancyContactNumber { get; set; }
        public string Email { get; set; }
        public int NID { get; set; }
        public string PrmanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Referance { get; set; }
        public byte[] Image { get; set; }
        public int BranchId { get; set; }

        public Branch Branch { get; set; }
    }
}
