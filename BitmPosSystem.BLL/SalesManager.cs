using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();

        public List<Sales> GetAll()
        {
            return _salesRepository.GetAll();
        }

        //Add Data
        public bool Add(Sales objSales)
        {
            var isAdded = false;
            isAdded = _salesRepository.Add(objSales);
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(Sales objSales)
        {

            var isUpdate = _salesRepository.Update(objSales);
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
            isDelete = _salesRepository.Delete(id);
            if (isDelete)
            {
                return true;
            }


            return isDelete;

        }
        //get id
        public Sales GetByid(int id)
        {
            return _salesRepository.GetById(id);
        }
        // Search code
        //public List<Sales> GetSearchCode(Sales objSales)
        //{
        //    return _salesRepository.GetSearchCode(objSales);
        //}

        ////search data
        //public List<Sales> GetSearchName(Sales objSales)
        //{
        //    return _salesRepository.GetSearchName(objSales);

        //}
    }
}
