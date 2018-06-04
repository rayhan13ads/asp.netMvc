using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BitmPosSystem.Models
{
    public class Category : IEnumerable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CateogryCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        [DisplayName]
        public virtual int? RootCategoryId { get; set; }
        public virtual Category RootCategory { get; set; }
        public List<Category> ChildCategories { get; set; }
        public List<Item> Items { get; set; }
        [NotMapped]
        public List<SelectListItem> SelectListRootCategoryItems { get; set; }
        [NotMapped]
        public List<Category> Categories { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
