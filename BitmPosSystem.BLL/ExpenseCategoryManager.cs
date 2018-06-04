using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class ExpenseCategoryManager
    {

        ExpenseCategoryRepository _expenseCategoryRepository = new ExpenseCategoryRepository();

        public List<ExpenseCategory> GetAll()
        {
            return _expenseCategoryRepository.GetAll();
        }

        //Add Data
        public bool Add(ExpenseCategory objExpenseCategory)
        {
            var isAdded = false;
            isAdded = _expenseCategoryRepository.Add(objExpenseCategory);
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(ExpenseCategory objExpenseCategory)
        {

            var isUpdate = _expenseCategoryRepository.Update(objExpenseCategory);
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
            isDelete = _expenseCategoryRepository.Delete(id);
            if (isDelete)
            {
                return true;
            }


            return isDelete;

        }
        //get id
        public ExpenseCategory GetByid(int id)
        {
            return _expenseCategoryRepository.GetById(id);
        }
        // Search code
        //public List<ExpenseCategory> GetSearchCode(ExpenseCategory objeExpenseCategory)
        //{
        //    return _expenseCategoryRepository.GetSearchCode(objeExpenseCategory);
        //}

        ////search data
        //public List<ExpenseCategory> GetSearchName(ExpenseCategory objeExpenseCategory)
        //{
        //    return _expenseCategoryRepository.GetSearchName(objeExpenseCategory);

        //}
    }
}
