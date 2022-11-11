using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace Web_Transport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KompanijaController : ControllerBase
    {
        public Context Context { get; set; }

        public KompanijaController(Context context)
        {
            Context = context;
        }
    }
}
