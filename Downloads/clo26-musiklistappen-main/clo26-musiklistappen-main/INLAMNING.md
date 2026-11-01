# Så lämnar du in

**Kurs:** CLO26 — Cloud Developer
**Deadline:** Måndag

---

## Steg för steg

1. **Forka det här repot** (knappen *Fork* uppe till höger på GitHub).
2. **Döp din fork** till `förnamn-clo26-musiklistappen`
   Exempel: `betty-clo26-musiklistappen`, `erik-clo26-musiklistappen`
3. **Klona din fork** till din dator och öppna `MusikApp.slnx`.
4. **Lägg din databas** i `MusikApp/` och döp den till `musik.db`.
   (Ingen databas? Importera `exempel/musik_exempel.sql` i DB Browser for SQLite.)
   Sökvägen står i `MusikApp/appsettings.json`. Heter din fil något annat ändrar du där.
5. **Bygg appen.** Börja med menyn i `Program.cs`, sedan metoderna i `DbHandler.cs`. Läs `UPPGIFT.md` för kraven. Spara ofta med `git commit`.
6. **Fyll i `README.md`** (ersätt mallen med din egen text och lägg in en screenshot på huvudmenyn).
7. **Fyll i `reflektion.md`.**
8. **Kolla att allt stämmer** (checklistan nedan).
9. **Zippa hela mappen** och lämna in på **Google Classroom**, precis som i diskografin.

---

## Checklista innan du lämnar in

- [ ] Appen bygger och startar (`dotnet run` i mappen `MusikApp`)
- [ ] Huvudmeny med numrerade alternativ, och appen avslutar snyggt
- [ ] Minst tre menyval fungerar mot databasen
- [ ] All databaskod ligger i `DbHandler.cs`, ingen SQL i `Program.cs`
- [ ] Alla queries med inmatning är **parameteriserade** (`@titel`), ingen strängkonkatenering
- [ ] `README.md` är ifylld: vad appen gör, hur man kör den och en screenshot
- [ ] `reflektion.md` är ifylld
- [ ] (VG) JOIN eller subquery finns i appen, och "Mina designval" står i README

---

## Vad gör jag om det går fel?

- **"Kunde inte hitta databasen" / tom lista:** kontrollera att `musik.db` ligger i `MusikApp/`, att filnamnet stämmer med `appsettings.json` och att tabellnamnen i din SQL stämmer med din databas.
- **`FileNotFoundException` om `appsettings.json`:** filen saknas. Kopiera `appsettings.example.json` till `appsettings.json` i mappen `MusikApp/`.
- **`NotImplementedException`:** den betyder bara att du inte har skrivit metoden än. Det är meningen att den ska synas tills du har gjort det.
- **Fastnar du:** skriv i klassens chatt eller fråga i början av lektionen. Skicka inte in en halvfärdig uppgift utan att säga till.
