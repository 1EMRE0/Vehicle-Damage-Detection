using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }





        public static string LastImageBase64 = "";

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.ImageBase64 = LastImageBase64;
            return View(new List<DamageResult>());
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imageFile)
        {
            List<DamageResult> results = new();

            if (imageFile == null || imageFile.Length == 0)
            {
                ViewBag.Hata = "Lütfen bir dosya seçin.";
                ViewBag.ImageBase64 = LastImageBase64;
                return View("Index", results);
            }

            using var client = new HttpClient();
            using var form = new MultipartFormDataContent();
            var stream = imageFile.OpenReadStream();
            var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            form.Add(fileContent, "image", imageFile.FileName);

            try
            {
                var response = await client.PostAsync("http://localhost:5000/predict", form);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

               
                var parsed = JsonSerializer.Deserialize<PredictResponse>(responseString);

                if (parsed.status == "fail")
                {
                    ViewBag.Hata = parsed.message;
                    ViewBag.ImageBase64 = LastImageBase64;
                    return View("Index", new List<DamageResult>());
                }

                results = parsed.results ?? new();
                LastImageBase64 = parsed.image_base64;
                ViewBag.ImageBase64 = LastImageBase64;

                foreach (var item in results)
                {
                    item.damage_action = item.iou > 0.8 ? "deðiþim" : "onarým";
                    item.repair_duration = item.iou > 0.8 ? 0 : Math.Round(RandomDouble(0.5, 1.0), 2);
                    item.disassembly_time = item.iou > 0.8 ? 0.84 : 0;
                    item.paint_duration = item.iou > 0.5 ? 2.59 : 0.5;
                    item.severity = item.iou > 0.9 ? "100%" : $"{(int)(item.iou * 100)}%";
                    item.confidence_level = $"{(int)(item.iou * 100)}%";
                }
               
                

            }
            catch (Exception ex)
            {
                ViewBag.Hata = "Hata oluþtu: " + ex.Message;
            }

            if (results.Any())
            {
                _context.DamageResults.AddRange(results);
                _context.SaveChanges();
            }

            return View("Index", results);
        }

        private static double RandomDouble(double min, double max)
        {
            return new Random().NextDouble() * (max - min) + min;
        }
    }
}
