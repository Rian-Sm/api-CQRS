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

        [HttpGet]
        public async Task<IActionResult> GetClients(){
            return CustomResponse(await _ClientService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id){
            return CustomResponse(await _ClientService.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> PutClient(ClientViewModel clientViewModel){
            return CustomResponse(await _ClientService.Update(clientViewModel));
        }

        [HttpDelete("{id}")]
        public  async Task<IActionResult> DeleteClient(Guid id){
            return CustomResponse(await _ClientService.Remove(id));
        }
    }
}