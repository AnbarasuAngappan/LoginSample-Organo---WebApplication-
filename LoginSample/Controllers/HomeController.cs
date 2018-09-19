using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LoginSample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace IdentitySample.Controllers
{
    public class SurveyDetails
    {
        private designdbEntities db = new designdbEntities();
        public void GetSurvey()
        {
            int x = 1800;
            foreach (var Mbuser in db.meter_details.ToList())
            {
               
                Graph graph = new Graph();
                
                var society = db.site_details.Where(s => s.SiD == Mbuser.SiD).FirstOrDefault();
                graph.SocietyID = society.Site_Name;
                var house = db.house_details.Where(s => s.HiD == Mbuser.HiD).FirstOrDefault();
                graph.HouseID = house.House_No;
                var meter = db.meter_masters.Where(s => s.MMiD == Mbuser.MMiD).FirstOrDefault();
                graph.MeterID = meter.Manufacturer;
                graph.IPAddress = Mbuser.IP_Address;
                graph.Port = Mbuser.Port;
                var utility = db.utility_tarrif_masters.Where(s => s.UiD == Mbuser.UiD).FirstOrDefault();
                graph.UtilityProvider = utility.Utility_Provider_Name;
                x += 200;              
                DateTime dtTest = new DateTime(2018, 4, 30, 0, 0, 0);
                int increment = 15;
               
                for (int i = 0; i < 96; i++)
                {
                    dtTest.ToString("HH:mm");
                    dtTest = dtTest.AddMinutes(increment);
                    if (dtTest >= DateTime.Parse("30-04-2018 00:00:00") && dtTest < DateTime.Parse("30-04-2018 06:00:00"))
                    {
                        x += 1;
                    }
                    else
                    {
                        x += 2;
                    }
                    
                    graph.Reading = x;
                    graph.Timestamp = dtTest.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    graph.Datetimestamp = dtTest;
                    db.Graphs.Add(graph);
                    db.SaveChanges();
                }
                               
            }

        }

        public void GetWaterReading()
        {
            int x = 1000;
            foreach (var watermeter in db.meter_details.Where(s => s.meter_master.Table_1.Name == "Water").ToList())
            {

                Water graph = new Water();

                var society = db.site_details.Where(s => s.SiD == watermeter.SiD).FirstOrDefault();
                graph.SocietyID = society.Site_Name;
                var house = db.house_details.Where(s => s.HiD == watermeter.HiD).FirstOrDefault();
                graph.HouseID = house.House_No;
                var meter = db.meter_masters.Where(s => s.MMiD == watermeter.MMiD).FirstOrDefault();
                graph.MeterID = meter.Manufacturer;
                graph.IPAddress = watermeter.IP_Address;
                graph.Port = watermeter.Port;
                var utility = db.utility_tarrif_masters.Where(s => s.UiD == watermeter.UiD).FirstOrDefault();
                graph.Utilityprovider = utility.Utility_Provider_Name;
                x += 200;
                DateTime dtTest = new DateTime(2018, 5, 8, 0, 0, 0);
                int increment = 15;

                for (int i = 0; i < 96; i++)
                {
                    dtTest.ToString("HH:mm");
                    dtTest = dtTest.AddMinutes(increment);
                    if (dtTest >= DateTime.Parse("08-05-2018 00:00:00") && dtTest < DateTime.Parse("08-05-2018 06:00:00"))
                    {
                        x += 1;
                    }
                    else if (dtTest >= DateTime.Parse("08-05-2018 06:00:00") && dtTest < DateTime.Parse("08-05-2018 12:00:00"))
                    {
                        x += 2;
                    }
                    else
                    {
                        x += 1;
                    }

                    graph.Reading = x;
                    graph.Timestamp = dtTest.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    graph.Datetimestamp = dtTest.ToString();
                    db.Waters.Add(graph);
                    db.SaveChanges();
                                        
                }

            }
        }

        public void GetGasReading()
        {
            int x = 1000;
            foreach (var watermeter in db.meter_details.Where(s => s.meter_master.Table_1.Name == "LPG").ToList())
            {

                GasReading graph = new GasReading();

                var society = db.site_details.Where(s => s.SiD == watermeter.SiD).FirstOrDefault();
                graph.SocietyID = society.Site_Name;
                var house = db.house_details.Where(s => s.HiD == watermeter.HiD).FirstOrDefault();
                graph.HouseID = house.House_No;
                var meter = db.meter_masters.Where(s => s.MMiD == watermeter.MMiD).FirstOrDefault();
                graph.MeterID = meter.Manufacturer;
                graph.IPAddress = watermeter.IP_Address;
                graph.Port = watermeter.Port;
                var utility = db.utility_tarrif_masters.Where(s => s.UiD == watermeter.UiD).FirstOrDefault();
                graph.Utilityprovider = utility.Utility_Provider_Name;
                x += 200;
                DateTime dtTest = new DateTime(2018, 5, 8, 0, 0, 0);
                int increment = 15;

                for (int i = 0; i < 96; i++)
                {
                    dtTest.ToString("HH:mm");
                    dtTest = dtTest.AddMinutes(increment);
                    if (dtTest >= DateTime.Parse("08-05-2018 00:00:00") && dtTest < DateTime.Parse("08-05-2018 06:00:00"))
                    {
                        x += 1;
                    }
                    else if (dtTest >= DateTime.Parse("08-05-2018 06:00:00") && dtTest < DateTime.Parse("08-05-2018 12:00:00"))
                    {
                        x += 2;
                    }
                    else if (dtTest >= DateTime.Parse("08-05-2018 12:00:00") && dtTest < DateTime.Parse("08-05-2018 18:00:00"))
                    {
                        x += 1;
                    }
                    else
                    {
                        x += 2;
                    }

                    graph.Reading = x;
                    graph.Timestamp = dtTest.ToString("h:mm tt", CultureInfo.InvariantCulture);
                    graph.Datetimestamp = dtTest.ToString();
                    db.GasReadings.Add(graph);
                    db.SaveChanges();

                }

            }
        }

    }

    public class HomeController : Controller
    {
        private designdbEntities db = new designdbEntities();

        public ActionResult Index()
        {
            var user = db.AspNetUsers.Where(u => u.UserName.Equals(User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            //var oth = new SurveyDetails();
            //oth.GetSurvey();
            //oth.GetWaterReading();
            //oth.GetGasReading();
            return View();
        }

        public JsonResult ChartDetails()
        {
            var result = (from tags in db.EMeter()

                          select new { tags.x, tags.y, tags.z }).ToList();

            //List<string> model = JsonConvert.DeserializeObject(result);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WaterReading()
        {
            var result = (from tags in db.WaterMeter()

                          select new { tags.x, tags.y}).ToList();

           
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GasReading()
        {
            var result = (from tags in db.GasMeter()

                          select new { tags.x, tags.y }).ToList();


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult ElectricityReading()
        {
            var viewModel= new ElectricityReadingViewModel();
            viewModel.GraphData = Graph();
            //viewModel.SearchFilter = new Class1();
            return View(viewModel);
           
            //ViewBag.HouseId = new SelectList(db.house_details, "HiD", "House_No");
            //DateTime start = DateTime.ParseExact("00:00", "HH:mm", null);
            //DateTime end = DateTime.ParseExact("23:55", "HH:mm", null);
            //int interval = 60;

            //List<string> lstTimeIntervals = new List<string>();

            //for (DateTime i = start; i <= end; i = i.AddMinutes(interval))
            //    lstTimeIntervals.Add(i.ToString("h:mm tt"));
            //ViewBag.time = new SelectList(lstTimeIntervals);
            //return View();

        }

        public IQueryable<Graph> Graph()
        {
            var date = db.Graphs.OrderByDescending(s => s.Datetimestamp).Take(1).Select(s => s.Datetimestamp).FirstOrDefault();
            var graph = db.Graphs.Where(s => (s.Datetimestamp.Hour) == date.Hour & DbFunctions.TruncateTime(s.Datetimestamp) == (date.Date)).AsQueryable();
            return graph.OrderBy(s => s.IPAddress);
        }
               

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetChartData(Class1 surveydata, string id)
        {
            TempData["id"] = id;
            TempData["From"] = surveydata.From;
            TempData["To"] = surveydata.To;
            Class1 survey = new Class1
            {
                From = surveydata.From,
                To = surveydata.To,
                houseId = id,
                time = surveydata.time
            };

            var result =
               db.Database.SqlQuery<Electricity_Result>(
             "exec dbo.[Electricity] @Fromdate,@Todate,@Villa,@time",
             new SqlParameter("@Fromdate", surveydata.From == null ? (DateTime)SqlDateTime.Null : surveydata.From),
             new SqlParameter("@Todate", surveydata.To == null ? (DateTime)SqlDateTime.Null : surveydata.To),
             new SqlParameter("@Villa", survey.houseId == null ? SqlString.Null : survey.houseId),
             new SqlParameter("@time", surveydata.time == null ? SqlString.Null : surveydata.time)

           ).ToList();

            TempData["result"] = result;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportToExcel()
        {

            var id = TempData.Peek("id").ToString();

            var dcuip = db.Graphs.Where(s => s.HouseID == id).Select(v => v.IPAddress).FirstOrDefault();
            var owner = db.Graphs.Where(s => s.HouseID == id).Select(v => v.OwnerName).FirstOrDefault();
            var serialno = db.Graphs.Where(s => s.HouseID == id).Select(v => v.SerialNo).FirstOrDefault().ToString();
            List<Electricity_Result> data = TempData.Peek("result") as List<Electricity_Result>;

            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Report");
            workSheet.Cells[2, 1].LoadFromText("Owner Name:");
            workSheet.Cells[3, 1].LoadFromText("Serial No:");
            workSheet.Cells[4, 1].LoadFromText("DCU IP No:");
            workSheet.Cells[2, 2].LoadFromText(owner);
            workSheet.Cells[3, 2].LoadFromText(serialno);
            workSheet.Cells[4, 2].LoadFromText(dcuip);
            workSheet.Cells[5, 1].LoadFromText(TempData.Peek("From").ToString());
            workSheet.Cells[5, 2].LoadFromText(TempData.Peek("To").ToString());
            workSheet.Cells[7, 1].LoadFromCollection(data, true);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Report.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

            return View();

        }

        public ActionResult ExportToPDF()
        {
            var id = TempData.Peek("id").ToString();
            var dcuip = db.Graphs.Where(s => s.HouseID == id).Select(v => v.IPAddress).FirstOrDefault();
            var owner = db.Graphs.Where(s => s.HouseID == id).Select(v => v.OwnerName).FirstOrDefault();
            var serialno = db.Graphs.Where(s => s.HouseID == id).Select(v => v.SerialNo).FirstOrDefault().ToString();
            List<Electricity_Result> data = TempData.Peek("result") as List<Electricity_Result>;

            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = data;
            GridView1.DataBind();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
              "attachment;filename=Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
           
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            Paragraph p1 = new Paragraph("Owner Name:" + owner);
            Paragraph p2 = new Paragraph("Serial No:"+ serialno);
            Paragraph p3 = new Paragraph("DCU IP No:" + dcuip);
            Paragraph p4 = new Paragraph(TempData.Peek("From").ToString()+ "  " + TempData.Peek("To").ToString());
            Paragraph p5 = new Paragraph(" ");
            pdfDoc.Add(p1);
            pdfDoc.Add(p2);
            pdfDoc.Add(p3);
            pdfDoc.Add(p4);
            pdfDoc.Add(p5);
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            return View();
        }

        public ActionResult Account()
        {

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
