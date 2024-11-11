﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindOriginalRestApi2.Models;

namespace NorthwindOriginalRestApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        // Alustetaan tietokantayhteys NorwindOriginalContextiin.

        NorthwindOriginalContext db = new NorthwindOriginalContext();
        // NorthwindOriginalContext db = new(); sama kuin yllä oleva mutta lyhyt versio.


        // HttpGet -metodi ja public - ja paluu tyyppi on ActionResult joka ei ota yhtää paratyyppiä

        [HttpGet] // Haetaan kaikki asiakkaat Customer taulukosta ja listaksi.
        public ActionResult GetAllCustomers()
        {
            try
            {
                var asiakkaat = db.Customers.ToList();
                return Ok(asiakkaat);
            }
            catch (Exception e) 
            { 
            return BadRequest("Tapahtui virhe. Lues lisää : " + e.InnerException);
            }
            // tehty try -catch ja Exception ex. innerexception vieti ketju 
        }




        [HttpGet("{id}")] // haetaan yksi asiakas id perusteella
        //[Route("{ id }")] url osoitepolun  laitettava parametri määrittely (vapaasti määriteltävä mikä lisätää metodin parametriksi)
        public ActionResult GetOneCustomersById(string id)
        {
            try
            {
                var asiakas = db.Customers.Find(id);
                if (asiakas != null) // ei ole null -> !=null 
                {
                    return Ok(asiakas);
                }

                else
                {
                    //  return BadRequest("Asikasta id:llä" + id + " ei löydy");
                    return NotFound($"Asikasta id:llä {id} ei löydy");// string interpolation $ merkillä 
                }
            }
            catch (Exception e)
            {
                return BadRequest("On tapahtunut virhe. Lue lisää:" + e.InnerException);
            }
        }


        // Uuden Asiakkaan lisääminen tauluun  Post fitterillä,
        [HttpPost]
        public ActionResult AddNew([FromBody] Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return Ok($"Lisättiin uusi asikas {customer.CompanyName} from {customer.City}");

            }
            catch (Exception e)
            {
                return BadRequest("Tapahtunut virhe. Lue Lisää: " + e.InnerException);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(string id)
        {
            try
            {
                var asiakas = (db.Customers.Find(id));
                if (asiakas != null) // jos id.llä löytyy asiakas

                {
                    db.Customers.Remove(asiakas);
                    db.SaveChanges();
                    return Ok("Asiakas id.llä poistettiin " + asiakas.CompanyName );

                }
                else 
                {
                    return NotFound("Asiakas id.llä " + id + " ei löydy");
                }

            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException);
            }

        }
    }
}
