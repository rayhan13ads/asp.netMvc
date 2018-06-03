﻿using System;
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

        public List<Organisetion> GetAll()
        {
            return _Db.Organisetions.ToList();
        }

        //Add Data
        public bool Add(Organisetion objOrganisetion)
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

        public bool Update(Organisetion objOrganisetion)
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

        public Organisetion GetById(int id)
        {
            return _Db.Organisetions.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        public List<Organisetion> GetSearchCode(Organisetion objOrganisetion)
        {
            return _Db.Organisetions.Where(c => c.OrganisetionCode.Contains(objOrganisetion.OrganisetionCode)).ToList();
        }

        //Search by Name
        public List<Organisetion> GetSearchName(Organisetion objOrganisetion)
        {
            return _Db.Organisetions.Where(c => c.OrganisetionName.Contains(objOrganisetion.OrganisetionName)).ToList();

        }
    }
}
