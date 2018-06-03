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
        public List<Organisetion> GetAll()
        {
            return _organizationRepository.GetAll();
        }

        //Add Data
        public bool Add(Organisetion objOrganisetion)
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

        public bool Update(Organisetion objOrganisetion)
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

        public Organisetion GetById(int id)
        {
            return _organizationRepository.GetById(id);
        }

        //Search By Code

        public List<Organisetion> GetSearchCode(Organisetion objOrganisetion)
        {
            return _organizationRepository.GetSearchCode(objOrganisetion);
        }

        //Search by Name

        public List<Organisetion> GetSearchName(Organisetion objOrganisetion)
        {
            return _organizationRepository.GetSearchName(objOrganisetion);
        }
    }
}
