using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BitmPosSystem.Models;
namespace BitmPosSystem.Models.ViewModels
{
    class PurchaseVM
    {
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public double PurchaseDue { get; set; }
        public DateTime PurchasseDate { get; set; }
        public string Remark { get; set; }
        public int OrganisetioId { get; set; }
        public int BranchId { get; set; }
        public int SupplierId { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetailses { get; set; }
      

        public Branch Branch { get; set; }
     
        public Supplier Supplier { get; set; }
        public ICollection<Organization> Organisetions { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public List<SelectListItem>  ItemsDrop { get; set; }
        public List<SelectListItem>  OrganizetionDrop { get; set; }
        public List<SelectListItem> BranchDrop { get; set; }
        public List<SelectListItem> SuplierDrop { get; set; }

    }
}
