using Entities.Concretes;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
        //Select * from Categories where categoryId = 3
        public List<Category> GetById(int categoryId)
        {
            return _categoryDal.GetAll(c => c.Id == categoryId);
        }
    }
}
