using System.Formats.Asn1;

using Client.Library;

Console.Clear();
Console.CursorVisible = false;
/* Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White; */


while (true)
{
    int ItemSelection = 1;
    string[] items = await Api.GetStringArrayAsync();
    Console.Clear();
    Console.WriteLine("Loading...");
    await Task.Delay(1000);
    while (true) {
        int ItemNumber = 1;
        Console.Clear();
                foreach (string item in items)
                {
                    if (ItemNumber == ItemSelection)
                    {
                        Screen.Print1($"{ItemNumber}. {item}", foreground: ConsoleColor.Black, background: ConsoleColor.White);
                    }
                    else
                    {
                    Screen.Print1($"{ItemNumber}. {item}");

                    }
                    ItemNumber++;
                }
        
        ConsoleKey KeyPress = Console.ReadKey().Key;
        if (KeyPress == ConsoleKey.UpArrow)
        {
            if (ItemSelection < 2)
            {
                ItemSelection = items.Length;
            }
            else
            {
                ItemSelection--;
            }
        }
        else if (KeyPress == ConsoleKey.DownArrow)
        {
            if (ItemSelection > items.Length - 1)
            {
                ItemSelection = 1;
            }
            else
            {
                ItemSelection++;
            }
        }
        else if (KeyPress == ConsoleKey.Enter)
        {
            string SelectString = "You selected:";

            Console.Clear();
            Screen.SurroundWithBorder(new System.Drawing.Point(0, 0), new System.Drawing.Size(items[ItemSelection - 1].Length + SelectString.Length + 1, 1), Screen.BorderStyle.@single);
            Console.SetCursorPosition(1, 1);
            Screen.Print1($"{SelectString} {items[ItemSelection - 1]}", foreground: ConsoleColor.Black, background: ConsoleColor.White);
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Screen.Print1("Press any key to continue...", foreground: ConsoleColor.Yellow, background: ConsoleColor.Blue);
            Console.ReadKey();
            break;
        }
        else if (KeyPress == ConsoleKey.Escape)
        {
            Console.Clear();
            break;
        }
    }
}

