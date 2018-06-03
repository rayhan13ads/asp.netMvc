using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class CustomerManager
    {
        CustomerManager _customerManager = new CustomerManager();

        public List<Customer> GetAll()
        {
            return _customerManager.GetAll();
        }

        //get Add
        public bool Add(Customer objCustomer)
        {
            var isAdded = false;
            isAdded = _customerManager.Add(objCustomer);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(Customer objCustomer)
        {
            var isUpdate = false;
            isUpdate = _customerManager.Update(objCustomer);
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
            isDelete = _customerManager.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public Customer GetById(int id)
        {
            return _customerManager.GetById(id);
        }

        //Search By Code

        public List<Customer> GetSearchCode(Customer objCustomer)
        {
            return _customerManager.GetSearchCode(objCustomer);
        }

        //Search by Name

        public List<Customer> GetSearchName(Customer objCustomer)
        {
            return _customerManager.GetSearchName(objCustomer);
        }
    }
}
