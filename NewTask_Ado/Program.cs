using System;

namespace NewTask_Ado
{
    internal class Program
    {
        static void DrawMenu()
        {
            Console.WriteLine("a/ Display a Departments\nb/ Add Departments\nc/ Delete Department\ne/ Exit");
            Console.WriteLine("--------------------------------------------------------------------------");
        }
        static void Choices()
        {
            string deptName = "";
            int id;
            bool flag = true;
            ConnectionToDatabase connectionToDatabase = new ConnectionToDatabase();
            while (flag)
            {
                char input = Console.ReadKey().KeyChar;
                Console.Clear();
                DrawMenu();
                switch (input)
                {
                    case 'a':
                        Console.WriteLine("The Departments: ");
                        connectionToDatabase.DisplayDepartments();
                        break;
                    case 'b':
                        Console.Write("Enter Department number: ");
                        string Idinput = Console.ReadLine();
                        if (!int.TryParse(Idinput, out id))
                        {
                            Console.WriteLine("Invalid number. Please enter a valid integer.");
                            break;
                        }

                        Console.Write("Enter Department name: ");
                        deptName = Console.ReadLine();

                        try
                        {
                            connectionToDatabase.AddDepartment(id, deptName);
                            Console.WriteLine("Added Successfully");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine($"Error adding department: {e.Message}");
                        }

                        break;
                    case 'c':
                        Console.Write("Enter Department name: ");
                        deptName = Console.ReadLine();
                        try
                        {
                            connectionToDatabase.DeleteDepartment(deptName);
                            Console.WriteLine("Deleted Successfully");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine($"Error deleting department: {e.Message}");
                        }
                        break;

                    case 'e':
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }

        }

        static void Main(string[] args)
        {
            DrawMenu();
            Choices();

        }
    }
}
