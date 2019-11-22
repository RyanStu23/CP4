using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class RentalsController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        public static List<Client> lstClient = new List<Client>(); 

        public static string Usedd;
        public static string Neww;
        public static string Instrument;
        public static string bottle;
        public static int instID;

        public static int iCount;

        // GET: Rentals
        public ActionResult Rentals()
        {
            return View();
        }

        public ActionResult Trumpet()
        {
            Instrument = "Trumpet";
            Usedd = "25";
            Neww = "55";
            instID = 1;
            ViewBag.Used = Usedd;
            ViewBag.New = Neww;
            ViewBag.Instrument = Instrument;
            ViewBag.ID = instID;
            return View("Instrument");
        }
        public ActionResult Trombone()
        {
            Instrument = "Trombone";
            Usedd = "35";
            Neww = "60";
            instID = 3;
            ViewBag.Instrument = Instrument;
            ViewBag.ID = instID;
            return View("Instrument");
        }
        public ActionResult Tuba()
        {
            Instrument = "Tuba";
            Usedd = "50";
            Neww = "70";
            instID = 5;
            ViewBag.Instrument = Instrument;
            ViewBag.ID = instID;
            return View("Instrument");
        }
        public ActionResult Flute()
        {
            Instrument = "Flute";
            Usedd = "25";
            Neww = "40";
            instID = 7;
            ViewBag.Instrument = Instrument;
            ViewBag.ID = instID;
            return View("Instrument");
        }
        public ActionResult Clarinet()
        {
            Instrument = "Clarinet";
            Usedd = "27";
            Neww = "35";
            instID = 9;
            ViewBag.Instrument = Instrument;
            ViewBag.ID = instID;
            return View("Instrument");
        }
        public ActionResult Saxophone()
        {
            Instrument = "Saxophone";
            Usedd = "30";
            Neww = "42";
            instID = 11;
            ViewBag.Instrument = Instrument;
            ViewBag.ID = instID;
            return View("Instrument");
        }

        public ActionResult New(int ID)
        {
            bottle = "To rent a new " + Instrument + " will cost $";
            ViewBag.New = bottle + Neww;
            return View("NewClientInstrument");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Include = "clientID, firstName, lastName, address, city, state, zip, phone, email")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                client.clientID = lstClient.Count + 1;

                db.Clients.Add(client);
                db.SaveChanges();

                //lookup instrument
                Instrument instrument = new Models.Instrument();
                instrument.instrumentDesc = Instrument;
                instrument.instrumentType = "New";
                instrument.price = Neww;
                instrument.clientID = Convert.ToInt32(client.clientID);
                db.Instruments.Add(instrument);

                //Save Changes
                db.SaveChanges();

                return RedirectToAction("Summary", new { clientID = client.clientID, instrumentID = instrument.instrumentID });

            }

            return View();
        }


        public ActionResult Used(int ID)
        {
            bottle = "To rent a new " + Instrument + " will cost $";
            ViewBag.New = bottle + Usedd;
            return View("UsedClientInstrument");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Used([Bind(Include = "clientID, firstName, lastName, address, city, state, zip, phone, email")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                client.clientID = lstClient.Count + 1;

                db.Clients.Add(client);
                db.SaveChanges();

                //lookup instrument
                Instrument instrument = new Models.Instrument();
                instrument.instrumentDesc = Instrument;
                instrument.instrumentType = "Used";
                instrument.price = Usedd;
                instrument.clientID = Convert.ToInt32(client.clientID);
                db.Instruments.Add(instrument);

                //Save Changes
                db.SaveChanges();

                return RedirectToAction("Summary", new { clientID = client.clientID, instrumentID = instrument.instrumentID });

            }

            return View();
        }

        public ActionResult Summary(int clientID, int instrumentID)
        {
            Client client = db.Clients.Find(clientID);
            Instrument instrument = db.Instruments.Find(instrumentID);

            int iPrice = Convert.ToInt32(instrument.price);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;
            ViewBag.TotalPrice = iPrice * 18;

            return View();
        }
    }
}