using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class PurchaseManager
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        public List<Purchase> GetAll()
        {
            return _purchaseManager.GetAll();
        }

        //Add Data
        public bool Add(Purchase objPurchase)
        {
            var isAdded = false;
            isAdded = _purchaseManager.Add(objPurchase);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(Purchase objPurchase)
        {
            var isUpdate = false;
            isUpdate = _purchaseManager.Update(objPurchase);
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
            isDelete = _purchaseManager.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public Purchase GetById(int id)
        {
            return _purchaseManager.GetById(id);
        }

        //Search By Code

        public List<Purchase> GetSearchCode(Purchase objPurchase)
        {
            return _purchaseManager.GetSearchCode(objPurchase);
        }

        //Search by Name

        public List<Purchase> GetSearchName(Purchase objPurchase)
        {
            return _purchaseManager.GetSearchName(objPurchase);
        }
    }
}
