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
    public class OrganizationRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Branch Tabel

        public List<Organization> GetAll()
        {
            return _Db.Organisetions.ToList();
        }

        //Add Data
        public bool Add(Organization objOrganisetion)
        {
            var isAdded = false;
            _Db.Organisetions.Add(objOrganisetion);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }


        //Update Data 

        public bool Update(Organization objOrganisetion)
        {
            _Db.Organisetions.Attach(objOrganisetion);
            _Db.Entry(objOrganisetion).State = EntityState.Modified;
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
            var removeData = _Db.Organisetions.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Organisetions.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Organization GetById(int id)
        {
            return _Db.Organisetions.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        public List<Organization> GetSearchCode(Organization objOrganisetion)
        {
            return _Db.Organisetions.Where(c => c.OrganizationCode.Contains(objOrganisetion.OrganizationCode)).ToList();
        }

        //Search by Name
        public List<Organization> GetSearchName(Organization objOrganisetion)
        {
            return _Db.Organisetions.Where(c => c.OrganizationName.Contains(objOrganisetion.OrganizationName)).ToList();

        }
    }
}
