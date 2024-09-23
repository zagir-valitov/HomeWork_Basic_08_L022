using HomeWork_Basic_08_L022;
using System.Collections.Generic;

Console.WriteLine(" ---- Home work 8 ----\n");

while(true)
{
    var employees = Operations.AddEmployee();

    if (employees != null)
    {
        List<Employee> employeeList = new List<Employee>();
        Operations.TraverseInOrder(employees, employeeList);
        Operations.ShowSortedListEmployees(employeeList);
        Operations.FindEmployeeBySalary(employees);
    }
    else
    {
        Console.WriteLine("List of employees not found!");
        Console.WriteLine("Enter 0 to exit, press Enter to continue");
        if (Console.ReadLine() == "0")
        {
            break;
        }
    }        
}
Console.WriteLine("Finished!");
