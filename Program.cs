using System.IO;

namespace Folder_Disintegrator

{
    internal class Program
    {

        static void Main(string[] args)
        {
            string path = @"C:\";



            // закончить с вывидением сообщения об ошибки или некоректом вводе, так же сменить последовательность действий
            // сначало оно должно проверить существует ли файл и можно ли его удалить а только затем спрашивать удалять или нет



            while (true)
            {
                path += UserInput("Введите путь к папке: ");
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Такая папка есть: ");
                    break;
                }
                else if (!Directory.Exists(path))
                {
                    Console.WriteLine("Такой папки не существует: ");
                    continue;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод: ");
                    continue;
                }

            }


            Console.Write("Введите Yes если да, No если не будем удалять: ");

            while (true)
            {
                string message = Console.ReadLine();

                if (message != null & message == "Yes")
                {
                    try
                    {
                        UserDelete(path);
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        Console.WriteLine("У тебя здесь нет власти ");
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


        static string UserDelete(string name)
        {

            foreach (string file in Directory.GetFiles(name))
            {
                File.Delete(file);
            }

            foreach (var path2 in Directory.GetDirectories(name))
            {
                UserDelete(path2);
                Directory.Delete(path2);
            }


            return "17";
        }
        static public string UserInput(string message)
        {
            Console.Write(message);
            string tim = Console.ReadLine();

            return tim;
        }
    }
}
