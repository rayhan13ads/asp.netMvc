using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public List<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        //Add Data
        public bool Add(Item objItem, HttpPostedFileBase  file)
        {
            var isAdded = false;
            isAdded = _itemRepository.Add(objItem, file);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(Item objItem, HttpPostedFileBase  file)
        {
            var isUpdate = false;
            isUpdate = _itemRepository.Update(objItem , file);
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
            isDelete = _itemRepository.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }

        //Search By Code

        public List<Item> GetSearchCode(Item objItem)
        {
            return _itemRepository.GetSearchCode(objItem);
        }

        //Search by Name

        public List<Item> GetSearchName(Item objItem)
        {
            return _itemRepository.GetSearchName(objItem);
        }
        public bool Dispose(bool disposing)
        {
            if (disposing)
            {
                _itemRepository.Dispose(disposing);
            }
            return Dispose(disposing);
        }
    }
}
