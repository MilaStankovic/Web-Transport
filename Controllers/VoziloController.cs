using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Web_Transport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoziloController : ControllerBase
    {
        public Context Context { get; set; }

        public VoziloController(Context context)
        {
            Context = context;
        }

        [HttpGet]
        [Route("VratiVozila/{zapremina}/{tezina}/{cenaOd}/{cenaDo}")]
        public async Task<ActionResult> Vozila(int zapremina, int tezina, int cenaOd, int cenaDo)
        {
            try
            {
                var vozila = await Context.Vozila
                    .Where(p => p.Zapremina>=zapremina && p.TezinaPaketa>=tezina && p.Cena>=cenaOd && p.Cena<=cenaDo)
                    .Include(p => p.Kompanija)
                    .ToListAsync();
                return Ok(vozila);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("RezervisiVozilo/{kompanijaID}/{voziloID}")]
        public async Task<ActionResult> RezervisiVozilo(int kompanijaID, int voziloID)
        {
            try
            {
                var kompanija = await Context.Kompanija.FindAsync(kompanijaID);
                if(kompanija == null) {
                    return BadRequest("Kompanija ne postoji.");
                }

                var vozilo = await Context.Vozila.FindAsync(voziloID);
                if(vozilo == null) {
                    return BadRequest("Vozilo ne postoji.");
                }
                
                var novaIsporuka = new Isporuka
                {
                    Kompanija = kompanija,
                    Prevoz = vozilo
                };
                var isporuka = Context.Isporuke.Add(novaIsporuka);

                await Context.SaveChangesAsync();
                
                return Ok("Vozilo uspesno rezervisano");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
