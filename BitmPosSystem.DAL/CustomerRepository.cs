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
    public class CustomerRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Customers Tabel

        public List<Customer> GetAll()
        {
            return _Db.Customers.ToList();
        }

        //Add Data
        public bool Add(Customer objCustomer)
        {
            var isAdded = false;
            _Db.Customers.Add(objCustomer);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Customer objCustomer)
        {
            _Db.Customers.Attach(objCustomer);
            _Db.Entry(objCustomer).State = EntityState.Modified;
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
            var removeData = _Db.Customers.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Customers.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Customer GetById(int id)
        {
            return _Db.Customers.SingleOrDefault(c => c.Id == id);
        }

        //Search by Code
        public List<Customer> GetSearchCode(Customer objCustomer)
        {
            return _Db.Customers.Where(c => c.CustomerCode.Contains(objCustomer.CustomerCode)).ToList();
        }

        //Search by Name
        public List<Customer> GetSearchName(Customer objCustomer)
        {
            return _Db.Customers.Where(c => c.CustomerName.Contains(objCustomer.CustomerName)).ToList();
        }
    }
}
