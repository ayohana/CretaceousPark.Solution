using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CretaceousPark.Models;

namespace CretaceousPark.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private CretaceousParkContext _db;

    public AnimalsController(CretaceousParkContext db)
    {
      _db = db;
    }

    // GET api/animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> Get()
    {
      return _db.Animals.ToList();
    }
    // Our GET route needs to return an ActionResult of type <IEnumerable<Animal>>. In our web applications, we didn't need to specify a type because we were always returning a view.

    // POST api/animals
    [HttpPost]
    public void Post([FromBody] Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
    }
    // We need to include the [FromBody] annotation so that we can actually put the details of a new animal in the body of a POST API call.

    // GET api/animals/5
    [HttpGet("{id}")]
    public ActionResult<Animal> Get(int id)
    {
      return _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
    }

    // PUT api/animals/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Animal animal)
    {
        animal.AnimalId = id;
        _db.Entry(animal).State = EntityState.Modified;
        _db.SaveChanges();
    }
    // PUT is like POST in that it makes a change to the server. However, PUT changes existing information while POST creates new information. Notice we use an [HttpPut] annotation. We use the [FromBody] annotation just as we did with our POST route because we will need to specify the changes we want to make in the body of the API call.

     // DELETE api/animals/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Animals.Remove(animalToDelete);
      _db.SaveChanges();
    }

    // Note that we were able to have all CRUD functionality with only two URLs:
    // http://localhost:5000/api/animals
    // and
    // http://localhost:5000/api/animals/1
    // The benefits of RESTful standards become more readily apparent with an API. Developers don't need to search through documentation in order to surmise the correct URLs for an API. While a user of a web application might not notice that a URL in the browser is RESTful, a developer using an API certainly will notice whether the URL is RESTful and easy to work with. We should always keep the names of our endpoints as RESTful as possible.
  }
}