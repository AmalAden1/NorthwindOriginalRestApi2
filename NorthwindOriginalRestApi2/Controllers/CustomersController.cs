using Microsoft.AspNetCore.Http;
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
            var asiakkaat = db.Customers.ToList();
            return Ok(asiakkaat);
        }
                                        

    }
}
