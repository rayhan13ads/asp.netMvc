using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class ExpenseItemItemManager
    {
        ExpenseItemRepository _ExpenseItemRepository = new ExpenseItemRepository();
        public List<ExpenseItem> GetAll()
        {
            return _ExpenseItemRepository.GetAll();
        }

        //Add Data
        public bool Add(ExpenseItem objExpenseItem)
        {
            var isAdded = false;
            isAdded = _ExpenseItemRepository.Add(objExpenseItem);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(ExpenseItem objExpenseItem)
        {
            var isUpdate = false;
            isUpdate = _ExpenseItemRepository.Update(objExpenseItem);
            if (isUpdate)
            {
                return true;
            }
            return isUpdate;
        }

        //Get Delete
        public bool Delete(int Id)
        {
            var isDelete = false;
            isDelete = _ExpenseItemRepository.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public ExpenseItem GetById(int id)
        {
            return _ExpenseItemRepository.GetById(id);
        }

        //Search By Code

        public List<ExpenseItem> GetSearchCode(ExpenseItem objExpenseItem)
        {
            return _ExpenseItemRepository.GetSearchCode(objExpenseItem);
        }

        //Search by Name

        public List<ExpenseItem> GetSearchName(ExpenseItem objExpenseItem)
        {
            return _ExpenseItemRepository.GetSearchName(objExpenseItem);
        }
    }
}
