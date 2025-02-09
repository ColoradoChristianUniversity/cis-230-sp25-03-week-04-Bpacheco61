using Client.Library;

Console.Clear();

while (true)
{
    string[] items = await Api.GetStringArrayAsync();
    int ItemNumber = 1;
    int ItemSelection = 1;
            foreach (string item in items)
            {
                Screen.Print1($"{ItemNumber}. {item}");
                ItemNumber++;
            }
    
    Console.ReadKey();
}

