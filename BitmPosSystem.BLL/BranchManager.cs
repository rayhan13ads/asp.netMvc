using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class BranchManager
    {
        BranchRepository _branchReository = new BranchRepository();
        public List<Branch> GetAll()
        {
            return _branchReository.GetAll();
        }

        //Add Data
        public bool Add(Branch objBranch)
        {
            var isAdded = false;
            isAdded = _branchReository.Add(objBranch);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(Branch objBranch)
        {
            var isUpdate = false;
            isUpdate = _branchReository.Update(objBranch);
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
            isDelete = _branchReository.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public Branch GetById(int id)
        {
            return _branchReository.GetById(id);
        }

        //Search By Code

        public List<Branch> GetSearchCode(Branch objBranch)
        {
            return _branchReository.GetSearchCode(objBranch);
        }

        //Search by Name

        public List<Branch> GetSearchName(Branch objBranch)
        {
            return _branchReository.GetSearchName(objBranch);
        }
    }
}
