using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //AutoFac Ekleme kismi
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(
        builder => builder.RegisterModule(new AutofacBusinessModule()));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Services.AddSingleton<ICourseService, CourseManager>();
        //builder.Services.AddSingleton<ICourseDal, EfCourseDal>();

        //builder.Services.AddSingleton<ICategoryService, CategoryManager>();
        //builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();

        //builder.Services.AddSingleton<IInstructorService, InstructorManager>();
        //builder.Services.AddSingleton<IInstructorDal, EfInstructorDal>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}