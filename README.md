# MarvelAPI

This project is an ASP.NET Core MVC Web API that allows you to explore Marvel Universe to provide information about characters, movies, planets, and series. It is built using .NET 8 and utilizes the Entity Framework Core for database interactions.

### Features

- **Characters Endpoint:** Retrieve details about Marvel characters, their affiliations, and notable traits.
- **Movies Endpoint:** Access information about Marvel movies, including titles, release dates, and the directors.
- **Planets Endpoint:** Explore details of planets in the Marvel universe, such as their climate, population, and notable residents.
- **Series Endpoint:** Fetch data about Marvel series, including number of seasons and released year.

# Preview of the Website
Below is a preview of the website showcasing its design and functionality:

![Image](https://github.com/denis-ktoo/MarvelAPI/blob/master/wwwroot/images/Preview.png?raw=true)

#### Example Endpoints

**1. Characters**
- GET `/api/characters/2`
- Response:
```
{
  "id": 2,
  "name": "Steve Rogers",
  "alias": "Captain America",
  "affiliation": "Avengers",
  "homePlanetID": 1,
  "homePlanet": "Earth"
}
```

**2. Movies**
-  GET `/api/movies/2`
- Response
```
{
  "id": 2,
  "name": "Asgard",
  "climate": "Temperate (magical)",
  "terrain": "Majestic cities, mountains",
  "population": 500000,
  "characters": [
    "https://localhost:7119/api/characters/3/",
    "https://localhost:7119/api/characters/30/"
  ]
}
```

![Image](https://github.com/denis-ktoo/MarvelAPI/blob/master/wwwroot/images/About.png?raw=true)

![Image](https://github.com/denis-ktoo/MarvelAPI/blob/master/wwwroot/images/Documentation.png?raw=true)

# Installation Instructions

To set up the Marvel API, install the appropriate versions of the necessary packages:
```
Install-Package Microsoft.EntityFrameworkCore -Version 8.0.10
Install-Package Pomelo.EntityFrameworkCore.MySql
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 8.0.10
Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.10
```
These commands ensure that the API has the required dependencies for Entity Framework Core and MySQL integration.

After installing the necessary packages, run the following command to apply migrations and update the database schema:
```
Update-Database
```
This will apply migrations and ensure the database is up to date.
