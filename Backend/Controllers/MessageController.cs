using Backend.Logic;
using Backend.Model;
using Backend.Services;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessagLogic logic; 
        IHubContext<SignalRHub> hub;
        public MessageController(IMessagLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<MessageController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<MessageController>/5
        [HttpGet]
        public async Task Get()
        {
           
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post([FromBody] MessageModel message)
        {

            this.logic.Add(message);
            
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
