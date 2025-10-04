using System;
using EmploTaskOne.Application.Services;
using EmploTaskOne.Infrastructure.Repositories;
using EmploTaskOne.Domain.Interfaces;
using EmploTaskOne.Infrastructure.Context;

namespace EmploTaskOne.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EmploTaskOneDbContext())
            {
                var dbContext = new EmploTaskOneDbContext();
                IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);

                var service = new EmployeeStructureService(employeeRepository);
                service.FillEmployeesStructure();

                Console.WriteLine("Row 1 = " + service.GetSuperiorRowOfEmployee(2, 1)); 
                Console.WriteLine("Row 2 = " + service.GetSuperiorRowOfEmployee(4, 3)); 
                Console.WriteLine("Row 3 = " + service.GetSuperiorRowOfEmployee(4, 1)); 
                Console.WriteLine("Row 4 = " + service.GetSuperiorRowOfEmployee(3, 1)); 
                Console.WriteLine("Row 5 = " + service.GetSuperiorRowOfEmployee(6, 1)); 
                Console.WriteLine("Row 6 = " + service.GetSuperiorRowOfEmployee(6, 2)); 
            }

            Console.ReadKey();
        }
    }
}
