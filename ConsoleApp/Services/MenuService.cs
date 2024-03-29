﻿using ConsoleApp.Models;

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

            Console.Write("Lägenhetens unika serienummer (6 siffror) ");
            errorReport.ApartmentSerialNumber = Console.ReadLine() ?? "";

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
                    Console.WriteLine($"Lägenhetens unika serienummer: {errorReport.ApartmentSerialNumber}");
                    Console.WriteLine($"Anmälan skapades med email: {errorReport.Email}");
                    Console.WriteLine($"Anmälan skapades: {errorReport.Created}");
                    Console.WriteLine($"Ärendestatus: {errorReport.Status}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Ingen felanmälan finns registrerad i databasen, tryck på valfri tangent för att återgå till huvudmenyn");
            }
        }

        public async Task ListSpecificErrorReportAsync()
        {
            Console.Write("Ange lägenhetens unika serienummer (6 siffror): ");
            var apartmentSerialNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(apartmentSerialNumber))
            {
                //get specific apartment from database
                var errorReport = await ErrorReportService.GetAsync(apartmentSerialNumber);

                if (errorReport != null)
                {
                    Console.WriteLine($"LägenhetsId: {errorReport.Id}");
                    Console.WriteLine($"Anmälarens namn: {errorReport.FirstName} {errorReport.LastName}");
                    Console.WriteLine($"Anmälarens email: {errorReport.Email}");
                    Console.WriteLine($"Anmälarens telefonnummer:{errorReport.PhoneNumber}");
                    Console.WriteLine($"Beskrivning av ärendet: {errorReport.Description}");
                    Console.WriteLine($"Anmälan skapades: {errorReport.Created}");
                    Console.WriteLine($"Ärendestatus: {errorReport.Status}");
                    Console.WriteLine();
                    Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Finns ingen felanmälan skapad med detta serienummer: {apartmentSerialNumber}, tryck på valfri tangent för att återgå till huvudmenyn ");
                }
            }
            else
            {
                Console.WriteLine("Inget serienummer angivet, tryck på valfri tangent för att återgå till huvudmenyn");
            }
        }

        public async Task UpdateSpecificErrorReportAsync()
        {
            Console.Write("Ange lägenhetens unika serienummer (6 siffror): ");
            var apartmentSerialNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(apartmentSerialNumber))
            {
                var errorReport = await ErrorReportService.GetAsync(apartmentSerialNumber);
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
                    Console.WriteLine($"Finns ingen felanmälan skapad med detta serienummer: {apartmentSerialNumber}, tryck på valfri tangent för att återgå till huvudmenyn");
                }
            }
            else
            {
                Console.WriteLine("Inget serienummer angivet, tryck på valfri tangent för att återgå till huvudmenyn");
            }
        }

        public async Task DeleteSpecificErrorReportAsync()
        {
            Console.Write("Ange lägenhetens unika serienummer (6 siffror): ");
            var apartmentSerialNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(apartmentSerialNumber))
            {
                

                Console.Write($"Vill du verkligen ta bort felanmälan för lägenhet { apartmentSerialNumber}? (j/n): ");
                var key = Console.ReadLine();
                if (key == "j")
                {
                    //delete specific apartment from database
                    await ErrorReportService.DeleteAsync(apartmentSerialNumber);
                    Console.WriteLine();
                    Console.WriteLine("Felanmälan är nu borttagen ur systemet, tryck på valfri tangent för att återgå till huvudmenyn");

                }
                else if (key == "n")
                {
                    Console.WriteLine($"Felanmälan för lägenhet {apartmentSerialNumber} har inte tagits bort, tryck på valfri tangent för att återgå till huvudmenyn");
                }
            }
            else
            {
                Console.WriteLine("Inget serienummer angivet, tryck på valfri tangent för att återgå till huvudmenyn");
            }
        }

        public async Task CreateNewJanitorAsync()
        {
            var janitor = new Janitor();

            Console.Write("Förnamn: ");
            janitor.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            janitor.LastName = Console.ReadLine() ?? "";

            Console.Write("Email: ");
            janitor.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            janitor.PhoneNumber = Console.ReadLine() ?? "";


            //save apartment to database
            await JanitorService.SaveAsync(janitor);

            Console.WriteLine();
            Console.WriteLine("En ny fastighetskötare är nu tillagd i systemet, tryck på valfri tangent för att återgå till huvudmenyn");
        }

    
        public async Task CreateNewCommentAsync()
        {
            var comment = new Comment();

            Console.Write("Kommentar: ");
            comment.Text = Console.ReadLine() ?? "";


            //save comment to database
            await CommentService.SaveAsync(comment);
        }

    }
}
