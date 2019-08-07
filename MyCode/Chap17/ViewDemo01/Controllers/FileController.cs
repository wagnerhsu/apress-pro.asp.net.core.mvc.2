using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ViewDemo01.Controllers
{
    public class FileController : Controller
    {
        private IHostingEnvironment _env;
        private ILogger<FileController> _logger;

        public FileController(IHostingEnvironment env, ILogger<FileController> logger)
        {
            _env = env;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string path = Path.Combine(_env.ContentRootPath, "wwwroot", "css");
            ViewBag.Files = Directory.GetFiles(path).Select(x => Path.GetFileName(x));
            return View();
        }

        [AllowAnonymous]
        public IActionResult Download(string fileName)
        {
            if (fileName == null)
            {
                return Content("filename not found");
            }

            string path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\css", fileName);
            FileStream file = new FileStream(path, FileMode.Open);
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            file.Close();
            ms.Position = 0;
            return File(ms, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            return GetMimeTypes()[Path.GetExtension(path).ToLowerInvariant()];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>()
            {
                {".css","text/plain" },
                { ".txt", "text/plain" },
                { ".pdf", "application/pdf" },
                { ".doc", "application/vnd.ms-word" },
                { ".docx", "application/vnd.ms-word" },
                { ".xls", "application/vnd.ms-excel" },
                { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                { ".png", "image/png" },
                { ".jpg", "image/jpeg" },
                { ".jpeg", "image/jpeg" },
                { ".gif", "image/gif" },
                { ".csv", "text/csv" },
                { ".zip", "application/x-zip-compressed" },
                { ".xml", "text/xml" }
            };
        }

        public VirtualFileResult VirtualFileDemo()
        {
            return File("~/css/site.css", "text/css");
        }

        [HttpPost]
        public ViewResult UploadFile(IFormFile file)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    memoryStream.Position = (long)0;
                    byte[] buffer = new byte[memoryStream.Length];
                    memoryStream.Read(buffer, 0, buffer.Length);
                    _logger.LogInformation($"Write to {file.FileName}");
                    System.IO.File.WriteAllBytes(file.FileName, buffer);
                    return View("Index");
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                _logger.LogError(exception.ToString(), Array.Empty<object>());
                return View("Index");
            }
        }
    }
}