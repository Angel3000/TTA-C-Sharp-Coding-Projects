using CarInsuranceQuotes.Models;
using CarInsuranceQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuotes.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
            {
                var dbQuotes = db.Quotes;
                var quoteList = new List<QuotePar>();
                //
                foreach (var qq in dbQuotes)
                {
                    var quoteVar = new QuotePar();
                    quoteVar.firstName = qq.FirstName;
                    quoteVar.lastName = qq.LastName;
                    quoteVar.dateBirth = Convert.ToDateTime(qq.DateBirth);
                    quoteVar.carYear = Convert.ToInt32(qq.CarYear);
                    quoteVar.carMake = qq.CarMake;
                    quoteVar.carModel = qq.CarModel;
                    if (Convert.ToBoolean(qq.DUI)) quoteVar.diu = "Y";
                    else quoteVar.diu = "N";
                    quoteVar.speedTickets = Convert.ToInt32(qq.SpeedTickets);
                    if (Convert.ToBoolean(qq.FullCoverage)) quoteVar.cover = "1";
                    else quoteVar.cover = "2";
                    quoteVar.emailAddress = qq.EmailAddress;
                    quoteVar.quoteDate = Convert.ToDateTime(qq.QuoteDate);
                    quoteVar.totalQuote = Convert.ToDecimal(qq.QuoteAmount);
                    //
                    quoteList.Add(quoteVar);
                    //
                }
                return View(quoteList);
            }
        }
    }
}