using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
   public class Organisetion
    {
        public int Id { get; set; }
        public string OrganisetionName { get; set; }
        public string OrganisetionCode { get; set; }
       
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public List<Branch> Branches { get; set; }
        public List<Purchase> Purchases { get; set; }
    }
}
