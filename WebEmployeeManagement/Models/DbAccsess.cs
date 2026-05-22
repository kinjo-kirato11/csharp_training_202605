using WebEmployeeManagement.Infrastructures.Context;
using WebEmployeeManagement.Models;
using EmployeeList.Models;
using DepartmentList.Models;
using EmployeeContext = WebEmployeeManagement.Infrastructures.Context.AppDbContext;
using Npgsql;
namespace WebEmployeeManagement.Models;
public class DbAccsess
{
    private static readonly string ConnectionString =
        Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
        ?? "Host=PostgreSQL 18;Port=5432;Database=EmployeeManagement;Username=postgres;Password=postgres";
 public static void Initialize()
    {
        using var connection = new NpgsqlConnection(ConnectionString);
        connection.Open();

        var createDepartments = connection.CreateCommand();
        createDepartments.CommandText = @"
CREATE TABLE IF NOT EXISTS departments (
    department_id INTEGER PRIMARY KEY,
    department_name TEXT NOT NULL
);";
        createDepartments.ExecuteNonQuery();

        var createEmployees = connection.CreateCommand();
        createEmployees.CommandText = @"
CREATE TABLE IF NOT EXISTS employees (
    employee_id SERIAL PRIMARY KEY,
    employee_number TEXT NOT NULL,
    employee_name TEXT NOT NULL,
    department_id INTEGER NOT NULL,
    FOREIGN KEY (department_id) REFERENCES departments(department_id)
);";
        createEmployees.ExecuteNonQuery();

        var insertDepartment = connection.CreateCommand();
        insertDepartment.CommandText = @"
INSERT INTO departments (department_id, department_name)
VALUES (10, '営業部')
ON CONFLICT (department_id) DO NOTHING;";
        insertDepartment.ExecuteNonQuery(); 
    }
    }