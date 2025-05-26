# SecureDocStorage
#  Secure Document Storage System

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

Application will be available at:
🔗 https://localhost:5001
Download Latest Version
Endpoint: GET /files/sample.pdf
Returns: Latest version of sample.pdf

📜 Download Specific Version
Endpoint: GET /files/sample.pdf?revision=0
Returns: First uploaded version of sample.pdf

##Demo Video

AI Tools Used
ChatGPT 4 – Design, architecture, code assistance
GitHub Copilot – Code auto-suggestions



