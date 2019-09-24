using CarInsuranceQuotes.Models;
using CarInsuranceQuotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuotes.Controllers
{
    public class FinalController : Controller
    {
        [HttpPost]
        public ActionResult QuoteCal(QuotePar quote)
        {
            decimal qTotal = 50;
            double age = 0;
            //
            TimeSpan aget = DateTime.Now - quote.dateBirth;
            age = aget.TotalDays / 365;
            //
            if (age < 18) qTotal += 100;
            else if (age < 25 || age > 100) qTotal += 25;
            //
            if (quote.carYear < 2000) qTotal += 25;
            else if (quote.carYear > 2015) qTotal += 25;
            //
            if (quote.carMake.ToLower() == "porsche")
            {
                qTotal += 25;
                if (quote.carModel.ToLower() == "carrera") qTotal += 25;
            }
            //
            qTotal = qTotal + (quote.speedTickets * 10);
            //
            if (quote.diu == "Y") qTotal = Percent(qTotal, 25);
            //
            if (quote.cover == "1") qTotal = Percent(qTotal, 50);
            //
            quote.totalQuote = qTotal;
            //
            using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
            {
                var dbQuote = new Quote();
                dbQuote.LastName = quote.lastName;
                dbQuote.FirstName = quote.firstName;
                dbQuote.EmailAddress = quote.emailAddress;
                dbQuote.DateBirth = quote.dateBirth;
                dbQuote.CarYear = quote.carYear;
                dbQuote.CarModel = quote.carModel;
                dbQuote.CarMake = quote.carMake;
                if (quote.diu == "Y") dbQuote.DUI = true;
                else dbQuote.DUI = false;
                dbQuote.SpeedTickets = quote.speedTickets;
                if (quote.cover == "1") dbQuote.FullCoverage = true;
                else dbQuote.FullCoverage = false;
                dbQuote.QuoteDate = DateTime.Now;
                dbQuote.QuoteAmount = qTotal;
                //
                db.Quotes.Add(dbQuote);
                db.SaveChanges();
                //
            }
            //
            return View(quote);
        }
        //
        public static decimal Percent(decimal number, int percent)
        {
            number = number + ((number * percent) / 100);
            return number;
        }
        //
        
        // GET: Final
        public ActionResult Index()
        {
            return View();
        }
    }
}