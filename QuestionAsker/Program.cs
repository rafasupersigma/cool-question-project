Console.WriteLine("Hello there! Pick an option:\n  Create a new question: 1\n  Load an existing question: 2\n  Quit: 0");

var UserInput = Console.ReadLine();

void CreateNewQuestion()
{
    Console.WriteLine("What is the question?");
    var Question = Console.ReadLine();

    Console.WriteLine("Perfect! Now, what is the answer?");
    var Answer = Console.ReadLine();

    Console.WriteLine("What will the save file for this question be called?");
    var SaveName = Console.ReadLine();

    string basePath = AppDomain.CurrentDomain.BaseDirectory;
    string folderPath = Path.Combine(basePath, "Questions");
    Directory.CreateDirectory(folderPath);
    string fullPath = Path.Combine(folderPath, SaveName);
    File.WriteAllText(fullPath, Question + "|" + Answer);

    Console.WriteLine("Question saved to: " + fullPath);
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
        string fileName = Path.GetFileName(files[i]); // just the file name, not full path
        Console.WriteLine(fileName);
    }

    var SaveName = Console.ReadLine();

    string fullPath = Path.Combine(folderPath, SaveName);

    string SaveContent = File.ReadAllText(fullPath);
    string[] parts = SaveContent.Split("|");

    string Question = parts[0];
    string Answer = parts[1];

    Console.WriteLine(Question);

    var UserAnswer = Console.ReadLine();

    if (Answer == UserAnswer)
    {
        Console.WriteLine("Correct!");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Wrong! The correct answer is: " + Answer);
        Console.ReadKey();
    }
}

switch (UserInput)
{
    case "0":
        break;
    case "1":
        CreateNewQuestion();
        break;
    case "2":
        LoadQuestion();
        break;
}