

	**Secure Document Storage System**
A secure ASP.NET Core Web API project that allows registered users to upload, retrieve, and version
documents. All files are stored as BLOBs in a SQL Server database, and endpoints are protected using JWT authentication.

**Company Task Requirements (Covered)**
-	User registration & login with JWT
-	Upload documents with automatic version control
-	Retrieve latest or specific file versions
-	Use SQL Server and store files as BLOBs
-	Swagger API documentation
-	Protect endpoints using [Authorize]
	Technologies Used
-	ASP.NET Core Web API
-	Entity Framework Core
-	SQL Server
-	JWT Authentication
-	Swagger
-	 C#
-	 Visual Studio 2022

**	Setup Instructions**
1.	Clone the repository**

git clone https://github.com/your-username/SecureDocStorage.git cd SecureDocStorage
2.	Open in Visual Studio 2022**

3.	Set up database**

-Open `appsettings.json` and update the connection string:


"ConnectionStrings": {
"DefaultConnection": "Server=YOUR_SERVER;Database=SecureDocStorageDB;Trusted_Connection=True;"

}

4.	Apply EF Core Migrations**
-	In Package Manager Console: Update-Database
5.	Run the application**
-	Press `F5` in Visual Studio or run: dotnet run

**	API Documentation**
Swagger enabled and available 
at:https://localhost:{port}/swagger


**	Authentication**
Method	Endpoint	Description
POST  	| `/api/auth/register	Register user

POST  	/api/auth/login	once i Login then generate token





**	Document Management**
Method	Endpoint	Description
POST  	`/api/document/upload	Upload new document
GET       	`/api/document/{filename}`	Get latest version of a document  
GET	`/api/document/{filename}?revision=0`	Get specific version by revision  

All document routes require a Bearer token: 
Authorization:Bearer {your-token}

Testing Instructions

**	Using Swagger**

1.	Register & login via Swagger
2.	Copy JWT token and click **Authorize**
3.	Upload a document using `/api/document/upload`
4.	Retrieve it using:
-	`/api/document/sample.pdf` Latest
-	`/api/document/sample.pdf?revision=0` First version




**	Using Postman**

1.	Register and login
2.	Set `Authorization: Bearer {token}` in headers
3.	Use form-data to upload a file under key `file`




**	AI Tools Used**
       
ChatGPT For
-	Structuring API routes
-	Writing secure file upload logic
-	Swagger setup


**	Author**
                   Dipali Devkar*
                  Jobfolio.dip@gmail.com



 

 



 



 






