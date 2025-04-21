using System.Runtime.CompilerServices;

void CreateNewQuestion()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("What is the question?");
    
    Console.ForegroundColor = ConsoleColor.White;
    var Question = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Perfect! Now, what is the answer?");

    Console.ForegroundColor = ConsoleColor.White;
    var Answer = Console.ReadLine();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("What will the save file for this question be called?");

    Console.ForegroundColor = ConsoleColor.White;
    var SaveName = Console.ReadLine();

    string basePath = AppDomain.CurrentDomain.BaseDirectory;
    string folderPath = Path.Combine(basePath, "Questions");
    Directory.CreateDirectory(folderPath);
    string fullPath = Path.Combine(folderPath, SaveName);
    if (File.Exists(fullPath) == true)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That file already exists; Would you like to overwrite it? [y/n]");
        Console.ForegroundColor = ConsoleColor.Yellow;
        var overInput = Console.ReadLine();
        if (overInput.ToLower() == "y")
        {
            Console.WriteLine("Overwriting..");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            return;
        }
    }
    File.WriteAllText(fullPath, Question + "|" + Answer);

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Question saved to: " + fullPath);

    Console.ForegroundColor = ConsoleColor.White;
}
void LoadQuestion()
{
    string basePath = AppDomain.CurrentDomain.BaseDirectory;
    string folderPath = Path.Combine(basePath, "Questions");
    Directory.CreateDirectory(folderPath);

    Console.WriteLine("What is the question you want to load?");

    string[] files = Directory.GetFiles(folderPath, "*.txt");
    for (int i = 0; i < files.Length; i++)
    {
        string fileName = Path.GetFileName(files[i]);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("> " + fileName);
    }
    
    Console.ForegroundColor = ConsoleColor.White;
    var SaveName = Console.ReadLine();

    string fullPath = Path.Combine(folderPath, SaveName);
    if (File.Exists(fullPath) == false)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That file doesn't exist!");
        Console.ForegroundColor = ConsoleColor.White;
        return;
    }
    string SaveContent = File.ReadAllText(fullPath);
    string[] parts = SaveContent.Split("|");

    string Question = parts[0];
    string Answer = parts[1];

    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine(Question);
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    var UserAnswer = Console.ReadLine();

    if (Answer == UserAnswer)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Correct!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wrong! The correct answer is: " + Answer);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}

void Menu()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nHello there! Pick an option:\n  Create a new question: 1\n  Load an existing question: 2\n  Quit: 0");

    var UserInput = Console.ReadLine();

    switch (UserInput)
    {
        case "0":
            break;
        case "1":
            CreateNewQuestion();
            Menu();
            break;
        case "2":
            LoadQuestion();
            Menu();
            break;
    }
}

Menu();