# [Library](https://github.com/filipjaruska/Library/tree/School)

This library is a school project for "managing" a fictional library database connection using Entity Framework Core. It includes the `AppDbContext` class, which is used to interact with the database.

Please be aware that this project and its accompanying .md file contain numerous comments and chapters that are primarily educational in nature. They may not necessarily add practical value to the code or to the reader. Many of these notes are likely to be incomplete or unfinished, as they primarily serve to document new information or to serve as reminders.

### **NuGet Packages**

- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/): This is a cross-platform version of the Entity Framework data access technology. It provides object-relational mapping (ORM) support for .NET with SQL Server and other databases.

- [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/): This is the PostgreSQL provider for Entity Framework Core. It allows your .NET application to connect to a PostgreSQL database.

- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/): This is a popular high-performance JSON framework for .NET. It's used here to deserializing JSON.

### **File Structure**

- **[Data](#appdbcontext)**

  - AppDbContext.cs
  - [App.config](#database-connection)

- **[Components](#components)**

  - Form1
    - ChangeButton.cs
    - ChildFormOpener.cs
    - ConfigFileCreator.cs
  - FormCopies
    - ButtonHandler.cs
    - ComboBoxHandler.cs
    - DataSaver.cs
  - FormBooks
    - BookSelection.cs
    - GoogleCustomSearch.cs
  - FormBorrowed
    - ReturnHandler.ccs
  - FormStaff
    - StaffEdit.cs
    - StaffSelection.cs
  - [DataGridBinder.cs](#datagridbinder)
    - List vs Bindinglist
  - DataGridStyle.cs
  - [DeleteDataGridRow.cs](#deletedatagridrowcs)
  - [OpenBrowser.cs](#openbrowsercs)

- **[Forms](#forms)**
  - Form1
  - FormCopies
  - FormStaff
  - FormBooks
  - FormBorrowed
- **[Icons](#)**

## AppDbContext

The `AppDbContext` class is defined in [AppDbContext.cs](Library/Data/AppDbContext.cs). It extends the `DbContext` class from Entity Framework Core and includes `DbSet` properties for each of the tables in the database.

### Database Connection

The XML markup in the configuration file sets up the connection string for the database. The `AppDbContext` class in [AppDbContext.cs](Library/Data/AppDbContext.cs) uses this connection string to connect to the database. Said configuration file would be located in Library/Data/App.config.

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
  <appSettings>
    <add key="GoogleCustomSearchApiKey" value="" />
    <add key="GoogleCustomSearchCx" value="" />
</appSettings>
</configuration>
```

Its also possible to instead replace the connection string configuration manager with the connection string it self.

```csharp
//App.config solution
 string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

 //Hardcoded solution
 string connectionString = "Host=; Database=; Username=; Password=";
```

### Database Configuration

## Components

### DataGridBinder

_[DataGridBinder](/Library/Components/DataGridBinder.cs)_

**Generic Types (`T` and `TViewModel`)**
`T` represents the type of entities in database. `TViewModel` represents the type of view models that used for displaying data in `DataGridView`.

**Function Parameters**

- `queryFunc` is a function that takes an `AppDbContext` and returns an `IQueryable<T>`.

  _Note: `IQueryable<T>` is an interface that represents a collection of objects that can be queried in a LINQ fashion._

- `whereFunc` is a function that takes an entity of type `T` and returns a boolean, it defaults to a function that always returns `true`, meaning no filtering is applied.
- `selectFunc` is a function that takes an entity of type `T` and converts it to a view model of type `TViewModel`.

**Using `AppDbContext`** creates a new instance of the `AppDbContext` class, and the `using` statement ensures that the context is disposed of correctly when the block is exited.

_Note: It's a good practice to wrap database operations in a `using` statement to ensure proper resource management._

**Query Execution**

- `var query = queryFunc(context);` executes the provided `queryFunc` to get an `IQueryable<T>` representing the initial set of data from the database.
- `var filteredQuery = query.Where(whereFunc ?? (_ => true));` filters the data based on the `whereFunc` (or a default filter if `whereFunc` is null).

  _Note: The `??` operator is the null-coalescing operator, which means if `whereFunc` is null, it uses a default filter that always returns `true`._

- `var viewModelList = filteredQuery.Select(selectFunc).ToList();`: Projects the filtered entities into view models using the `selectFunc` and converts the result to a list.

#### [`List vs BindingList`](https://stackoverflow.com/questions/2243950/listt-vs-bindinglistt-advantages-disadvantages)

A `List<>` is simply an automatically resizing array, of items of a given type, with a couple of helper functions (eg: sort). It's just the data, and you're likely to use it to run operations on a set of objects in your model.

A `BindingList<>` is a wrapper around a typed list or a collection, which implements the IBindingList interface. This is one of the standard interfaces that support two-way databinding. It works by implementing the ListChanged event, which is raised when you add, remove, or set items. Bound controls listen to this event in order to know when to refresh their display.

When you set a BindingSource's DataSource to a List<>, it internally creates a BindingList<> to wrap your list. You may want to pre-wrap your list with a BindingList<> yourself if you want to access it outside of the BindingSource, but otherwise it's just the same. You can also inherit from BindingList<> to implement special behavior when changing items.

IEditableObject is handled by the BindingSource. It'll call BeginEdit on any implementing object when you change the data in any bound control. You can then call EndEdit/CancelEdit on the BindingSource and it will pass it along to your object. Moving to a different row will call EndEdit as well.

### DeleteDataGridRow.cs

A class that provides a method to delete the selected row from a DataGridView and the corresponding record from the database. It uses Entity Framework Core to interact with the database. The method is generic and can be used with any entity type and corresponding view model type.

#### [Type Parameters](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-type-parameters)

Type parameters, often denoted by `<T>`, `<T1, T2, ...>`, etc., are placeholders for actual types. They allow you to define generic classes, interfaces, methods, and delegates that can work with different data types while still providing type safety and performance benefits of strong typing.

In a this method `DeleteSelectedRow<T, TViewModel>`, `T` and `TViewModel` are type parameters. They represent any type, and the actual types are specified when the method is called.

##### Constraints

Specified by the `where` keyword, can be applied to type parameters to require more specific type arguments. For example, `where T : class` specifies that `T` must be a reference type. Other constraints can restrict type parameters to value types, to classes that have a parameterless constructor, to classes that inherit from a particular base class, or to classes that implement a particular interface.

### OpenBrowser.cs

It takes a base URL and an optional search query as parameters, URL encodes the search query, appends it to the base URL, and opens the resulting URL in the default web browser. **It's a "Utility Class"**

## Forms
