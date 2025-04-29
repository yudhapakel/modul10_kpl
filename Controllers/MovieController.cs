using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300010.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> moviesList = new List<Movie>
        {
            new Movie { title="The Shawshank Redemption", director="Frank Darabont", stars=new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, 
                description="A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."},
            new Movie {title="The God Father", director="Francis Ford Coppola", stars= new List<string>{"Marlon Brando", "AI Pacino", "James Caan"}, 
                description="The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."},
            new Movie {title="The Dark Knight", director="Chistoper Nolan", stars= new List<string>{"Christian Bale", "Heath Ledger", "Aaron Eckhart"},
                description="When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."}
        };

        [HttpGet]
        public ActionResult<List<Movie>> Get() 
        { 
            return moviesList;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id) 
        {
            if (id < 0 || id > moviesList.Count)
            {
                return NotFound();
            }
            return moviesList[id];
        }

        [HttpPost]
        public ActionResult<List<Movie>> Post([FromBody] Movie mve) 
        {
            moviesList.Add(mve);
            return moviesList;
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Movie>> Delete(int id)
        {
            if (id < 0 || id >= moviesList.Count)
            {
                return NotFound();
            }
            moviesList.RemoveAt(id);
            return moviesList;
        }
    }
}
