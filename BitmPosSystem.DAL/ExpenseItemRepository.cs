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
    public class ExpenseItemRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form ExpenseItem Tabel

        public List<ExpenseItem> GetAll()
        {
            return _Db.ExpenseItems.ToList();
        }

        //Add Data
        public bool Add(ExpenseItem objExpenseItem)
        {
            var isAdded = false;
            _Db.ExpenseItems.Add(objExpenseItem);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(ExpenseItem objExpenseItem)
        {
            _Db.ExpenseItems.Attach(objExpenseItem);
            _Db.Entry(objExpenseItem).State = EntityState.Modified;
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
            var removeData = _Db.ExpenseItems.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.ExpenseItems.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public ExpenseItem GetById(int id)
        {
            return _Db.ExpenseItems.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        public List<ExpenseItem> GetSearchCode(ExpenseItem objExpenseItem)
        {
            return _Db.ExpenseItems.Where(c => c.ExpenseItemCode.Contains(objExpenseItem.ExpenseItemCode)).ToList();
        }

        //Search by Name
        public List<ExpenseItem> GetSearchName(ExpenseItem objExpenseItem)
        {
            return _Db.ExpenseItems.Where(c => c.ExpenseItemName.Contains(objExpenseItem.ExpenseItemName)).ToList();

        }
    }
}
