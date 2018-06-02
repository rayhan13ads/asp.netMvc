using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //Add Data
        public bool Add(Category objCategory)
        {
            var isAdded = false;
            _Db.Categories.Add(objCategory);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(Category objCategory)
        {
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
           var removeData = _Db.Categories.SingleOrDefault(c => c.Id == id);
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
        public Category GetByid(int id)
        {
            return _Db.Categories.SingleOrDefault(c => c.Id == id);
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
    }
}
