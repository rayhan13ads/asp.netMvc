using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class EmployeeManager
    {
        EmployeeManager _employeeManager = new EmployeeManager();
        public List<Employee> GetAll()
        {
            return _employeeManager.GetAll();
        }

        //Add Data
        public bool Add(Employee objBranch)
        {
            var isAdded = false;
            isAdded = _employeeManager.Add(objBranch);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(Employee objeEmployee)
        {
            var isUpdate = false;
            isUpdate = _employeeManager.Update(objeEmployee);
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
            isDelete = _employeeManager.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public Employee GetById(int id)
        {
            return _employeeManager.GetById(id);
        }

        //Search By Code

        public List<Employee> GetSearchCode(Employee objeEmployeeh)
        {
            return _employeeManager.GetSearchCode(objeEmployeeh);
        }

        //Search by Name

        public List<Employee> GetSearchName(Branch objeBranch)
        {
            return _employeeManager.GetSearchName(objeBranch);
        }
    }
}
