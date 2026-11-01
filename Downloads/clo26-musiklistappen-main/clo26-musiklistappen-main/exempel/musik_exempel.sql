-- Exempeldatabas för dig som inte har kvar din .db från diskografin.
-- Importera i DB Browser for SQLite: Fil -> Importera -> Databas från SQL-fil.
-- Spara sedan databasen som MusikApp/musik.db.
-- Artisten är påhittad. Byt gärna ut mot din egen favorit.

CREATE TABLE Album (
    Id INTEGER PRIMARY KEY,
    Namn TEXT NOT NULL,
    Utgivningsår INTEGER NOT NULL
);

CREATE TABLE Låtar (
    Id INTEGER PRIMARY KEY,
    AlbumId INTEGER NOT NULL,
    Titel TEXT NOT NULL,
    Längd INTEGER NOT NULL,  -- sekunder
    FOREIGN KEY (AlbumId) REFERENCES Album(Id)
);

INSERT INTO Album (Id, Namn, Utgivningsår) VALUES
    (1, 'Första försöket', 2019),
    (2, 'Andra andan', 2022);

INSERT INTO Låtar (Id, AlbumId, Titel, Längd) VALUES
    (1, 1, 'Startskottet', 187),
    (2, 1, 'Sakta uppför', 242),
    (3, 1, 'Ekot i hallen', 203),
    (4, 2, 'Nattbuss', 266),
    (5, 2, 'Ljus i fönstret', 198),
    (6, 2, 'Sista refrängen', 321);
