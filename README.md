# Garage2.0 Group 1

Exercise 12 in Lexicon's .NET Programming course: group exercise.

## MS SQL Server and SQLite DB

The main branch of the program uses MS SQL Server as database, while the *__victors__* branch uses embedded SQLite database for development. There are two places that need to be changed in order to use the correct DB: `appsettings.json` and `Startup.cs`

### App Settings

In order to use MS SQL Server the connection string in the `appsettings.json` looks as following:

```csharp
"ConnectionStrings": {
  "ParkedVehicleContext": "Server=(localdb)\\mssqllocaldb;Database=ParkedVehicleContext;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

 For SQLite the corresponding part of the `appsettings.json` has this connection string:

```json
"ConnectionStrings": {
  "ParkedVehicleContext": "Data Source=ParkedVehicles.db"
}
```

In case the current `appsettings.json` has the wrong connection string, rename it to `appsettings.json.Back-sqllite`, and rename `appsettings.json.Back-mssql` back to `appsettings.json`.

### Startup

In the file `Startup.cs` the method `ConfigureServices` has the part that needs to be commented out or uncommented, depending on which database system is in use. For the MS SQL Server the lines that add the database context to the services look like this:

```csharp
services.AddDbContext<ParkedVehicleContext>(options => 
         options.UseSqlServer(Configuration.GetConnectionString("ParkedVehicleContext")).EnableSensitiveDataLogging());
```

For SQLite the same lines look in this way:

```csharp
services.AddDbContext<ParkedVehicleContext>(options => 
         options.UseSqlite(Configuration.GetConnectionString("ParkedVehicleContext")));
```

The inactive part is commented out.
