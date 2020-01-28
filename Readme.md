# NotesApi application

Basic tutorial to show special how to build REST API with EF core framework. It allows to create and view notes and set associated type.

Disclaimer:
Application is just for educational purposes, does not contain proper error handling, logging etc.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine.

### Prerequisites

Development of application requires following software to be installed:
* Visual Studio Code or other C# .net project editor.
* .net core 3.1 SDK (https://dotnet.microsoft.com/download/dotnet-core/3.1)
* .net core entity framework tool - install from command line: dotnet tool install --global dotnet-ef --version 3.1.1
* Docker (if you wish to run application in container)
* PostgreSQL db (either use docker image - https://hub.docker.com/_/postgres) or locally installed
* PostgreSQL db client (to check results) - e.g. pgAdmin 4

### Installing

* Clone repository.
* Run command dotnet restore.
* Create database for project (name defined in appsettings.json file).
* Run command dotnet ef database update (to create database tables and seed data).

#### Running directly

* Execute command dotnet run
* Check that application is running on given url and port by calling curl.

#### Running in docker

Use docker-compose up to start application in container.

### Configurations

Following configurations are part of project:
* apppsetting.json - connection to database.
* docker-compose.yml - docker configuration file.

## Exposed APIs and example of calls

    curl --location --request GET 'http://localhost:5000/api/notes'
    
    curl --location --request POST 'http://localhost:5000/api/notes' \
        --header 'Content-Type: application/json' \
        --data-raw '    {
            "Name": "Reminder",
            "Text": "Some test reminder",
            "NoteTypeId" : 2
        }'

