﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using  BitmPosSystem.DAL;
using BitmPosSystem.Models;
namespace BitmPosSystem.BLL
{
   public class CategoryManager
    {
        CategoryRepository repository = new CategoryRepository();

        public List<Category> GetAll()
        {
            return repository.GetAll();
        }

        //Add Data
        public bool Add(Category objCategory, HttpPostedFileBase file)
        {
            var isAdded = false;
            isAdded = repository.Add(objCategory,file);
            if (isAdded)
            {
                return true;
            }

            return isAdded;
        }
        //update data

        public bool Update(Category objCategory, HttpPostedFileBase file)
        {

            var isUpdate = repository.Update(objCategory,file);
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
                isDelete = repository.Delete(id);
                if (isDelete)
                {
                    return true;
                }
            

            return isDelete;

        }
        //get id
        public Category GetByid(int id)
        {
            return repository.GetById(id);
        }
        // Search code
        public List<Category> GetSearchCode(Category objCategory)
        {
            return repository.GetSearchCode(objCategory);
        }

        //search data
        public List<Category> GetSearchName(Category objCategory)
        {
            return repository.GetSearchName(objCategory);

        }

        public List<Category> GetAllRoot()
        {
            return repository.GetAllRoot();
        }

        public int Code()
        {
            return repository.Code();
        }
    }
}
