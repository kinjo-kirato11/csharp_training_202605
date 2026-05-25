using WebEmployeeManagement.Infrastructures.Entities;
using WebEmployeeManagement.Applications.Interfaces;
using System;  
using System.Collections.Generic;
using WebEmployeeManagement.Applications.Services;
using WebEmployeeManagement.Infrastructures.Repositories;


namespace WebEmployeeManagement.Applications.Services
{
  public record EmployeeSaveResult(bool Succeeded, string? ErrorMessage);
  
    public record EmployeeDeleteResult(bool Succeeded, string? ErrorMessage);
    public interface IEmployeeService
{
    EmployeeSaveResult Create(Employee employee);
}
    public class EmployeeService : IEmployeeService
    {
            private readonly IEmployeeRepository _employeeRepository;

        public EmployeeSaveResult Create(Employee employee)
        {
            throw new NotImplementedException();
        }

        public class EmployeeServie : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeServie(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public List<Employee> GetAll()
    {
        return _employeeRepository.GetAll();
    }

    public Employee? Find(int employeeId)
    {
        return _employeeRepository.Find(employeeId);
    }

    public bool HasEmployees(int employeeId)
    {
        return _employeeRepository.HasEmployees(employeeId);
    }

    public EmployeeSaveResult Create(Employee employee)
    {
        if (_employeeRepository.ExistsById(employee.EmployeeId))
        {
            return new EmployeeSaveResult(false, "同一IDの従業員が既に存在しています。");
        }

        try
        {
            _employeeRepository.Add(employee);
            _employeeRepository.SaveChanges();
            return new EmployeeSaveResult(true, null);
        }
        catch (Exception ex)
        {
            // ログ出力などのエラーハンドリングを行う
            return new EmployeeSaveResult(false, $"従業員の保存中にエラーが発生しました: {ex.Message}");
        }
    }

    }
    }
}