using Microsoft.EntityFrameworkCore;
using LesiszJakubRetroTool.Data;

var builder = WebApplication.CreateBuilder(args);

// Dodaj us³ugi do kontenera.
builder.Services.AddControllers();

// Rejestracja ApplicationDbContext z u¿yciem SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=blogging.db"));

// Konfiguracja Swaggera
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfiguracja œcie¿ki HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapowanie kontrolerów
app.MapControllers();

app.Run();

//namespace LesiszJakubRetroTool
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
//using LesiszJakubRetroTool.Data;
//using System;
//using System.Linq;

//using var db = new ApplicationDbContext();

////// Note: This sample requires the database to be created before running.
////Console.WriteLine($"Database path: {db.DbPath}.");

////// Create
////Console.WriteLine("Inserting a new blog");
////db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
////db.SaveChanges();

////// Read
////Console.WriteLine("Querying for a blog");
////var blog = db.Blogs
////    .OrderBy(b => b.BlogId)
////    .First();

////// Update
////Console.WriteLine("Updating the blog and adding a post");
////blog.Url = "https://devblogs.microsoft.com/dotnet";
////blog.Posts.Add(
////    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
////db.SaveChanges();

////// Delete
////Console.WriteLine("Delete the blog");
////db.Remove(blog);
////db.SaveChanges();