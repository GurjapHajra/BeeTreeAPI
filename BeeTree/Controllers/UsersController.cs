using BeeTree.Data;
using BeeTree.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BeeTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly BeetreeAPIDbContext dbContext;

        public UsersController(BeetreeAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<User> Get()
        {
            return dbContext.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
           User user = dbContext.Users.Find(1);

            return user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User value)
        {

            User t = new User();

            t.firstName =  value.firstName;
            t.lastName = value.lastName;
            t.Email = value.Email;
            t.Gender = value.Gender;
            t.Premium = value.Premium;

            Random rnd = new Random();

            int indentity = rnd.Next(1000000000,2000000000);

            while (dbContext.Users.Find(indentity) != null)
            {
                indentity = rnd.Next(1000000000, 2000000000);
            }

            t.Id = indentity;

            dbContext.Users.Add(t);
            dbContext.SaveChanges();

            return indentity;

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JsonDocument value)
        {

            User u = dbContext.Users.Find(id);

            JsonElement root = value.RootElement;
            
            if (root.TryGetProperty("firstName", out JsonElement gradeElement))
            {
                u.firstName = root.GetProperty("firstName").ToString();
            }
            if (root.TryGetProperty("lastName", out gradeElement))
            {
                u.lastName = root.GetProperty("lastName").ToString();
            }
            if (root.TryGetProperty("Email", out gradeElement))
            {
                u.Email = root.GetProperty("Email").ToString();
            }
            if (root.TryGetProperty("Gender", out gradeElement))
            {
                u.Gender = root.GetProperty("Gender").ToString();
            }
            if (root.TryGetProperty("Premium", out gradeElement))
            {
                u.Premium = root.GetProperty("Premium").ToString() == "True";
            }

            dbContext.Users.Update(u);
            dbContext.SaveChanges();

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dbContext.Users.Remove(dbContext.Users.Find(id));
            dbContext.SaveChanges(true);
        }

        [HttpGet("count")]
        public int Getcount()
        {
            return dbContext.Users.Count();
        }
    }
}
