using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using BitmPosSystem.Models;
using BitmPosSystem.Models.Context;

namespace BitmPosSystem.DAL
{
    public class ItemRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Item Tabel

        public List<Item> GetAll()
        {
            return _Db.Items.ToList();
        }

        //Add Data
        public bool Add(Item objItem , HttpPostedFileBase file)
        {
            var isAdded = false;
            objItem.Image = ConvertToBytes(file);
            _Db.Items.Add(objItem);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Item objItem, HttpPostedFileBase file)
        {
            objItem.Image = ConvertToBytes(file);
            _Db.Items.Attach(objItem);
            _Db.Entry(objItem).State = EntityState.Modified;
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
            var removeData = _Db.Items.Find(Id);
            if (removeData != null)
            {
                _Db.Items.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }
        public bool Dispose(bool disposing)
        {
            if (disposing)
            {
                _Db.Dispose();
            }
            return Dispose(disposing);
        }
        //GetById 

        public Item GetById(int id)
        {
            return _Db.Items.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        public List<Item> GetSearchCode(Item objItem)
        {
            return _Db.Items.Where(c => c.ItemCode.Contains(objItem.ItemCode)).ToList();
        }

        //Search by Name
        public List<Item> GetSearchName(Item objItem)
        {
            return _Db.Items.Where(c => c.ItemName.Contains(objItem.ItemName)).ToList();

        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}
