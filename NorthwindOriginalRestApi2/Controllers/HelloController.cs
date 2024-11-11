using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindOriginalRestApi2.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class HelloController : ControllerBase
    {
        // Luodaa Ensimmäinen  metodi, jonka yläpuolelle tulee [Http Get] ohjautuvat vaan get tyyppiset metodit
        // näkyvyyn määreltään public ja paluutyyppi String eli teksti/ merkkijono
        // ensimmäinen metodi  get metodin palauttaa  Hello Word 

        [HttpGet] 
        public string Get()
        {
            return ("Hei Maailma");
        }
    }
}
