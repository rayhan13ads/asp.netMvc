using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class SupplierManager
    {

        SupplierRepository _sapplierRepository = new SupplierRepository();

        public List<Supplier> GetAll()
        {
            return _sapplierRepository.GetAll();
        }

        //Add Data
        public bool Add(Supplier objSupplier)
        {
            var isAdded = false;
            isAdded = _sapplierRepository.Add(objSupplier);
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(Supplier objSupplier)
        {

            var isUpdate = _sapplierRepository.Update(objSupplier);
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
            isDelete = _sapplierRepository.Delete(id);
            if (isDelete)
            {
                return true;
            }


            return isDelete;

        }
        //get id
        public Supplier GetByid(int id)
        {
            return _sapplierRepository.GetById(id);
        }
        // Search code
        //public List<Supplier> GetSearchCode(Supplier objSupplier)
        //{
        //    return _sapplierRepository.GetSearchCode(objSupplier);
        //}

        ////search data
        //public List<Supplier> GetSearchName(Supplier objSupplier)
        //{
        //    return _sapplierRepository.GetSearchName(objSupplier);

        //}
    }
}
