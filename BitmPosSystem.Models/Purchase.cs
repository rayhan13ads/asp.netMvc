using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        public double TotalAmount { get; set; }
        public double PurchaseDue { get; set; }
        public DateTime PurchasseDate { get; set; }
        public string Remark { get; set; }
        public int OrganizationId { get; set; }
        public int BranchId { get; set; }
        public int SupplierId { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetailses { get; set; }
        [ForeignKey("BranchId")]
        
        public Branch Branch { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        [ForeignKey("OrganisetioId")]
        public Organization Organisetion { get; set; }
        public List<Income> Incomes { get; set; }
      
    }
}
