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
            if (ItemSelection < 1)
            {
                ItemSelection = items.Length + 1;
            }
            else
            {
                ItemSelection--;
            }
        }
        else if (KeyPress == ConsoleKey.DownArrow)
        {
            if (ItemSelection > items.Length)
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
            Console.Clear();
            Console.WriteLine($"You have selected {items[ItemSelection - 1]}");
            Console.ReadKey();
            break;
        }
    }
}

