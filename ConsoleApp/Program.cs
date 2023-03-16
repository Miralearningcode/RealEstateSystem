using ConsoleApp.Services;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("MW FASTIGHETER AB");
    Console.WriteLine("_____________________________________");
    Console.WriteLine("\n1.Lägg till en felanmälan");
    Console.WriteLine("\n2.Visa alla felanmälningar");
    Console.WriteLine("\n3.Visa en specifik felanmälan");
    Console.WriteLine("\n4.Uppdatera status på felanmälan");
    Console.WriteLine("\n5.Ta bort en felanmälan");
    Console.WriteLine("\n6.Lägg till en fastighetsskötare");
    Console.WriteLine("\n7.Lägg till en kommentar till en felanmälan");
    //Console.WriteLine("8. Se kommentar till en felanmälan");
    Console.Write("\nVälj ett alternativ från ovan:");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await menu.CreateNewErrorReportAsync();
            break;

        case "2":
            Console.Clear();
            await menu.ListAllErrorReportsAsync();
            break;

        case "3":
            Console.Clear();
            await menu.ListSpecificErrorReportAsync();
            break;

        case "4":
            Console.Clear();
            await menu.UpdateSpecificErrorReportAsync();
            break;

        case "5":
            Console.Clear();
            await menu.DeleteSpecificErrorReportAsync();
            break;

        case "6":
            Console.Clear();
            await menu.CreateNewJanitorAsync();
            break;

        case "7":
            Console.Clear();
            await menu.CreateNewCommentAsync();
            break;
    }

    
    Console.ReadKey();

}