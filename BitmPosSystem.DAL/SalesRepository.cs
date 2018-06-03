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
    public class SalesRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Branch Tabel

        public List<Sales> GetAll()
        {
            return _Db.Saleses.ToList();
        }

        //Add Data
        public bool Add(Sales objSales)
        {
            var isAdded = false;
            _Db.Saleses.Add(objSales);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Sales objSales)
        {
            _Db.Saleses.Attach(objSales);
            _Db.Entry(objSales).State = EntityState.Modified;
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
            var removeData = _Db.Saleses.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Saleses.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Sales GetById(int id)
        {
            return _Db.Saleses.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        public List<Sales> GetSearchCode(Sales objSales)
        {
            return _Db.Saleses.Where(c => c.SaleCode.Contains(objSales.SaleCode)).ToList();
        }

        //Search by Name
        public List<Sales> GetSearchName(Sales objSales)
        {
            return _Db.Saleses.Where(c => c.SaleName.Contains(objSales.SaleName)).ToList();

        }
    }
}
