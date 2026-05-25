using Npgsql;
using WebEmployeeManagement.Applications.Interfaces;
using WebEmployeeManagement.Infrastructures.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using WebEmployeeManagement.Applications.Services;
using WebEmployeeManagement.Infrastructures.Repositories;

namespace WebEmployeeManagement.Infrastructures.Repositories;

public class EmployeeRepository : IEmployeeRepository
{    private readonly string _connectionString;

    public EmployeeRepository(IConfiguration configuration)
    {
        _connectionString = configuration["DB_CONNECTION_STRING"]
            ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
            ?? "Host=localhost;Port=5432;Database=sql_training";
    }

    public List<Employee> GetAll()
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT employee_id, employee_name FROM employees ORDER BY employee_id";

        var employees = new List<Employee>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            employees.Add(new Employee
            {
                EmployeeId = reader.GetInt32(0),
                EmployeeName = reader.GetString(1)
            });
        }

        return employees;
    }

    public Employee? Find(int employeeId)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT employee_id, employee_name FROM employees WHERE employee_id = @employeeId";
        command.Parameters.AddWithValue("employeeId", employeeId);

        using var reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        return new Employee
        {
            EmployeeId = reader.GetInt16(0),
            EmployeeName = reader.GetString(1)
        };
    }

    public bool ExistsById(int departmentId)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(1) FROM departments WHERE department_id = @departmentId";
        command.Parameters.AddWithValue("departmentId", departmentId);

        return Convert.ToInt16(command.ExecuteScalar()) > 0;
    }

    public bool HasEmployees(int departmentId)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(1) FROM employees WHERE department_id = @departmentId";
        command.Parameters.AddWithValue("departmentId", departmentId);

        return Convert.ToInt32(command.ExecuteScalar()) > 0;
    }

    public void Add(Department department)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = @"
INSERT INTO departments (department_id, department_name)
VALUES (@departmentId, @departmentName);";
        command.Parameters.AddWithValue("departmentId", department.DepartmentId);
        command.Parameters.AddWithValue("departmentName", department.DepartmentName);
        command.ExecuteNonQuery();
    }

    public void Remove(Department department)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM departments WHERE department_id = @departmentId";
        command.Parameters.AddWithValue("departmentId", department.DepartmentId);
        command.ExecuteNonQuery();
    }

    public void MoveEmployees(int fromDepartmentId, int toDepartmentId)
    {
        using var connection = CreateConnection();
        using var command = connection.CreateCommand();
        command.CommandText = @"
UPDATE employees
SET department_id = @toDepartmentId
WHERE department_id = @fromDepartmentId;";
        command.Parameters.AddWithValue("toDepartmentId", toDepartmentId);
        command.Parameters.AddWithValue("fromDepartmentId", fromDepartmentId);
        command.ExecuteNonQuery();
    }

    public void SaveChanges()
    {

    }

    private NpgsqlConnection CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public void Add(Employee employee)
    {
        throw new NotImplementedException();
    }
}