using Backend.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private static List<MessageModel> messages= new List<MessageModel>();
        private static List<StreamWriter> clients = new List<StreamWriter>();
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
            Response.ContentType = "text/event-stream";
            var client = new StreamWriter(Response.Body);
            clients.Add(client);
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post([FromBody] MessageModel message)
        {
            message.Date=DateTime.Now;
            messages.Add(message);
            foreach (var client in clients)
            {
                Console.WriteLine($"New message from{message.Name} at {message.Date}: {message.Message}");
            }
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
