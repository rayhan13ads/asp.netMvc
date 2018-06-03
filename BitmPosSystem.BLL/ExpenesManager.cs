using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class ExpenesManager
    {

        ExpenseRepository _expenseRepository = new ExpenseRepository();

        public List<Expense> GetAll()
        {
            return _expenseRepository.GetAll();
        }

        //Add Data
        public bool Add(Expense objExpense)
        {
            var isAdded = false;
            isAdded = _expenseRepository.Add(objExpense);
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(Expense objExpense)
        {

            var isUpdate = _expenseRepository.Update(objExpense);
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
            isDelete = _expenseRepository.Delete(id);
            if (isDelete)
            {
                return true;
            }


            return isDelete;

        }
        //get id
        public Expense GetByid(int id)
        {
            return _expenseRepository.GetById(id);
        }
        // Search code
        public List<Expense> GetSearchCode(Expense objExpense)
        {
            return _expenseRepository.GetSearchCode(objExpense);
        }

        //search data
        public List<Expense> GetSearchName(Expense objExpense)
        {
            return _expenseRepository.GetSearchName(objExpense);

        }
    }
}
