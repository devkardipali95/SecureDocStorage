
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureDocStorage.Data;
using SecureDocStorage.Models;
using System.Security.Claims;

namespace SecureDocStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly AppDbContext db;
        public DocumentController(AppDbContext db)
        {
            this.db = db;
        }
        [Authorize]
        [HttpPost("upload")]
        public async Task<IActionResult> Upload( IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No file uploaded.");

                var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdStr, out int userId))
                    return Unauthorized();

                // Sanitize filename to avoid path issues
                var sanitizedFileName = Path.GetFileName(file.FileName);

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();

                // Get existing document with versions
                var document = await db.Documents
                    .Include(d => d.Versions)
                    .FirstOrDefaultAsync(d => d.UserId == userId && d.FileName == sanitizedFileName);

                if (document == null)
                {
                    document = new Document
                    {
                        FileName = sanitizedFileName,
                        UserId = userId,
                        Versions = new List<DocumentVersion>()
                    };

                    db.Documents.Add(document);
                    await db.SaveChangesAsync(); // Save to generate document.Id
                }

                var nextRevision = document.Versions?.Count ?? 0;

                var newVersion = new DocumentVersion
                {
                    DocumentId = document.Id,
                    RevisionNumber = nextRevision,
                    FileContent = fileBytes,
                    UploadedAt = DateTime.UtcNow
                };

                db.DocumentVersions.Add(newVersion);
                await db.SaveChangesAsync();

                return Ok(new
                {
                    message = "File uploaded successfully.",
                    document = document.FileName,
                    version = newVersion.RevisionNumber
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpGet("/files/{fileName}")]
        public async Task<IActionResult> Download(string fileName, [FromQuery] int? revision = null)
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdStr, out int userId))
                return Unauthorized();

            var sanitizedFileName = Path.GetFileName(fileName);

            var document = await db.Documents
                .Include(d => d.Versions)
                .FirstOrDefaultAsync(d => d.UserId == userId && d.FileName == sanitizedFileName);

            if (document == null)
                return NotFound("Document not found.");

            DocumentVersion versionToReturn;

            if (revision.HasValue)
            {
                versionToReturn = document.Versions.FirstOrDefault(v => v.RevisionNumber == revision.Value);
                if (versionToReturn == null)
                    return NotFound($"Revision {revision.Value} not found.");
            }
            else
            {
                versionToReturn = document.Versions.OrderByDescending(v => v.RevisionNumber).FirstOrDefault();
                if (versionToReturn == null)
                    return NotFound("No versions found for this document.");
            }

            return File(versionToReturn.FileContent, "application/octet-stream", document.FileName);
        }


    }
}
