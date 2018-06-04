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
    public class ExpenseCategoryRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form ExpenseCategory Tabel

        public List<ExpenseCategory> GetAll()
        {
            return _Db.ExpenseCategories.ToList();
        }

        //Add Data
        public bool Add(ExpenseCategory objExpenseCategory)
        {
            var isAdded = false;
            _Db.ExpenseCategories.Add(objExpenseCategory);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(ExpenseCategory objExpenseCategory)
        {
            _Db.ExpenseCategories.Attach(objExpenseCategory);
            _Db.Entry(objExpenseCategory).State = EntityState.Modified;
            var isUpdate = _Db.SaveChanges() > 0;
            if (isUpdate)
            {
                return true;
            }
            return isUpdate;
        }

        //Delete Data
        public bool Delete(int Id)
        {
            var isDelete = false;
            var removeData = _Db.ExpenseCategories.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.ExpenseCategories.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public ExpenseCategory GetById(int id)
        {
            return _Db.ExpenseCategories.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        //public List<ExpenseCategory> GetSearchCode(ExpenseCategory objExpenseCategory)
        //{
        //    return _Db.ExpenseCategories.Where(c => c.ExpenseCategoryCode.Contains(objExpenseCategory.ExpenseCategoryCode)).ToList();
        //}

        ////Search by Name
        //public List<ExpenseCategory> GetSearchName(ExpenseCategory objExpenseCategory)
        //{
        //    return _Db.ExpenseCategories.Where(c => c.ExpenseCategoryName.Contains(objExpenseCategory.ExpenseCategoryName)).ToList();

        //}
    }
}
