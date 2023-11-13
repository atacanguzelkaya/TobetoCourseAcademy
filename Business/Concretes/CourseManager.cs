using Business.Abstracts;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public List<Course> GetAll()
        {
            return _courseDal.GetAll();
        }

        public List<Course> GetAllByCategoryId(int id)
        {
            return _courseDal.GetAll(c => c.CategoryId == id);
        }
    }
}
