# Library

This library is a school project for managing a fictional library database connection using Entity Framework Core. It includes the `AppDbContext` class, which is used to interact with the database.

[Github](https://github.com/filipjaruska/Library)

## File Structure

[Forms](Library/Forms/)

[Components](Library/Components)

[Icons](Library/Icons/)

## AppDbContext

The `AppDbContext` class is defined in [AppDbContext.cs](Library/Data/AppDbContext.cs). It extends the `DbContext` class from Entity Framework Core and includes `DbSet` properties for each of the tables in the database.

## Database Configuration

The XML markup in the configuration file sets up the connection string for the database. The `AppDbContext` class in [AppDbContext.cs](Library/Data/AppDbContext.cs) uses this connection string to connect to the database.

```xml
<?xml version="1.0" encoding="utf-8" ?>

<configuration>
  <connectionStrings>
    <add
      name="DefaultConnection"
      connectionString="Host=; Database=; Username=; Password="
      providerName="System.Data.SqlClient"
    />
  </connectionStrings>
</configuration>
```
