# SecureDocStorage

A version-controlled document storage API built with ASP.NET Core web api and Entity Framework. Supports multiple revisions per file and intuitive retrieval through RESTful endpoints.

---

##  Features

- Upload documents with automatic versioning.
-  Retrieve the latest or any historical version.
-  Simple API interface.
-  Easily extensible for cloud storage (e.g., Azure Blob).

---

## 🛠️ Setup Instructions

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server 
 Postman or Swagger UI for testing
-installation
microsoft.entityframeworkcore.tools
microsoft.entityframeworkcore.sqlserver
microsoft.aspnetcore.authentication.jwtbearer
### Clone and Run

```bash
git clone https://github.com/devkardipali95/SecureDocStorage.git
cd SecureDocumentStorage
update-database
dotnet run
## Testing Instructions

Application will be available at:
Access API at:
https://localhost:5001/api/
🔗 https://localhost:5001
1. User Registration & Login
➕ Register a new user
POST /api/auth/register
Body (JSON):

{
  "username": "john",
  "password": "StrongP@ssword123"
}
Expected:
 200 OK — "User registered successfully."
 400 Bad Request — "User already exists."

🔑 Login
POST /api/auth/login
Body (JSON):


{
  "username": "john",
  "password": "StrongP@ssword123"
}
Expected:
 200 OK


{
  "token": "<JWT-TOKEN>"
}
Copy the token and set it in Postman:


Authorization: Bearer <JWT-TOKEN>
 2. Upload Document
POST /api/document/upload
Headers:


Authorization: Bearer <JWT-TOKEN>
Content-Type: multipart/form-data
Body (form-data):


Key: file
Value: (choose any file)
Expected:
✅ 200 O
{
  "message": "File uploaded successfully.",
  "document": "filename.ext",
  "version": 0
}
Re-uploading the same file gives version: 1, 2, etc.

 3. Download Document
 Latest Version
GET /files/filename.ext
Header:
Authorization: Bearer <JWT-TOKEN>

Returns file stream if found.

 Specific Revision
GET /files/filename.ext?revision=1
Returns the specified revision if it exists.


Download Latest Version
Endpoint: GET /files/sample.pdf
Returns: Latest version of sample.pdf

 Download Specific Version
Endpoint: GET /files/sample.pdf?revision=0
Returns: First uploaded version of sample.pdf


AI Tools Used
ChatGPT 4 – Design, architecture, code assistance
GitHub Copilot – Code auto-suggestions



