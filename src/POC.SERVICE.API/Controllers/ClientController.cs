using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POC.SERVICE.API.Interfaces;
using POC.SERVICE.API.ViewModel;

namespace POC.SERVICE.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ApiController
    {
        private readonly IClientService _ClientService;

        public ClientController(IClientService clientService){
            _ClientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientViewModel clientViewModel){

            return CustomResponse(clientViewModel);
        }
    }
}