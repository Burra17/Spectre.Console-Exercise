using Spectre.Console;
namespace Spectre.Console_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ansiconsole istället för Console.WriteLine
            AnsiConsole.MarkupLine("[bold green]Hello, World![/]"); // Skriv ut "Hello, World!" i fet grön text
            AnsiConsole.MarkupLine("Welcome to Spectre.Console!"); // Skriv ut en välkomstmeddelande i standardstil
            AnsiConsole.MarkupLine("[slowblink]Hello World[/]"); // Skriv ut "Hello World" med en blinkande effekt

            AnsiConsole.Markup("Hello world! "); // Skriv ut "Hello world!" utan radbrytning istället för Console.Write
            AnsiConsole.WriteLine();

            AnsiConsole.MarkupLine("[underline]This is underlined text.[/]"); // Skriv ut understruken text

            AnsiConsole.WriteLine();

            var danger = new Style(foreground: Color.Red, decoration: Decoration.Bold | Decoration.Underline); // Skapa en stil med röd färg, fetstil och understrykning

            // Använd den direkt i AnsiConsole.Write():
            AnsiConsole.Write(new Markup("This is dangerous text!", danger));
            AnsiConsole.WriteLine(); // Lägg till en radbrytning efter texten
            AnsiConsole.WriteLine();

            // Läsa in från användaren
            int age = AnsiConsole.Ask<int>("What is your [green]age[/]?"); // Fråga användaren om deras ålder med grön text för "age", Om användaren skriver ogiltligt svar så skriver den ut invalid input som redan är inbyggt
            AnsiConsole.MarkupLine($"You are [bold]{age}[/] years old!"); // Skriv ut användarens ålder i fetstil


            // Promt för att låta användare välja bland alternativ, Har också inbbygt att det skriver välj ett giltligt alternativ om man skriver fel
            string happyText = AnsiConsole.Prompt(
                new TextPrompt<string>("Are you happy?")
                .AddChoice("yes")
                .AddChoice("no")
                .DefaultValue("yes") // Sätter värdet till yes om användaren lämnar tomt.
                );

            AnsiConsole.MarkupLine($"Happy: {happyText}"); // Skriva ut resultat på samma sätt som vi lärt oss

            List<string> listNames = [ // En vanlig lista med namn
                "André",
                "Joakim",
                "Bozhidar",
                "Georgia",
                "Nemo",
                "Gustav",
                "Martin"
                ];

            // Låter användaren gå igenom listan med pilarna och välja vilken den vill välja
            string yourName = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Which is your name?")
                .PageSize(4) // begränsar hur många alternativ som visas
                .MoreChoicesText("Move down to reveal more choices") // skriver ut hjälpmedellande till användaren
                .AddChoices(listNames)
                );

            AnsiConsole.MarkupLine($"Your name is [red] {yourName}[/]"); // Skriver ut vad användaren valde i rött
            AnsiConsole.WriteLine();

            // Skapa en lista med djurnamn
            List<string> petName = [
                "Nemo",
                "Hugo",
                "Kennedy",
                "Billy",
                "Leif"
                ];
            // Skapa en ny lista baserat på de valda favoritnamnen
            List<string> favouriteName = AnsiConsole.Prompt( 
                new MultiSelectionPrompt<string>() // Kan välja flera alternativ
                    .Title("Which are your favourite names?") // Titel
                    .InstructionsText("Press <space to toggle, <enter> to accept") // Instruktionstext till användaren
                    .AddChoices(petName)
                );
            foreach ( string name in favouriteName ) // Enkel foreach för att skriva ut namnen
            {
                AnsiConsole.WriteLine( name );
            }

            AnsiConsole.WriteLine();

            Table table = new Table(); // Skapa ny tabell

            table.AddColumn("First Name"); // Lägga till kolumner
            table.AddColumn("Las Name");
            table.AddColumn("Age");

            table.AddRow("André", "Pettersson", "22"); // Fylla värde i kolumnerna
            table.AddRow("Joakim", "Andersson", "31");
            table.AddRow("Bozhidar", "Ivanov", "27");

            AnsiConsole.Write(table);


        }
    }
}
