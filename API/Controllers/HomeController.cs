using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.IO;
using HasarTespitiMVC.Models;

namespace HasarTespitiMVC.Controllers
{
    public class HomeController : Controller
    {
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

                results = parsed.results ?? new();
                LastImageBase64 = parsed.image_base64;
                ViewBag.ImageBase64 = LastImageBase64;

                foreach (var item in results)
                {
                    item.islem = item.iou > 0.8 ? "deðiþim" : "onarým";
                    item.tamir_suresi = item.iou > 0.8 ? 0 : Math.Round(RandomDouble(0.5, 1.0), 2);
                    item.soktak_suresi = item.iou > 0.8 ? 0.84 : 0;
                    item.boya_suresi = item.iou > 0.5 ? 2.59 : 0.5;
                    item.yogunluk = item.iou > 0.9 ? "100%" : $"{(int)(item.iou * 100)}%";
                    item.eminlik = $"{(int)(item.iou * 100)}%";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Hata = "Hata oluþtu: " + ex.Message;
            }

            return View("Index", results);
        }

        private static double RandomDouble(double min, double max)
        {
            return new Random().NextDouble() * (max - min) + min;
        }
    }
}
