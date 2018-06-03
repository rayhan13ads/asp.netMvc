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
    public class SupplierRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Customers Tabel

        public List<Supplier> GetAll()
        {
            return _Db.Suppliers.ToList();
        }

        //Add Data
        public bool Add(Supplier objeSupplier)
        {
            var isAdded = false;
            _Db.Suppliers.Add(objeSupplier);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Supplier objSupplier)
        {
            _Db.Suppliers.Attach(objSupplier);
            _Db.Entry(objSupplier).State = EntityState.Modified;
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
            var removeData = _Db.Suppliers.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Suppliers.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Supplier GetById(int id)
        {
            return _Db.Suppliers.SingleOrDefault(c => c.Id == id);
        }

        //Search by Code
        public List<Supplier> GetSearchCode(Supplier objSupplier)
        {
            return _Db.Suppliers.Where(c => c.SupplierCode.Contains(objSupplier.SupplierCode)).ToList();
        }

        //Search by Name
        public List<Supplier> GetSearchName(Supplier objEmployee)
        {
            return _Db.Suppliers.Where(c => c.SupplierName.Contains(objEmployee.SupplierName)).ToList();
        }
    }
}
