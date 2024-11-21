
### Setup Instructions

**1. Install Required NuGet Packages**  
Install the following NuGet packages:  
- Microsoft.EntityFrameworkCore.SqlServer  
- Microsoft.EntityFrameworkCore.Tools  
- Microsoft.EntityFrameworkCore.Design  

---

**2. Create the Database and Table**  
Run the following SQL commands:  

create database loginDB;

use loginDB;

create table tblUser
(
    ID int primary key identity,
    NAME nvarchar(50) not null,
    GENDER nvarchar(10) not null,
    AGE int not null,
    EMAIL nvarchar(50) not null,
    PASSWORD nvarchar(50) not null
);

insert into tblUser(NAME, GENDER, AGE, EMAIL, PASSWORD)
values
('Ron', 'Male', 20, 'ron@gmail.com', 'Ron@123'),
('Simmi', 'Female', 20, 'simmi@gmail.com', 'Simmi@123');

select * from tblUser;


---

**3. Scaffold Models Using Database First Approach**  
Run the following command in **Package Manager Console PM**:  

Scaffold-DbContext "server=Desktop_Name; database=DB_Name; trusted_connection=true; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

---

**4. Add Connection String to `appsettings.json`**  
Add the following in `appsettings.json`:  

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DBCS": "server=Desktop_Name; database=DB_Name; trusted_connection=true; TrustServerCertificate=true;"
  },
  "AllowedHosts": "*"
}


---

**5. Register Connection String in `Program.cs`**  
(add before var app = builder.Build();)
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<LoginDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("DBCS"))
);

---

**6. Add Session Service and Middleware**  

In `Program.cs`:  
- Add session service:  
builder.Services.AddSession();

- Add session middleware:  
app.UseSession();


---

**7. Check Models Home Controller for Action Methods**  
