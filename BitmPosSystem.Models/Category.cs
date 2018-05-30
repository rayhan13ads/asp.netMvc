using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitmPosSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CateogryCode { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int RootCategoryId { get; set; }
        public Category RootCategory { get; set; }
        public List<Category> ChildCategories { get; set; }
        public List<Item> Items { get; set; }
    }
}
