using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BitmPosSystem.Models;
using BitmPosSystem.Models.Context;
namespace BitmPosSystem.DAL
{
    public class CategoryRepository
    {
        PosSystemContext _Db= new PosSystemContext();
        //Get all informaton form categories Tabel
        public List<Category> GetAll()
        {
            return _Db.Categories.ToList();
        }

        public List<Category> GetAllRoot()
        {
            //var query =
            //    from a in _Db.Categories
            //    from B in _Db.Categories
            //    where B.RootCategoryId == a.Id
            //    select B.RootCategoryId;
            return _Db.Categories.Where(s => s.RootCategoryId == null).ToList();

        }

        //Add Data
        public bool Add(Category objCategory, HttpPostedFileBase file)
        {
            var isAdded = false;
            objCategory.Image = ConvertToBytes(file);
            _Db.Categories.Add(objCategory);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(Category objCategory, HttpPostedFileBase file)
        {
            objCategory.Image = ConvertToBytes(file);
            _Db.Categories.Attach(objCategory);
            _Db.Entry(objCategory).State = EntityState.Modified;
            var isUpdate =_Db.SaveChanges() > 0;
            if (isUpdate)
            {
                return true;
            }

            return isUpdate;

        }
        //delete data
        public bool Delete(int id)
        {
            var isDelete = false;
            var removeData = _Db.Categories.Find();
            if (removeData != null)
            {
                _Db.Categories.Remove(removeData);
                isDelete = _Db.SaveChanges() >0;
                if (isDelete)
                {
                    return true;
                }
            }

            return isDelete;

        }
        //get id
        public Category GetById(int id)
        {
            return _Db.Categories.Find(id);
        }
        // Search code
        public List<Category> GetSearchCode(Category objCategory)
        {
            return _Db.Categories.Where(c => c.CateogryCode.Contains(objCategory.CateogryCode)).ToList();
        }

        //search data
        public List<Category> GetSearchName(Category objCategory)
        {
           return _Db.Categories.Where(c => c.Name.Contains(objCategory.Name)).ToList();

        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
