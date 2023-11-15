using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System.ComponentModel;

internal class Program
{
    private static void Main(string[] args)
    {
        //AllClasses();


        CourseManager courseManager = new CourseManager(new EfCourseDal());
        var result = courseManager.GetCourseDetails();
        if (result.Success==true)
        {
            foreach (var course in result.Data)
            {
                Console.WriteLine(course.CourseName + " / " + course.CategoryName);
            }
        }
        else 
        {
            Console.WriteLine(result.Message);
        }

    }

    private static void AllClasses()
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        var result = courseManager.GetCourseDetails();
        foreach (var course in result.Data)
        {
            Console.WriteLine(course.CourseName);
        }
        Console.WriteLine("-------------------");
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetById(1))
        {
            Console.WriteLine(category.Name);
        }
        Console.WriteLine("-------------------");
        InstructorManager instructorManager = new InstructorManager(new EfInstructorDal());
        foreach (var instructor in instructorManager.GetAll())
        {
            Console.WriteLine(instructor.Name);
        }
    }
}