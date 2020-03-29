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
    public ActionResult<IEnumerable<Animal>> Get(string species, string gender, string name)
    {
      var query = _db.Animals.AsQueryable();
      // .AsQueryable() converts an IEnumerable to an IQueryable
      // We create a variable called query and then collect the list of all animals from our database and return it as a queryable LINQ object. We return a queryable object so that we can use LINQ methods to build onto the query before finalizing our selection.
      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }

      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }

      if (name != null)
      {
      query = query.Where(entry => entry.Name == name);
      }

      return query.ToList();
    }
    // Our GET route needs to return an ActionResult of type <IEnumerable<Animal>>. In our web applications, we didn't need to specify a type because we were always returning a view.
    // We've added a parameter to the method of type string that we've called species. The naming here is important as .NET will automatically bind parameter values based on the query string. A call to http://localhost:5000/api/animals?species=dinosaur will now trigger our Get method and automatically bind the value "dinosaur" to the variable species. The framework does this by utilizing Model Binding which we used in our MVC apps to collect information from the route or from forms to use in our controllers.

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