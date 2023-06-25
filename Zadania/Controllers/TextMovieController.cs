using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Tar;
using Zadania.Data;
using Zadania.Helpers.SRTProcessor;
using Zadania.Models;

namespace Zadania.Controllers
{
    public class TextMovieController : Controller
    {
        IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<TextMovieController> _logger;
        private readonly SubtitleProcessor _subtitleProcessor;
        private readonly DatabaseContext _context;
        public TextMovieController(
            IWebHostEnvironment hostingEnvironment, 
            DatabaseContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _subtitleProcessor = new SubtitleProcessor();
        }
        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            ReturnMovieFilesVM resoult = new ReturnMovieFilesVM();
            resoult.IsFirst = true;

            var movieTexts = await _context.MovieTexts.ToListAsync();

            if (movieTexts != null && movieTexts.Count() > 0)
            {
                resoult.MovieTextsList = movieTexts;
              
            }
          
            return View(resoult);
        }

        // GET: /File/Upload
       

        // POST: /File/Upload
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var isOk = false;

            string filePathSaveDB = string.Empty;
            string filePathSaveOutput1DB = string.Empty;
            string filePathSaveOutput2DB = string.Empty;
            string fileName = string.Empty;

            ReturnMovieFilesVM resoult = new ReturnMovieFilesVM();
            if (file != null && file.Length > 0)
            {
                try
                {
                    fileName = file.FileName;


                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "fileOrigingl", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }



                    var fileNameOutput1 = "Output1-" + fileName;
                    var fileNameOutput2 = "Output2-" + fileName;
                    string filePathOutput1 = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileNameOutput1);
                    string filePathOutput2 = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileNameOutput2);

                    filePathSaveDB = Path.Combine("fileOrigingl", fileName);
                    filePathSaveOutput1DB = Path.Combine("files", fileNameOutput1);
                    filePathSaveOutput2DB = Path.Combine("files", fileNameOutput2);

                    TimeSpan timeShift = new TimeSpan(00, 00, 00, 05, 880); // 5 sekund i 880 milisekund
                                                                            // outputFilePath = filePathOutput;
                                                                            // TimeSpan timeShift = TimeSpan.FromSeconds(5.880);


                    _subtitleProcessor.ProcessSubtitles(filePath, filePathOutput1, filePathOutput2, timeShift);

                    MovieText movieText = new MovieText();
                    movieText.Name = fileName;
                    movieText.TextOriginalUrl = filePathSaveDB;
                    movieText.TextUpdate1Url = filePathSaveOutput1DB;
                    movieText.TextUpdate2Url = filePathSaveOutput2DB;
                    movieText.DateCreated = DateTime.Now;
                    _context.MovieTexts.Add(movieText);
                    await _context.SaveChangesAsync();

                    ViewBag.Message = "Plik został wgrany i podzielony i wszystkie pliki zostały zapisane na nysku i w bazie danych.";
                    isOk = true;

                    resoult.Message = "Plik został wgrany i podzielony i wszystkie pliki zostały zapisane na nysku i w bazie danych.";
                    resoult.IsOk = isOk;
                    var movieTexts = await _context.MovieTexts.ToListAsync();

                    if (movieTexts != null && movieTexts.Count() > 0)
                    {
                        resoult.MovieTextsList = movieTexts;
                        resoult.MovieText = movieText;
                    }
                }
                catch (Exception ex)
                {
                    isOk = false;
                    ViewBag.Message = $"Wystąpił błąd: {ex.Message}";
                    resoult.Message = $"Wystąpił błąd: {ex.Message}";
                    resoult.IsOk = isOk;
                    resoult.IsError = true;
                }
            }
            else
            {
                try 
                {
                    TimeSpan timeShift = new TimeSpan(00, 00, 00, 05, 880); // 5 sekund i 880 milisekund
                    var fileNameDysk = "napisy-do-filmu.srt";
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "fileOrigingl", fileNameDysk);

                    var fileNameOutput1 = "Output1-" + fileNameDysk;
                    var fileNameOutput2 = "Output2-" + fileNameDysk;
                    string filePathOutput1 = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileNameOutput1);
                    string filePathOutput2 = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileNameOutput2);


                    filePathSaveDB = Path.Combine("fileOrygingl", fileNameDysk);
                    filePathSaveOutput1DB = Path.Combine("files", fileNameOutput1);
                    filePathSaveOutput2DB = Path.Combine("files", fileNameOutput2);


                    _subtitleProcessor.ProcessSubtitles(filePath, filePathOutput1, filePathOutput2, timeShift);
                    ViewBag.Message = "Plik został pobrany z dysku podzielony i wszystkie pliki zostały zapisane na nysku i w bazie danych.";

                    MovieText movieText = new MovieText();
                    movieText.Name = fileName;
                    movieText.TextOriginalUrl = filePathSaveDB;
                    movieText.TextUpdate1Url = filePathSaveOutput1DB;
                    movieText.TextUpdate2Url = filePathSaveOutput2DB;
                    movieText.DateCreated = DateTime.Now;
                    _context.MovieTexts.Add(movieText);
                    await _context.SaveChangesAsync();


                    isOk = true;
                    resoult.Message = "Plik został pobrany z dysku podzielony i wszystkie pliki zostały zapisane na nysku i w bazie danych.";
                    resoult.IsOk = isOk;

                    var movieTexts = await _context.MovieTexts.ToListAsync();

                    if (movieTexts != null && movieTexts.Count() > 0) 
                    {
                        resoult.MovieTextsList = movieTexts;
                        resoult.MovieText = movieText;
                    }


                }
                catch(Exception ex) 
                {
                    isOk = false;
                    ViewBag.Message = $"Wystąpił błąd: {ex.Message}";
                    resoult.Message = $"Wystąpił błąd: {ex.Message}";
                    resoult.IsOk = isOk;
                    resoult.IsError = true;
                }
                

                
            }

            return View(resoult);


        }


        public async Task<IActionResult> GetFile(int id, int which) 
        {
            var movieFile = await _context.MovieTexts.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (movieFile != null)
            {
                if (which == 1)
                {
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, movieFile.TextOriginalUrl);
                    if (System.IO.File.Exists(filePath))
                    {
                        string fileContent = System.IO.File.ReadAllText(filePath);
                        return Content(fileContent, "text/plain");
                    }
                    else
                    {
                        // return NotFound();
                        return RedirectToAction("Index");
                    }
                }
               else if (which == 2)
                {
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, movieFile.TextUpdate1Url);
                    if (System.IO.File.Exists(filePath))
                    {
                        string fileContent = System.IO.File.ReadAllText(filePath);
                        return Content(fileContent, "text/plain");
                    }
                    else
                    {
                        // return NotFound();
                        return RedirectToAction("Index");
                    }
                }
               else if (which == 3)
                {
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, movieFile.TextUpdate2Url);
                    if (System.IO.File.Exists(filePath))
                    {
                        string fileContent = System.IO.File.ReadAllText(filePath);
                        return Content(fileContent, "text/plain");
                    }
                    else
                    {
                        // return NotFound();
                        return RedirectToAction("Index");
                    }
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }


    }
}
