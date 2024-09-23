using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Basic_08_L022;

public class Operations
{
    public static void FindEmployeeBySalary(TreeNode<Employee> root)
    {
        Console.Write("\nSearch for employee by salary" +
            "\nEnter: ");
        while (true)
        {                
            int salary = TryParseToIntSalary();
            if (salary == 0)
            {
                break;
            }
            var node = FindNodeEmployee(root, salary);
            if (node != null)
            {
                Console.WriteLine($"Found: {node.Value?.Name} - {node.Value?.Salary}");
            }
            else
            {
                Console.WriteLine("Employee not found!!!");
            }
            Console.Write("\nEnter\t1 - for new search" +
                "\n\t0 - to go to the beginning of the program" +
                "\nEnter: ");
        }
    }

    public static int TryParseToIntSalary()
    {
        int i;
        while (true)
        {
            bool result = int.TryParse(Console.ReadLine(), out i);
            if (result)
            {
                break;
            }
            Console.WriteLine("Incorrect input!!!");
        }
        return i;
    }

    public static TreeNode<Employee>? FindNodeEmployee(TreeNode<Employee>? root, int salary)
    {
        if (salary < root?.Value?.Salary)
        {
            //Ищем в левом поддереве
            if (root.Left != null)
            {
                return FindNodeEmployee(root.Left, salary);
            }
            return null;
        }
        if (salary > root?.Value?.Salary)
        {
            //Ищем в правом поддереве
            if (root.Right != null)
            {
                return FindNodeEmployee(root.Right, salary);
            }
            return null;
        }
        return root;
    }

    public static void TraverseInOrder<T>(TreeNode<T> orignNode, List<T> employeeList)
    {
        if (orignNode.Left != null)
        {
            TraverseInOrder(orignNode.Left, employeeList);
        }
        employeeList.Add(orignNode.Value);
        if (orignNode.Right != null)
        {
            TraverseInOrder(orignNode.Right, employeeList);
        }
    }

    public static void ShowSortedListEmployees(List<Employee> employeeList)
    {
        Console.WriteLine("\nSorted list of employees from tree:");
        foreach (Employee emp in employeeList)
        {
            Console.WriteLine($"{emp.Name} - {emp.Salary}");
        }
    }

    public static void Traverse<T>(TreeNode<T> originNode)
    {
        if (originNode.Left != null)
        {
            Traverse(originNode.Left);
        }
        Console.WriteLine(originNode.Value);
        if (originNode.Right != null)
        {
            Traverse(originNode.Right);
        }
    }

    public static TreeNode<Employee>? AddEmployee()
    {
        Console.WriteLine("Adding Employees");
        TreeNode<Employee>? root = null;
        int count = 1;
        List<Employee> empList = new List<Employee>();

        while (true)
        {
            Console.WriteLine($"\n---------- {count} ----------");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Adding employees finished!");
                break;
            }

            Console.Write("Salary: ");
            int salary = TryParseToIntSalary();

            if (root == null)
            {
                root = new TreeNode<Employee>()
                {
                    Value = new Employee()
                    {
                        Name = name,
                        Salary = salary
                    }
                };
            }
            else
            {
                AddNodeEmployee(root, new TreeNode<Employee>()
                {
                    Value = new Employee()
                    {
                        Name = name,
                        Salary = salary
                    }
                });
            }
            count++;
        }

        return root;
    }
    
    public static void AddNodeEmployee(TreeNode<Employee> rootNode, TreeNode<Employee> nodeToAdd) 
    {
        if (nodeToAdd.Value?.Salary < rootNode.Value?.Salary)
        {
            if (rootNode.Left != null)
            {
                AddNodeEmployee(rootNode.Left, nodeToAdd);
            }
            else
            {
                rootNode.Left = nodeToAdd;
            }
        }
        else
        {
            if (rootNode.Right != null)
            {
                AddNodeEmployee(rootNode.Right, nodeToAdd);
            }
            else
            {
                rootNode.Right = nodeToAdd;
            }
        }
    }
}
