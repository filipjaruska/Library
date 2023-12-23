# Library

This library is a school project for managing a fictional library database connection using Entity Framework Core. It includes the `AppDbContext` class, which is used to interact with the database.

Please note that some of the comments and chapters in this project and .md file are intended for educational purposes and may not provide practical value to the code or the reader. Most notes will be most likely incomplete or unfinished since in most cases they will only contain information that i either want aware of or wanted to remind my self of.

[Github](https://github.com/filipjaruska/Library)

### **File Structure**

- **[Data](#appdbcontext)**

- **[Components](#components)**

  - [Data Grid Binder](#datagridbinder)
    - List vs Bindinglist

- **[Forms](#forms)**

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

#### [List vs BindingList](https://stackoverflow.com/questions/2243950/listt-vs-bindinglistt-advantages-disadvantages)

A List<> is simply an automatically resizing array, of items of a given type, with a couple of helper functions (eg: sort). It's just the data, and you're likely to use it to run operations on a set of objects in your model.

A BindingList<> is a wrapper around a typed list or a collection, which implements the IBindingList interface. This is one of the standard interfaces that support two-way databinding. It works by implementing the ListChanged event, which is raised when you add, remove, or set items. Bound controls listen to this event in order to know when to refresh their display.

When you set a BindingSource's DataSource to a List<>, it internally creates a BindingList<> to wrap your list. You may want to pre-wrap your list with a BindingList<> yourself if you want to access it outside of the BindingSource, but otherwise it's just the same. You can also inherit from BindingList<> to implement special behavior when changing items.

IEditableObject is handled by the BindingSource. It'll call BeginEdit on any implementing object when you change the data in any bound control. You can then call EndEdit/CancelEdit on the BindingSource and it will pass it along to your object. Moving to a different row will call EndEdit as well.

### Fomr orsmghnt

## Forms
