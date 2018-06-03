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
    public class EmployeeRepository
    {

        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Customers Tabel

        public List<Employee> GetAll()
        {
            return _Db.Employees.ToList();
        }

        //Add Data
        public bool Add(Employee objeEmployee)
        {
            var isAdded = false;
            _Db.Employees.Add(objeEmployee);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Employee objEmployee)
        {
            _Db.Employees.Attach(objEmployee);
            _Db.Entry(objEmployee).State = EntityState.Modified;
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
            var removeData = _Db.Employees.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Employees.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Employee GetById(int id)
        {
            return _Db.Employees.SingleOrDefault(c => c.Id == id);
        }

        //Search by Code
        public List<Employee> GetSearchCode(Employee objEmployee)
        {
            return _Db.Employees.Where(c => c.EmployeeCode.Contains(objEmployee.EmployeeCode)).ToList();
        }

        //Search by Name
        public List<Employee> GetSearchName(Employee objEmployee)
        {
            return _Db.Employees.Where(c => c.EmployeeName.Contains(objEmployee.EmployeeName)).ToList();
        }
    }
}
