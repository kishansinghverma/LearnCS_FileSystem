using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer
{
    class Program
    {
        static Directory virtualDir;

        static void Main(string[] args)
        {
            virtualDir = new Directory(getPath());
            while (true)
                displayInstructions();

        }

        public static string getPath()
        {
            Console.Write("Please specify the directory path: ");
            string path = Console.ReadLine();
            return path;
        }
        public static void displayInstructions()
        {
            Console.WriteLine("\n1. Verify with file system");
            Console.WriteLine("2. Create on file system");
            Console.WriteLine("3. Delete from file system");
            Console.WriteLine("4. Get information about directory");
            Console.WriteLine("5. Enable backup service");
            Console.WriteLine("6. Change Directory");
            Console.WriteLine("7. Exit");
            Console.Write("Please select a option: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                doOperation(choice);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid option!\n");
            }
        }
        public static void doOperation(int choice)
        {
            switch (choice)
            {
                case 1:
                    if (virtualDir.exists())
                        Console.WriteLine("Directory exist on file system");
                    else
                        Console.WriteLine("Directory does not exist on file system!");
                    break;

                case 2:
                    int createResult = virtualDir.createDirectory();
                    if (createResult == 0)
                        Console.WriteLine("Directory already exists on file system!");
                    else if (createResult == -1)
                        Console.WriteLine("Some problem occured during directory creation!");
                    else
                        Console.WriteLine("Directory created on file system");
                    break;

                case 3:
                    int delResult = virtualDir.deleteDirectory(true);
                    if (delResult == 0)
                        Console.WriteLine("Directory not exists on file system!");
                    else if (delResult == -1)
                        Console.WriteLine("Some problem occured during deletion!");
                    else
                        Console.WriteLine("Directory deleted from file system");
                    break;

                case 4:
                    Console.WriteLine(virtualDir.getInfo());
                    break;

                case 5:
                    virtualDir.attachListener();
                    break;

                case 6:
                    virtualDir.SetPath(getPath());
                    Console.WriteLine("Directory path changed!\n");
                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Choice!\n");
                    displayInstructions();
                    break;
                   
            }
        }
    }
}
