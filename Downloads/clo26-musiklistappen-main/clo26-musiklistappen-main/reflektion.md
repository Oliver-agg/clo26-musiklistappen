# Reflektion — Musiklistappen

**Namn:** Oliver Ågren
**Datum:** 2026-11-01

---

## Vad var svårast?

Det svåraste var felet `no such table: Songs`. Det berodde på att databasfilen inte fanns i `bin`, så SQLite skapade en tom databas. Jag hittade orsaken genom att skriva ut sökvägen till filen.

---

## Vad lärde du dig?

Jag lärde mig hur en C#-app pratar med en databas med ADO.NET. Jag lärde mig också att en sökväg till databasen utgår från `bin`-mappen. Filen måste därför kopieras dit.

---

## Hur använde du ADO.NET i praktiken — vad kändes naturligt och vad var förvirrande?

Tänk på de fem stegen: öppna anslutning, skapa kommando, skriv SQL, skicka in värden, kör.

Stegen kändes naturliga när jag väl såg mönstret, för de upprepas i varje metod. Jag öppnar en `SqliteConnection`, skapar ett kommando, skriver SQL och skickar in värden med `@`-parametrar. Sedan kör jag med `ExecuteReader`. Det som var förvirrande var att veta vilken databasfil som egentligen öppnades.

---

## Varför ska man använda parameteriserade queries?

Vad kan hända om man klistrar ihop SQL med strängar i stället? (Tänk på Bobby Tables.)

Om man klistrar ihop SQL med strängar kan en användare skriva in egen SQL, till exempel för att radera en tabell. Det kallas SQL injection. Med parametrar behandlas inmatningen alltid som data och aldrig som kod.

---

## Om du hade mer tid — vad hade du lagt till eller gjort annorlunda?

Jag hade lagt till menyval för att lägga till och ta bort låtar, med en bekräftelse innan något tas bort. Jag hade också lagt databasfilen i projektet och ställt in att den kopieras till `bin` från början.

---

## (VG) Varför delade du upp koden som du gjorde?

Resonera kring ditt designval: varför ligger databaskoden i `DbHandler` och inte i `Program.cs`? Vad hade blivit svårare om allt låg i samma fil?

Jag lade all databaskod i `DbHandler` så att `Program.cs` bara sköter menyn och utskrifterna. Då är det lätt att hitta var något går fel. Om allt låg i samma fil hade koden blivit lång och rörig, och det hade varit svårare att ändra en fråga utan att råka ändra menyn.