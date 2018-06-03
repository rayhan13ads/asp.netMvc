using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.Models;
using BitmPosSystem.Models.Context;

namespace BitmPosSystem.DAL
{
    public class BranchRepository
    {
        PosSystemContext _Db = new PosSystemContext();

        //Get all informaton form Branch Tabel

        public List<Branch> GetAll()
        {
            return _Db.Branches.ToList();
        }

        //Add Data
        public bool Add(Branch objBranch)
        {
            var isAdded = false;
            _Db.Branches.Add(objBranch);
            isAdded = _Db.SaveChanges() > 0;
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }
        

        //Update Data 

        public bool Update(Branch objBranch)
        {
            _Db.Branches.Attach(objBranch);
            _Db.Entry(objBranch).State = EntityState.Modified;
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
            var removeData = _Db.Branches.SingleOrDefault(c => c.Id == Id);
            if (removeData != null)
            {
                _Db.Branches.Remove(removeData);
                isDelete = _Db.SaveChanges() > 0;
                if (isDelete)
                {
                    return true;
                }
            }
            return isDelete;
        }

        //GetById 

        public Branch GetById(int id)
        {
            return _Db.Branches.SingleOrDefault(s => s.Id == id);
        }

        //Search by Code
        public List<Branch> GetSearchCode(Branch objBranch)
        {
            return _Db.Branches.Where(c => c.BranchCode.Contains(objBranch.BranchCode)).ToList();
        }

        //Search by Name
        public List<Branch> GetSearchName(Branch objBranch)
        {
            return _Db.Branches.Where(c => c.BranchName.Contains(objBranch.BranchName)).ToList();

        }
    }
}
