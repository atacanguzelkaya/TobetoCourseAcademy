﻿using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Entities.DTOs;
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

        public IResult Add(Course course)
        {
            //buisness codes
            if (course.Name.Length < 2) 
            {   //magic strings
                return new ErrorResult(Messages.CourseNameInvalid);
            }
    
             _courseDal.Add(course);
            return new SuccessResult(Messages.CourseAdded);
        }

        public IDataResult<List<Course>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Course>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(),Messages.CourseListed);
        }

        public IDataResult<List<Course>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<Course> GetById(int courseId)
        {
            return new SuccessDataResult<Course>(_courseDal.Get(c => c.Id == courseId));
        }

        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            //
            //if (DateTime.Now.Hour == 12)
            //{
            //    return new ErrorDataResult<List<CourseDetailDto>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }
    }
}
