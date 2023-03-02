using ConsoleApp.Models;

namespace ConsoleApp.Services
{
    internal class MenuService
    {
        public async Task CreateNewErrorReportAsync()
        {
            var errorReport = new ErrorReport();

            Console.Write("Förnamn: ");
            errorReport.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            errorReport.LastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            errorReport.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            errorReport.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatunamn: ");
            errorReport.StreetName = Console.ReadLine() ?? "";

            Console.Write("Gatunummer: ");
            errorReport.StreetNumber = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            errorReport.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            errorReport.City = Console.ReadLine() ?? "";

            Console.Write("Beskrivning av ärendet: ");
            errorReport.Description = Console.ReadLine() ?? "";

            Console.Write("Ärendestatus(Ej påbörjad, pågående, avslutad): ");
            errorReport.Status = Console.ReadLine() ?? "";

            //save apartment to database
            await ErrorReportService.SaveAsync(errorReport);

            Console.WriteLine();
            Console.WriteLine("Felanmälan är nu skapad, tryck på valfri tangent för att återgå till huvudmenyn");
        }

        public async Task ListAllErrorReportsAsync()
        {
            //get all apartments from database
            var errorReports = await ErrorReportService.GetAllAsync();

            if (errorReports.Any())
            {
                foreach (ErrorReport errorReport in errorReports)
                {
                    //KOLLA OM JAG SKA HA NÅGOT MER HÄR
                    Console.WriteLine($"LägenhetsId: {errorReport.Id}");
                    Console.WriteLine($"Anmälan skapades med email: {errorReport.Email}");
                    Console.WriteLine($"Anmälan skapades: {errorReport.Created}");
                    Console.WriteLine($"Ärendestatus: {errorReport.Status}");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ingen felanmälan finns registrerad i databasen");
            }
        }

        public async Task ListSpecificErrorReportAsync()
        {
            Console.Write("Ange email: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //get specific apartment from database
                var errorReport = await ErrorReportService.GetAsync(email);

                if (errorReport != null)
                {
                    //KOLLA OM NÅGOT MER SKA LISTAS HÄR!
                    Console.WriteLine($"LägenhetsId: {errorReport.Id}");
                    Console.WriteLine($"Anmälarens namn: {errorReport.FirstName} {errorReport.LastName}");
                    Console.WriteLine($"Anmälarens email & telefonnummer: {errorReport.Email} {errorReport.PhoneNumber}");
                    Console.WriteLine($"Beskrivning av ärendet: {errorReport.Description}");
                    Console.WriteLine($"Anmälan skapades: {errorReport.Created}");
                    Console.WriteLine($"Ärendestatus: {errorReport.Status}");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Finns ingen felanmälan skapad med denna email: {email} ");
                }
            }
            else
            {
                Console.WriteLine("Ingen email angiven");
            }
        }

        public async Task UpdateSpecificErrorReportAsync()
        {
            Console.Write("Ange email: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var errorReport = await ErrorReportService.GetAsync(email);
                if (errorReport != null)
                {
                    Console.WriteLine("Uppdatera status (Ej påbörjad, pågående, avslutad):");

                    Console.Write("");
                    errorReport.Status = Console.ReadLine() ?? null!;

                    //update specific apartment from database
                    await ErrorReportService.UpdateAsync(errorReport);
                    Console.WriteLine();
                    Console.WriteLine("Felanmälan är nu uppdaterad, tryck på valfri tangent för att återgå till huvudmenyn");
                }
                else
                {
                    Console.WriteLine($"Finns ingen felanmälan skapad med denna email: {email}");
                }
            }
            else
            {
                Console.WriteLine("Inget emailangiven");
            }
        }

        public async Task DeleteSpecificErrorReportAsync()
        {
            Console.Write("Ange email: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //delete specific apartment from database
                await ErrorReportService.DeleteAsync(email);
                Console.WriteLine();
                Console.WriteLine("Felanmälan är nu borttagen ur systemet, tryck på valfri tangent för att återgå till huvudmenyn");
            }
            else
            {
                Console.WriteLine("Ingen email angiven");
            }
        }
    }
}
