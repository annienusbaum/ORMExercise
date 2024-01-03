using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORMExercise;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
//goes to the appsettings.json file to get the connection info file

string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);
var repo = new DepartmentRepository(conn);

Console.WriteLine("Type a new Department name");

var newDepartment = Console.ReadLine();

repo.InsertDepartment(newDepartment);

var departments = repo.GetAllDepartments();

foreach(var dept in departments)
{
    Console.WriteLine(dept.Name);
}

//IDbConnection specifies how a database connection should behave
//MySqlConnection(connString); is our specific implementation of our database connection
//dapper will work with anything that behaves like a database connection


departments = repo.GetAllDepartments();

foreach(var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
}