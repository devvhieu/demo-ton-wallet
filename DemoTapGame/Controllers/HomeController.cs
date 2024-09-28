using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Hosting;
using System.Web.Mvc;

namespace DemoTapGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SaveAddress(string address)
        {
            // Tạo object từ Id được truyền vào
            var data = new WalletDataModel
            {
                Address = address
            };

            // Chuyển đổi object thành JSON
            string jsonData = JsonConvert.SerializeObject(data);

            // Đường dẫn đến file JSON (ví dụ: ~/App_Data/data.json)
            string filePath = HostingEnvironment.MapPath("~/App_Data/data.json");

            // Ghi JSON vào file
            System.IO.File.WriteAllText(filePath, jsonData);

            return RedirectToAction("Index");
        }
    }

    public class WalletDataModel
    {
        public string Address { get; set; }
    }
}