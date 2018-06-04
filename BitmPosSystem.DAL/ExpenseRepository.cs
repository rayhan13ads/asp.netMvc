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
    public class ExpenseRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Expense Tabel

        public List<Expense> GetAll()
        {
            return _Db.Expenses.ToList();
        }

        //Add Data
        public bool Add(Expense objExpense)
        {
            var isAdded = false;
            _Db.Expenses.Add(objExpense);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Expense objExpense)
        {
            _Db.Expenses.Attach(objExpense);
            _Db.Entry(objExpense).State = EntityState.Modified;
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
            var removeData = _Db.Expenses.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Expenses.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Expense GetById(int id)
        {
            return _Db.Expenses.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        //public List<Expense> GetSearchCode(Expense objExpense)
        //{
        //    return _Db.Expenses.Where(c => c.ExpenseCode.Contains(objExpense.ExpenseCode)).ToList();
        //}

        ////Search by Name
        //public List<Expense> GetSearchName(Expense objExpense)
        //{
        //    return _Db.Expenses.Where(c => c.ExpenseName.Contains(objExpense.ExpenseName)).ToList();

        //}
    }
}
