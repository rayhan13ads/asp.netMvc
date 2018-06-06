using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitmPosSystem.DAL;
using BitmPosSystem.Models;

namespace BitmPosSystem.BLL
{
    public class OrganizationManager
    {
        OrganizationRepository _organizationRepository = new OrganizationRepository();
        public List<Organization> GetAll()
        {
            return _organizationRepository.GetAll();
        }

        //Add Data
        public bool Add(Organization objOrganisetion)
        {
            var isAdded = false;
            isAdded = _organizationRepository.Add(objOrganisetion);
            if (isAdded)
            {
                return true;
            }
            return isAdded;
        }

        //Update Data

        public bool Update(Organization objOrganisetion)
        {
            var isUpdate = false;
            isUpdate = _organizationRepository.Update(objOrganisetion);
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
            isDelete = _organizationRepository.Delete(Id);
            if (isDelete)
            {
                return true;
            }
            return isDelete;

        }

        //get id

        public Organization GetById(int id)
        {
            return _organizationRepository.GetById(id);
        }

        //Search By Code

        public List<Organization> GetSearchCode(Organization objOrganisetion)
        {
            return _organizationRepository.GetSearchCode(objOrganisetion);
        }

        //Search by Name

        public List<Organization> GetSearchName(Organization objOrganisetion)
        {
            return _organizationRepository.GetSearchName(objOrganisetion);
        }
    }
}
