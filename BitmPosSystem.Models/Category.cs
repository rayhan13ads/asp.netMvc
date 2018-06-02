using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CateogryCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }

        [Required]
        public int RootCategoryId { get; set; }
        public Category RootCategory { get; set; }
        public List<Category> ChildCategories { get; set; }
        public List<Item> Items { get; set; }
    }
}
