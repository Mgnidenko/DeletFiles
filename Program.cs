using System.IO;

namespace Folder_Disintegrator

{
    internal class Program
    {

        static void Main(string[] args)
        {

            string path = @"C:\";



            Console.Write("Введите Yes если да, No если не будем удалять: ");
            while (true)
            {
                string message = Console.ReadLine();
                if (message != null & message == "Yes")
                {
                    Examination();
                    break;
                }

                else if (message != null & message == "No")
                {
                    Console.WriteLine("Отмена");
                    break;
                }
                else
                {

                    Console.Write("Некорректный ввод, введите Yes или No: ");
                    continue;
                }
            }

            
        }

        static string Examination()
        {
            string path = @"C:\";
            while (true)
            {
                path = @"C:\";
                string userInput = UserInput("Введите путь к папке: ");
                path += userInput;
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Такая папка есть!");
                    break;
                }
                else if (!Directory.Exists(path))
                {
                    Console.WriteLine("Такой папки не существует: ");
                    Console.WriteLine(path);
                    continue;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод: ");
                    continue;
                }

            }




            while (true)
            {
                try
                {
                    UserDelete(path);
                }
                catch (System.UnauthorizedAccessException)
                {
                    Console.WriteLine("У тебя здесь нет власти ");
                    break;
                }
                catch (IOException)
                {
                    Console.WriteLine("Уы файл занят ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }


                Directory.Delete(path, true);
                Console.WriteLine("Папка удалена");
                break;
            }
            return "Успешно удалено";
        }

        static string UserDelete(string path)
        {

            foreach (string file in Directory.GetFiles(path))
            {
                File.Delete(file);
            }

            foreach (var path2 in Directory.GetDirectories(path))
            {
                UserDelete(path2);
                Directory.Delete(path2);
            }


            return "";
        }
        static public string UserInput(string message)
        {
            Console.Write(message);
            string tim = Console.ReadLine();

            return tim;
        }
    }
}
