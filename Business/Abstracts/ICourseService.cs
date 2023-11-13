using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        List<Course> GetAll();
        List<Course> GetAllByCategoryId(int id);
    }
}
