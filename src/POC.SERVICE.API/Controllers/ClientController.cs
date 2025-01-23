using Microsoft.AspNetCore.Mvc;
using POC.SERVICE.API.Interfaces;
using POC.Domain.ViewModel;


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


            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ClientService.Register(clientViewModel));
        }
    }
}