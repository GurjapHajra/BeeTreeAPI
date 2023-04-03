using BeeTree.Data;
using Microsoft.AspNetCore.Mvc;
using BeeTree.Models;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeeTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {

        private readonly BeetreeAPIDbContext dbContext;

        public UserDataController(BeetreeAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<UserData>
        [HttpGet]
        public List<UserData> Get()
        {
            return dbContext.UserData.ToList();
        }

        // GET api/<UserData>/5
        [HttpGet("{id}")]
        public UserData Get(int id)
        {
            return dbContext.UserData.Find(id);
        }

        // POST api/<UserData>
        [HttpPost]
        public void Post([FromBody] UserData value)
        {
            dbContext.UserData.Add(value);
            dbContext.SaveChanges();
        }

        // PUT api/<UserData>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonDocument value)
        {

            UserData u = dbContext.UserData.Find(id);
            JsonElement root = value.RootElement;

            if (root.TryGetProperty("instagram", out JsonElement gradeElement))
            {
                u.instagram = root.GetProperty("instagram").ToString();
            }
            if (root.TryGetProperty("Twitter", out gradeElement))
            {
                u.Twitter = root.GetProperty("Twitter").ToString();
            }
            if (root.TryGetProperty("LinkedIn", out gradeElement))
            {
                u.LinkedIn = root.GetProperty("LinkedIn").ToString();
            }
            if (root.TryGetProperty("Facebook", out gradeElement))
            {
                u.Facebook = root.GetProperty("Facebook").ToString();
            }
            if (root.TryGetProperty("Other", out gradeElement))
            {
                u.Other = root.GetProperty("Other").ToString();
            }

            dbContext.UserData.Update(u);
            dbContext.SaveChanges();

        }

        // DELETE api/<UserData>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            dbContext.UserData.Remove(dbContext.UserData.Find(id));
            dbContext.SaveChanges();

        }

        [HttpGet("count")]
        public int Getcount()
        {
            return dbContext.UserData.Count();
        }

    }
}
