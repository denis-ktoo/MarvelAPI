using MarvelAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace MarvelAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MarvelContext>();

                // Check if the database is already seeded
                if (context.Characters.Any() || context.Movies.Any() || context.Planets.Any() || context.Series.Any())
                {
                    return; // DB has been seeded
                }

                // Create planets
                var earth = new Planet { Name = "Earth", Climate = "Varied", Terrain = "Diverse", Population = 7800000000 };
                var asgard = new Planet { Name = "Asgard", Climate = "Temperate (magical)", Terrain = "Majestic cities, mountains", Population = 500000 };
                var zenWhoberi = new Planet { Name = "Zen-Whoberi", Climate = "Tropical", Terrain = "Forests and mountains", Population = 1000000 };
                var kylos = new Planet { Name = "Kylos", Climate = "Varied", Terrain = "Mountains and valleys", Population = 0 };
                var halfworld = new Planet { Name = "Halfworld", Climate = "Tropical", Terrain = "Alien landscapes", Population = 100000 };
                var planetX = new Planet { Name = "Planet X", Climate = "Tropical", Terrain = "Plant-covered environments", Population = 0 };
                var titan = new Planet { Name = "Titan", Climate = "Harsh", Terrain = "Rocky and mountainous", Population = 2000000 };
                var jotunheim = new Planet { Name = "Jotunheim", Climate = "Icy", Terrain = "Mountains", Population = 100000 };
                var klyntar = new Planet { Name = "Klyntar", Climate = "Unknown", Terrain = "Alien symbiotic environment", Population = 0 };
                var xandar = new Planet { Name = "Xandar", Climate = "Temperate", Terrain = "Urban and plains", Population = 1200000000 };
                var sakaar = new Planet { Name = "Sakaar", Climate = "Desert", Terrain = "Scrap fields", Population = 5000000 };
                var knowhere = new Planet { Name = "Knowhere", Climate = "Unknown", Terrain = "Celestial head", Population = 100000 };
                var nowhere = new Planet { Name = "Nowhere", Climate = "Cold", Terrain = "Mining Colony", Population = 500 };
                var hala = new Planet { Name = "Hala", Climate = "Temperate", Terrain = "Urbanized", Population = 6000000000 };
                var vormir = new Planet { Name = "Vormir", Climate = "Harsh", Terrain = "Rocky cliffs", Population = 0 };
                var ego = new Planet { Name = "Ego", Climate = "Living organism", Terrain = "Varied", Population = 1 };
                var contraxia = new Planet { Name = "Contraxia", Climate = "Cold", Terrain = "Snowy fields", Population = 500000 };
                var nidavellir = new Planet { Name = "Nidavellir", Climate = "Space forge", Terrain = "Industrial", Population = 300 };
                var alfheim = new Planet { Name = "Alfheim", Climate = "Temperate", Terrain = "Forests", Population = 1000000 };
                var svartalfheim = new Planet { Name = "Svartalfheim", Climate = "Dark", Terrain = "Rocky wasteland", Population = 50000 };
                var helheim = new Planet { Name = "Helheim", Climate = "Cold", Terrain = "Mountains", Population = 0 };
                var kamenar = new Planet { Name = "Kamenar", Climate = "Arid", Terrain = "Desert", Population = 2000000 };
                var novaPrime = new Planet { Name = "Nova Prime", Climate = "Temperate", Terrain = "Urban", Population = 10000000 };
                var hoth = new Planet { Name = "Hoth", Climate = "Cold", Terrain = "Icy", Population = 0 };
                var morag = new Planet { Name = "Morag", Climate = "Harsh", Terrain = "Ocean and ruins", Population = 0 };
                var sovereign = new Planet { Name = "Sovereign", Climate = "Temperate", Terrain = "Golden urban landscapes", Population = 1000000 };
                var zennLa = new Planet { Name = "Zenn-La", Climate = "Temperate", Terrain = "Urban, Technologically Advanced", Population = 12000000 };
                var attilan = new Planet { Name = "Attilan", Climate = "Varied (Mobile City)", Terrain = "Urban", Population = 1500000 };


                context.Planets.AddRange(earth, asgard, zenWhoberi, kylos, halfworld, planetX, titan, jotunheim, klyntar, xandar, sakaar, knowhere, hala,
                    vormir, ego, contraxia, nidavellir, alfheim, svartalfheim, helheim, nowhere, kamenar, novaPrime, hoth, morag, sovereign, zennLa, attilan);
                context.SaveChanges();

                // Create characters
                context.Characters.AddRange(
                    new Character { Name = "Tony Stark", Alias = "Iron Man", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Steve Rogers", Alias = "Captain America", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Thor Odinson", Alias = "Thor", Affiliation = "Avengers", HomePlanetID = asgard.Id, HomePlanet = asgard.Name },
                    new Character { Name = "Bruce Banner", Alias = "Hulk", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Natasha Romanoff", Alias = "Black Widow", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Clint Barton", Alias = "Hawkeye", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Peter Quill", Alias = "Star-Lord", Affiliation = "Guardians of the Galaxy", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Gamora", Alias = "Gamora", Affiliation = "Guardians of the Galaxy", HomePlanetID = zenWhoberi.Id, HomePlanet = zenWhoberi.Name },
                    new Character { Name = "Drax", Alias = "Drax the Destroyer", Affiliation = "Guardians of the Galaxy", HomePlanetID = kylos.Id, HomePlanet = kylos.Name },
                    new Character { Name = "Rocket Raccoon", Alias = "Rocket Raccoon", Affiliation = "Guardians of the Galaxy", HomePlanetID = halfworld.Id, HomePlanet = halfworld.Name },
                    new Character { Name = "Groot", Alias = "Groot", Affiliation = "Guardians of the Galaxy", HomePlanetID = planetX.Id, HomePlanet = planetX.Name },
                    new Character { Name = "Loki", Alias = "God of Mischief", Affiliation = "Villains", HomePlanetID = jotunheim.Id, HomePlanet = jotunheim.Name },
                    new Character { Name = "Thanos", Alias = "Thanos", Affiliation = "Villains", HomePlanetID = titan.Id, HomePlanet = titan.Name },
                    new Character { Name = "Wanda Maximoff", Alias = "Scarlet Witch", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Vision", Alias = "Vision", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Sam Wilson", Alias = "Falcon", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Bucky Barnes", Alias = "Winter Soldier", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "T'Challa", Alias = "Black Panther", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Stephen Strange", Alias = "Doctor Strange", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Carol Danvers", Alias = "Captain Marvel", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Nick Fury", Alias = "Nick Fury", Affiliation = "S.H.I.E.L.D.", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Maria Hill", Alias = "Maria Hill", Affiliation = "S.H.I.E.L.D.", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Phil Coulson", Alias = "Phil Coulson", Affiliation = "S.H.I.E.L.D.", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Yondu Udonta", Alias = "Yondu", Affiliation = "Ravagers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Nebula", Alias = "Nebula", Affiliation = "Guardians of the Galaxy", HomePlanetID = titan.Id, HomePlanet = titan.Name },
                    new Character { Name = "Okoye", Alias = "Okoye", Affiliation = "Dora Milaje", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Shuri", Alias = "Shuri", Affiliation = "Wakandan Royal Family", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Mantis", Alias = "Mantis", Affiliation = "Guardians of the Galaxy", HomePlanetID = halfworld.Id, HomePlanet = halfworld.Name },
                    new Character { Name = "Ego", Alias = "Ego", Affiliation = "Villains", HomePlanetID = ego.Id, HomePlanet = ego.Name },
                    new Character { Name = "Hela", Alias = "Hela", Affiliation = "Villains", HomePlanetID = asgard.Id, HomePlanet = asgard.Name },
                    new Character { Name = "Korg", Alias = "Korg", Affiliation = "Revengers", HomePlanetID = sakaar.Id, HomePlanet = sakaar.Name },
                    new Character { Name = "Valkyrie", Alias = "Valkyrie", Affiliation = "Revengers", HomePlanetID = sakaar.Id, HomePlanet = sakaar.Name },
                    new Character { Name = "Hope Van Dyne", Alias = "Wasp", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Scott Lang", Alias = "Ant-Man", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Luis", Alias = "Luis", Affiliation = "Team Ant-Man", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Erik Killmonger", Alias = "Killmonger", Affiliation = "Villains", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Ultron", Alias = "Ultron", Affiliation = "Villains", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Peter Parker", Alias = "Spider-Man", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "May Parker", Alias = "May Parker", Affiliation = "Family", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Ned Leeds", Alias = "Ned Leeds", Affiliation = "Friends of Spider-Man", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "MJ", Alias = "MJ", Affiliation = "Friends of Spider-Man", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Wong", Alias = "Wong", Affiliation = "Masters of the Mystic Arts", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Pepper Potts", Alias = "Pepper Potts", Affiliation = "Stark Industries", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Harley Keener", Alias = "Harley Keener", Affiliation = "Team Iron Man", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Happy Hogan", Alias = "Happy Hogan", Affiliation = "Stark Industries", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Jane Foster", Alias = "Mighty Thor", Affiliation = "Asgardians", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Darcy Lewis", Alias = "Darcy Lewis", Affiliation = "Team Thor", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Nova Prime", Alias = "Irani Rael", Affiliation = "Nova Corps", HomePlanetID = xandar.Id, HomePlanet = xandar.Name },
                    new Character { Name = "Rhomann Dey", Alias = "Rhomann Dey", Affiliation = "Nova Corps", HomePlanetID = xandar.Id, HomePlanet = xandar.Name },
                    new Character { Name = "The Grandmaster", Alias = "Grandmaster", Affiliation = "Rulers of Sakaar", HomePlanetID = sakaar.Id, HomePlanet = sakaar.Name },
                    new Character { Name = "Topaz", Alias = "Topaz", Affiliation = "Grandmaster's Guard", HomePlanetID = sakaar.Id, HomePlanet = sakaar.Name },
                    new Character { Name = "Venom", Alias = "Eddie Brock (Symbiote)", Affiliation = "Anti-Hero", HomePlanetID = klyntar.Id, HomePlanet = klyntar.Name },
                    new Character { Name = "Carnage", Alias = "Cletus Kasady (Symbiote)", Affiliation = "Villains", HomePlanetID = klyntar.Id, HomePlanet = klyntar.Name },
                    new Character { Name = "Red Skull", Alias = "Johann Schmidt", Affiliation = "Villains", HomePlanetID = vormir.Id, HomePlanet = vormir.Name },
                    new Character { Name = "Eitri", Alias = "Eitri the Dwarf King", Affiliation = "Weaponsmith", HomePlanetID = nidavellir.Id, HomePlanet = nidavellir.Name },
                    new Character { Name = "Freyja", Alias = "Queen of Alfheim", Affiliation = "Vanir Gods", HomePlanetID = alfheim.Id, HomePlanet = alfheim.Name },
                    new Character { Name = "Heimdall", Alias = "Heimdall", Affiliation = "Vanir Gods", HomePlanetID = alfheim.Id, HomePlanet = alfheim.Name },
                    new Character { Name = "Malekith", Alias = "Malekith the Accursed", Affiliation = "Dark Elves", HomePlanetID = svartalfheim.Id, HomePlanet = svartalfheim.Name },
                    new Character { Name = "Algrim", Alias = "Kurse", Affiliation = "Dark Elves", HomePlanetID = svartalfheim.Id, HomePlanet = svartalfheim.Name },
                    new Character { Name = "Ronan", Alias = "Ronan the Accuser", Affiliation = "Kree Empire", HomePlanetID = hala.Id, HomePlanet = hala.Name },
                    new Character { Name = "Korath", Alias = "Korath the Pursuer", Affiliation = "Kree Empire", HomePlanetID = hala.Id, HomePlanet = hala.Name },
                    new Character { Name = "Garm", Alias = "Garm", Affiliation = "Mythical Beasts", HomePlanetID = helheim.Id, HomePlanet = helheim.Name },
                    new Character { Name = "Meredith Quill", Alias = "Meredith Quill", Affiliation = "Celestial Lineage", HomePlanetID = ego.Id, HomePlanet = ego.Name },
                    new Character { Name = "Collector", Alias = "Taneleer Tivan", Affiliation = "Cosmic Entities", HomePlanetID = knowhere.Id, HomePlanet = knowhere.Name },
                    new Character { Name = "Cosmo", Alias = "Cosmo the Spacedog", Affiliation = "Guardians of Knowhere", HomePlanetID = knowhere.Id, HomePlanet = knowhere.Name },
                    new Character { Name = "Stakar Ogord", Alias = "Stakar", Affiliation = "Ravagers", HomePlanetID = contraxia.Id, HomePlanet = contraxia.Name },
                    new Character { Name = "Aleta Ogord", Alias = "Aleta", Affiliation = "Ravagers", HomePlanetID = contraxia.Id, HomePlanet = contraxia.Name },
                    new Character { Name = "Adora", Alias = "Nova Commander", Affiliation = "Nova Corps", HomePlanetID = novaPrime.Id, HomePlanet = novaPrime.Name },
                    new Character { Name = "Tundra", Alias = "Ice Elemental", Affiliation = "Mythical Beasts", HomePlanetID = hoth.Id, HomePlanet = hoth.Name },
                    new Character { Name = "Kraglin Obfonteri", Alias = "Kraglin", Affiliation = "Ravagers", HomePlanetID = kamenar.Id, HomePlanet = kamenar.Name },
                    new Character { Name = "Eros", Alias = "Starfox", Affiliation = "Eternals", HomePlanetID = titan.Id, HomePlanet = titan.Name },
                    new Character { Name = "Laufey", Alias = "King of the Frost Giants", Affiliation = "Frost Giants", HomePlanetID = jotunheim.Id, HomePlanet = jotunheim.Name },
                    new Character { Name = "Kamala Khan", Alias = "Ms. Marvel", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Namor", Alias = "Namor the Sub-Mariner", Affiliation = "Talokanil", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Talos", Alias = "Talos", Affiliation = "Skrulls", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "G'iah", Alias = "G'iah", Affiliation = "Skrulls", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Jean Grey", Alias = "Phoenix", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Charles Xavier", Alias = "Professor X", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Erik Lehnsherr", Alias = "Magneto", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Logan", Alias = "Wolverine", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Ororo Munroe", Alias = "Storm", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Hank McCoy", Alias = "Beast", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Scott Summers", Alias = "Cyclops", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Raven Darkholme", Alias = "Mystique", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Kurt Wagner", Alias = "Nightcrawler", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Bishop", Alias = "Bishop", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Bobby Drake", Alias = "Iceman", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Kitty Pryde", Alias = "Shadowcat", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Piotr Rasputin", Alias = "Colossus", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Emma Frost", Alias = "White Queen", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Warren Worthington III", Alias = "Angel", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Deadpool", Alias = "Deadpool", Affiliation = "X-Force", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Cable", Alias = "Cable", Affiliation = "X-Force", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Domino", Alias = "Domino", Affiliation = "X-Force", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Negasonic Teenage Warhead", Alias = "Ellie Phimister", Affiliation = "X-Force", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Vanessa Carlysle", Alias = "Copycat", Affiliation = "Anti-Hero", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Moira MacTaggert", Alias = "Moira MacTaggert", Affiliation = "X-Men Allies", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Adam Warlock", Alias = "Adam Warlock", Affiliation = "Guardians of the Galaxy", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Mantis", Alias = "Mantis", Affiliation = "Guardians of the Galaxy", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Shuri", Alias = "Shuri", Affiliation = "Wakanda", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Valkyrie", Alias = "Valkyrie", Affiliation = "New Asgard", HomePlanetID = asgard.Id, HomePlanet = asgard.Name },
                    new Character { Name = "Moon Knight", Alias = "Marc Spector", Affiliation = "Avengers, Heroes for Hire", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Elektra Natchios", Alias = "Elektra", Affiliation = "Daredevil, Hand", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "The Punisher", Alias = "Frank Castle", Affiliation = "None", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Doctor Doom", Alias = "Victor Von Doom", Affiliation = "Latveria", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Silver Surfer", Alias = "Norrin Radd", Affiliation = "Independent, former herald of Galactus", HomePlanetID = zennLa.Id, HomePlanet = zennLa.Name },
                    new Character { Name = "Scarlet Spider", Alias = "Ben Reilly", Affiliation = "Spider-Man", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Sif", Alias = "Sif", Affiliation = "Asgard", HomePlanetID = asgard.Id, HomePlanet = asgard.Name },
                    new Character { Name = "Black Bolt", Alias = "Black Bolt", Affiliation = "Inhumans", HomePlanetID = attilan.Id, HomePlanet = attilan.Name },
                    new Character { Name = "Quake", Alias = "Daisy Johnson", Affiliation = "S.H.I.E.L.D.", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Lady Sif", Alias = "Lady Sif", Affiliation = "Asgard", HomePlanetID = asgard.Id, HomePlanet = asgard.Name },
                    new Character { Name = "Kingpin", Alias = "Wilson Fisk", Affiliation = "Independent", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Black Knight", Alias = "Dane Whitman", Affiliation = "Avengers", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Gwen Stacy", Alias = "Spider-Gwen", Affiliation = "Independent", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Ghost Rider", Alias = "Robbie Reyes", Affiliation = "Independent", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Mister Sinister", Alias = "Nathaniel Essex", Affiliation = "X-Men, X-Factor", HomePlanetID = earth.Id, HomePlanet = earth.Name },
                    new Character { Name = "Rogue", Alias = "Rogue", Affiliation = "X-Men", HomePlanetID = earth.Id, HomePlanet = earth.Name }
                );


                // Create MCU movies
                context.Movies.AddRange(
                    new Movie { Title = "Iron Man", ReleaseYear = 2008, Director = "Jon Favreau" },
                    new Movie { Title = "The Incredible Hulk", ReleaseYear = 2008, Director = "Louis Leterrier" },
                    new Movie { Title = "Iron Man 2", ReleaseYear = 2010, Director = "Jon Favreau" },
                    new Movie { Title = "Thor", ReleaseYear = 2011, Director = "Kenneth Branagh" },
                    new Movie { Title = "Captain America: The First Avenger", ReleaseYear = 2011, Director = "Joe Johnston" },
                    new Movie { Title = "The Avengers", ReleaseYear = 2012, Director = "Joss Whedon" },
                    new Movie { Title = "Iron Man 3", ReleaseYear = 2013, Director = "Shane Black" },
                    new Movie { Title = "Thor: The Dark World", ReleaseYear = 2013, Director = "Alan Taylor" },
                    new Movie { Title = "Captain America: The Winter Soldier", ReleaseYear = 2014, Director = "Anthony and Joe Russo" },
                    new Movie { Title = "Guardians of the Galaxy", ReleaseYear = 2014, Director = "James Gunn" },
                    new Movie { Title = "Avengers: Age of Ultron", ReleaseYear = 2015, Director = "Joss Whedon" },
                    new Movie { Title = "Ant-Man", ReleaseYear = 2015, Director = "Peyton Reed" },
                    new Movie { Title = "Captain America: Civil War", ReleaseYear = 2016, Director = "Anthony and Joe Russo" },
                    new Movie { Title = "Doctor Strange", ReleaseYear = 2016, Director = "Scott Derrickson" },
                    new Movie { Title = "Guardians of the Galaxy Vol. 2", ReleaseYear = 2017, Director = "James Gunn" },
                    new Movie { Title = "Spider-Man: Homecoming", ReleaseYear = 2017, Director = "Jon Watts" },
                    new Movie { Title = "Thor: Ragnarok", ReleaseYear = 2017, Director = "Taika Waititi" },
                    new Movie { Title = "Black Panther", ReleaseYear = 2018, Director = "Ryan Coogler" },
                    new Movie { Title = "Avengers: Infinity War", ReleaseYear = 2018, Director = "Anthony and Joe Russo" },
                    new Movie { Title = "Ant-Man and the Wasp", ReleaseYear = 2018, Director = "Peyton Reed" },
                    new Movie { Title = "Captain Marvel", ReleaseYear = 2019, Director = "Anna Boden and Ryan Fleck" },
                    new Movie { Title = "Avengers: Endgame", ReleaseYear = 2019, Director = "Anthony and Joe Russo" },
                    new Movie { Title = "Spider-Man: Far From Home", ReleaseYear = 2019, Director = "Jon Watts" },
                    new Movie { Title = "Black Widow", ReleaseYear = 2021, Director = "Cate Shortland" },
                    new Movie { Title = "Shang-Chi and the Legend of the Ten Rings", ReleaseYear = 2021, Director = "Destin Daniel Cretton" },
                    new Movie { Title = "Eternals", ReleaseYear = 2021, Director = "Chloé Zhao" },
                    new Movie { Title = "Spider-Man: No Way Home", ReleaseYear = 2021, Director = "Jon Watts" },
                    new Movie { Title = "Doctor Strange in the Multiverse of Madness", ReleaseYear = 2022, Director = "Sam Raimi" },
                    new Movie { Title = "Thor: Love and Thunder", ReleaseYear = 2022, Director = "Taika Waititi" },
                    new Movie { Title = "Black Panther: Wakanda Forever", ReleaseYear = 2022, Director = "Ryan Coogler" },
                    new Movie { Title = "Ant-Man and the Wasp: Quantumania", ReleaseYear = 2023, Director = "Peyton Reed" },
                    new Movie { Title = "Guardians of the Galaxy Vol. 3", ReleaseYear = 2023, Director = "James Gunn" },
                    new Movie { Title = "The Marvels", ReleaseYear = 2023, Director = "Nia DaCosta" },
                    new Movie { Title = "Blade", ReleaseYear = 2025, Director = "Yann Demange" },
                    new Movie { Title = "Fantastic Four", ReleaseYear = 2025, Director = "Matt Shakman" },
                    new Movie { Title = "Avengers: The Kang Dynasty", ReleaseYear = 2026, Director = "Destin Daniel Cretton" },
                    new Movie { Title = "Avengers: Secret Wars", ReleaseYear = 2027, Director = "TBD" },
                    new Movie { Title = "X-Men: The Mutants", ReleaseYear = 2028, Director = "TBD" },
                    new Movie { Title = "Deadpool 3", ReleaseYear = 2024, Director = "Shawn Levy" },
                    new Movie { Title = "Spider-Man: Into the Spider-Verse", ReleaseYear = 2018, Director = "Bob Persichetti, Peter Ramsey, Rodney Rothman" },
                    new Movie { Title = "Spider-Man: Across the Spider-Verse", ReleaseYear = 2023, Director = "Joaquim Dos Santos, Kemp Powers, Justin K. Thompson" },
                    new Movie { Title = "Spider-Man: Beyond the Spider-Verse", ReleaseYear = 2024, Director = "TBD" },
                    new Movie { Title = "Venom", ReleaseYear = 2018, Director = "Ruben Fleischer" },
                    new Movie { Title = "Venom: Let There Be Carnage", ReleaseYear = 2021, Director = "Andy Serkis" },
                    new Movie { Title = "Morbius", ReleaseYear = 2022, Director = "Daniel Espinosa" },
                    new Movie { Title = "Kraven the Hunter", ReleaseYear = 2024, Director = "J.C. Chandor" },
                    new Movie { Title = "Madame Web", ReleaseYear = 2024, Director = "S.J. Clarkson" },
                    new Movie { Title = "Spider-Woman", ReleaseYear = 2025, Director = "TBD" },
                    new Movie { Title = "X-Men", ReleaseYear = 2000, Director = "Bryan Singer" },
                    new Movie { Title = "X2: X-Men United", ReleaseYear = 2003, Director = "Bryan Singer" },
                    new Movie { Title = "X-Men: The Last Stand", ReleaseYear = 2006, Director = "Brett Ratner" },
                    new Movie { Title = "X-Men Origins: Wolverine", ReleaseYear = 2009, Director = "Gavin Hood" },
                    new Movie { Title = "X-Men: First Class", ReleaseYear = 2011, Director = "Matthew Vaughn" },
                    new Movie { Title = "The Wolverine", ReleaseYear = 2013, Director = "James Mangold" },
                    new Movie { Title = "X-Men: Days of Future Past", ReleaseYear = 2014, Director = "Bryan Singer" },
                    new Movie { Title = "X-Men: Apocalypse", ReleaseYear = 2016, Director = "Bryan Singer" },
                    new Movie { Title = "Logan", ReleaseYear = 2017, Director = "James Mangold" },
                    new Movie { Title = "Deadpool", ReleaseYear = 2016, Director = "Tim Miller" },
                    new Movie { Title = "Deadpool 2", ReleaseYear = 2018, Director = "David Leitch" },
                    new Movie { Title = "Dark Phoenix", ReleaseYear = 2019, Director = "Simon Kinberg" },
                    new Movie { Title = "The New Mutants", ReleaseYear = 2020, Director = "Josh Boone" }
            );


                // Create MCU series
                context.Series.AddRange(
                    new Series { Title = "Agents of S.H.I.E.L.D.", Description = "A group of agents investigate strange occurrences.", Seasons = 7, ReleaseYear = 2013 },
                    new Series { Title = "WandaVision", Description = "Wanda and Vision explore suburban life.", Seasons = 1, ReleaseYear = 2021 },
                    new Series { Title = "Loki", Description = "The God of Mischief's time-bending adventures.", Seasons = 2, ReleaseYear = 2021 },
                    new Series { Title = "The Falcon and the Winter Soldier", Description = "Sam and Bucky face global threats.", Seasons = 1, ReleaseYear = 2021 },
                    new Series { Title = "Hawkeye", Description = "Clint Barton trains a young archer.", Seasons = 1, ReleaseYear = 2021 },
                    new Series { Title = "What If...?", Description = "Alternate realities and possibilities in the Marvel Universe.", Seasons = 2, ReleaseYear = 2021 },
                    new Series { Title = "Moon Knight", Description = "A vigilante with dissociative identity disorder battles threats.", Seasons = 1, ReleaseYear = 2022 },
                    new Series { Title = "Ms. Marvel", Description = "A teenager discovers her extraordinary powers.", Seasons = 1, ReleaseYear = 2022 },
                    new Series { Title = "She-Hulk: Attorney at Law", Description = "Jennifer Walters balances life as a lawyer and superhero.", Seasons = 1, ReleaseYear = 2022 },
                    new Series { Title = "Secret Invasion", Description = "Nick Fury uncovers a Skrull conspiracy on Earth.", Seasons = 1, ReleaseYear = 2023 },
                    new Series { Title = "Echo", Description = "Maya Lopez confronts her past and embraces her future.", Seasons = 1, ReleaseYear = 2024 },
                    new Series { Title = "Ironheart", Description = "Riri Williams builds on Tony Stark's legacy.", Seasons = 1, ReleaseYear = 2024 },
                    new Series { Title = "Agatha: Darkhold Diaries", Description = "Agatha Harkness' dark magical exploits.", Seasons = 1, ReleaseYear = 2024 },
                    new Series { Title = "Daredevil: Born Again", Description = "Matt Murdock returns to protect Hell's Kitchen.", Seasons = 1, ReleaseYear = 2024 },
                    new Series { Title = "The Defenders", Description = "Marvel's street-level heroes unite against a common enemy.", Seasons = 1, ReleaseYear = 2017 },
                    new Series { Title = "Jessica Jones", Description = "A former superhero turns private investigator.", Seasons = 3, ReleaseYear = 2015 },
                    new Series { Title = "Luke Cage", Description = "A bulletproof man fights for his community.", Seasons = 2, ReleaseYear = 2016 },
                    new Series { Title = "Iron Fist", Description = "Danny Rand harnesses the power of the Iron Fist.", Seasons = 2, ReleaseYear = 2017 },
                    new Series { Title = "The Punisher", Description = "Frank Castle seeks revenge for his family's murder.", Seasons = 2, ReleaseYear = 2017 },
                    new Series { Title = "Cloak & Dagger", Description = "Two teens with mysterious powers discover their connection.", Seasons = 2, ReleaseYear = 2018 },
                    new Series { Title = "Runaways", Description = "Teenagers unite against their villainous parents.", Seasons = 3, ReleaseYear = 2017 },
                    new Series { Title = "Inhumans", Description = "A royal family of superpowered beings faces a rebellion.", Seasons = 1, ReleaseYear = 2017 },
                    new Series { Title = "Legion", Description = "A man struggles with mental illness and mutant powers.", Seasons = 3, ReleaseYear = 2017 },
                    new Series { Title = "The Gifted", Description = "A family goes on the run after discovering their children's mutant abilities.", Seasons = 2, ReleaseYear = 2017 },
                    new Series { Title = "Spider-Man: The Animated Series", Description = "Peter Parker battles villains in this iconic series.", Seasons = 5, ReleaseYear = 1994 },
                    new Series { Title = "X-Men: The Animated Series", Description = "Mutants fight for survival in a world that fears them.", Seasons = 5, ReleaseYear = 1992 },
                    new Series { Title = "The Spectacular Spider-Man", Description = "A teenage Peter Parker juggles school and crime-fighting.", Seasons = 2, ReleaseYear = 2008 },
                    new Series { Title = "Avengers: Earth's Mightiest Heroes", Description = "The Avengers unite against powerful threats.", Seasons = 2, ReleaseYear = 2010 },
                    new Series { Title = "Ultimate Spider-Man", Description = "Spider-Man leads a team of young heroes.", Seasons = 4, ReleaseYear = 2012 },
                    new Series { Title = "Marvel's Spider-Man", Description = "Peter Parker's journey as Spider-Man in a modern retelling.", Seasons = 3, ReleaseYear = 2017 },
                    new Series { Title = "X-Men: Evolution", Description = "Young mutants attend a high school for superheroes.", Seasons = 4, ReleaseYear = 2000 },
                    new Series { Title = "Marvel's Avengers Assemble", Description = "The Avengers fight to protect Earth from cosmic threats.", Seasons = 5, ReleaseYear = 2013 },
                    new Series { Title = "Fantastic Four: World's Greatest Heroes", Description = "The Fantastic Four battle intergalactic foes.", Seasons = 1, ReleaseYear = 2006 },
                    new Series { Title = "Hulk and the Agents of S.M.A.S.H.", Description = "The Hulk leads a team of powerful allies.", Seasons = 2, ReleaseYear = 2013 },
                    new Series { Title = "Big Hero 6: The Series", Description = "The adventures of Baymax and the team continue.", Seasons = 3, ReleaseYear = 2017 },
                    new Series { Title = "Marvel Rising: Secret Warriors", Description = "Young heroes team up to save the day.", Seasons = 1, ReleaseYear = 2018 },
                    new Series { Title = "The Super Hero Squad Show", Description = "Heroes and villains battle in a humorous take on Marvel's universe.", Seasons = 2, ReleaseYear = 2009 },
                    new Series { Title = "Silver Surfer: The Animated Series", Description = "The Silver Surfer explores the cosmos.", Seasons = 1, ReleaseYear = 1998 },
                    new Series { Title = "Blade: The Series", Description = "Blade fights vampires in this live-action series.", Seasons = 1, ReleaseYear = 2006 },
                    new Series { Title = "Spider-Man Unlimited", Description = "Spider-Man travels to an alternate Earth to rescue John Jameson.", Seasons = 1, ReleaseYear = 1999 },
                    new Series { Title = "The Avengers: United They Stand", Description = "The Avengers battle threats without key members.", Seasons = 1, ReleaseYear = 1999 },
                    new Series { Title = "Marvel Future Avengers", Description = "Young heroes train under the Avengers.", Seasons = 2, ReleaseYear = 2017 },
                    new Series { Title = "Eternals: The Animated Series", Description = "The Eternals protect Earth from Deviants.", Seasons = 1, ReleaseYear = 2021 },
                    new Series { Title = "Marvel Knights: Black Panther", Description = "The animated adaptation of Black Panther's adventures.", Seasons = 1, ReleaseYear = 2010 },
                    new Series { Title = "X-Men '97", Description = "A continuation of the classic animated series, now set in the MCU.", Seasons = 1, ReleaseYear = 2023 },
                    new Series { Title = "Blade: The Animated Series", Description = "Blade hunts vampires in this animated adaptation.", Seasons = 1, ReleaseYear = 2006 },
                    new Series { Title = "Marvel Future Avengers", Description = "Young heroes train under the Avengers.", Seasons = 2, ReleaseYear = 2017 },
                    new Series { Title = "Marvel Knights: Black Panther", Description = "The animated adaptation of Black Panther's adventures.", Seasons = 1, ReleaseYear = 2010 },
                    new Series { Title = "Eternals: The Animated Series", Description = "The Eternals protect Earth from Deviants.", Seasons = 1, ReleaseYear = 2021 }
                );


                context.SaveChanges(); // Save all changes
            }
        }
    }
}
