using Business.Concretes;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System.ComponentModel;

internal class Program
{
    private static void Main(string[] args)
    {
        CourseManager courseManager = new CourseManager(new EfCourseDal());
        foreach (var course in courseManager.GetAll())
        {
            Console.WriteLine(course.Name);
        }
        Console.WriteLine("-------------------");
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
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