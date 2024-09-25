using System;
using System.IO;


class Program
{

    public static void Choice()
    {

        Console.WriteLine("1.Add a person");
        Console.WriteLine("2.Edit a person");
        Console.WriteLine("3.Delete a person");
        Console.WriteLine("4.Display a person");
        Console.WriteLine("5.Exit\n");

    }

    public static void Case_1(string path)
    {
        Console.WriteLine("Ex: Dumitru Ion 0712345678");
        string read = Console.ReadLine();
        string[] split = read.Split(' ');

        using (StreamWriter outputFile = new StreamWriter(Path.Combine(path), true))
            if (split.Length == 3)
            {

                if (int.TryParse(split[2], out int a))
                {
                    outputFile.WriteLine("{0} {1} {2}", split[0], split[1], split[2]);
                }

            }
            else
            {
                Console.WriteLine("Error: Invalid format! {0} {1}");
            }

    }

    public static void Case_2(string path, string name)
    {
        Console.Write("ID person: ");
        string ID_Str = Console.ReadLine();
        _ = Int32.Parse(ID_Str);

        if (!int.TryParse(ID_Str, out int ID))
        {
            Console.WriteLine("Error: Invalid id!");
            return;
        }

        if (ID < 0)
        {
            Console.WriteLine("Error: Index < Storage size");
        }

        if (ID > Number_lines(path))
        {
            Console.WriteLine("Error: Index > Storage size");
        }

        if ((ID >= 0) && (ID <= Number_lines(path)))
        {
            string line = null;
            int line_number = 0;

            string GuarnteedWritePath = System.Environment.
                 GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string loc = Path.Combine(GuarnteedWritePath, "Second File");

            using (StreamReader reader = new StreamReader(path))
            {
                using StreamWriter writer = new StreamWriter(loc);
                while ((line = reader.ReadLine()) != null)
                {

                    if (line_number == ID)
                    {
                        string scanf = Console.ReadLine();
                        string[] split = scanf.Split(' ');

                        if (split.Length == 3)
                        {

                            if (int.TryParse(split[2], out int x))
                            {
                                writer.WriteLine("{0} {1} {2}", split[0], split[1], split[2]);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid format!");
                        }

                    }
                    else writer.WriteLine(line);


                    line_number++;
                }
            }
            File.Delete(name);
            File.Move(loc, name);
        }
    }

    public static void Case_3(string path, string name)
    {
        Console.Write("ID person: ");
        string ID = Console.ReadLine();
        int IDP = Int32.Parse(ID);

        if (IDP < 0)
        {
            Console.WriteLine("Error: Index < Storage size");
        }
        if (IDP > Number_lines(path))
        {
            Console.WriteLine("Error: Index > Storage size");
        }
        if ((IDP >= 0) && (IDP <= Number_lines(path)))
        {
            string line = null;
            int line_number = 0;
            string GuarnteedWritePath = System.Environment.
                 GetFolderPath(
                     Environment.SpecialFolder.CommonApplicationData);
            string loc = Path.Combine(GuarnteedWritePath, "Second File");
            using (StreamReader reader = new StreamReader(path))
            {
                using StreamWriter writer = new StreamWriter(loc);
                while ((line = reader.ReadLine()) != null)
                {
                    line_number++;

                    if (line_number == IDP + 1)
                        continue;

                    writer.WriteLine(line);
                }
            }
            File.Delete(name);
            File.Move(loc, name);
        }
    }

    public static void Case_4(string path)
    {

        int counter = 0;

        foreach (string line in System.IO.File.ReadLines(path))
        {

            string[] split = line.Split(' ');

            Console.WriteLine("ID: {0}", counter);
            Console.WriteLine("Name: {0}", split[0]);
            Console.WriteLine("Surname: {0}", split[1]);
            Console.WriteLine("Phone number: {0}", split[2]);

            counter++;
            Console.WriteLine();
        }
    }

    public static void Number_contacts(string path)
    {
        int counter = 0;

        foreach (string line in System.IO.File.ReadLines(path))
        {
            counter++;
        }

        Console.WriteLine("\nNumber of contacts: {0}", counter);
        Console.WriteLine();
    }

    public static int Number_lines(string path)
    {
        int counter = 0;

        foreach (string line in System.IO.File.ReadLines(path))
        {
            counter++;
        }

        return counter;

    }

    public static void Main()
    {
        Console.WriteLine("1.Open a phonebook");
        Console.WriteLine("2.Create a new phonebook");
        Console.Write("Choose: ");
        string line = Console.ReadLine();
        int choice = Int32.Parse(line);

        if ((choice != 1) && (choice != 2))
        {
            Environment.Exit(0);
        }

        Console.Write("Phonebook location: ");
        string name = Console.ReadLine();
        var path = Path.GetFullPath(name);

        if (choice == 1)
        {
            if (File.Exists(path))
            {
                Number_contacts(path);
                Case_4(path);
                Choice();

                Console.Write("Choose: ");
                string read = Console.ReadLine();
                int choice_case = Int32.Parse(read);
                int repeat_alege = 0;
                do
                {

                    if (repeat_alege > 0)
                    {
                        Console.Write("Choose: ");
                        read = Console.ReadLine();
                        choice_case = Int32.Parse(read);
                    }
                    switch (choice_case)
                    {

                        case 1:
                            {
                                Case_1(path);
                                Choice();
                            }
                            break;
                        case 2:
                            {
                                Case_2(path, name);
                                Choice();
                            }
                            break;
                        case 3:
                            {
                                Case_3(path, name);
                                Choice();
                            }
                            break;
                        case 4:
                            {
                                Number_contacts(path);
                                Case_4(path);
                                Choice();
                            }
                            break;
                        case 5:
                            {
                                Environment.Exit(0);
                            }
                            break;
                        default:
                            Choice();
                            break;

                    }
                    repeat_alege++;
                } while (choice_case != 5);

            }
            else
            {
                Console.WriteLine("\nThe location does not exist.");
                System.Threading.Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }

        if (choice == 2)
        {
            var myFile = File.Create(path);
            myFile.Close();

            Console.WriteLine("\nNumber of contacts: 0\n");
            Choice();

            Console.Write("Choose: ");
            string read = Console.ReadLine();
            int choice_case = Int32.Parse(read);
            int repeat_alege = 0;
            do
            {

                if (repeat_alege > 0)
                {
                    Console.Write("Alege: ");
                    read = Console.ReadLine();
                    choice_case = Int32.Parse(read);
                }
                switch (choice_case)
                {

                    case 1:
                        {
                            Case_1(path);
                            Choice();
                        }
                        break;
                    case 2:
                        {
                            Case_2(path, name);
                            Choice();
                        }
                        break;
                    case 3:
                        {
                            Case_3(path, name);
                            Choice();
                        }
                        break;
                    case 4:
                        {
                            Number_contacts(path);
                            Case_4(path);
                            Choice();
                        }
                        break;
                    case 5:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Choice();
                        break;

                }
                repeat_alege++;
            } while (choice_case != 5);



        }
    }
}