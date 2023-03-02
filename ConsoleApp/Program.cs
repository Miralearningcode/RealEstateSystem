using ConsoleApp.Services;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1.Lägg till en felanmälan");
    Console.WriteLine("2.Visa alla felanmälningar");
    Console.WriteLine("3.Visa en specifik felanmälan");
    Console.WriteLine("4.Uppdatera status på felanmälan");
    Console.WriteLine("5.Ta bort en felanmälan");
    Console.Write("\nVälj ett av följande alternativ:");

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
    }

    //Console.WriteLine("Tryck på valfri knapp för att återgå till huvudmenyn");
    Console.ReadKey();

}