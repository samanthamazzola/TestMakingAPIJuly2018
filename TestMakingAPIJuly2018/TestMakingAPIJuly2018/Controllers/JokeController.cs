using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestMakingAPIJuly2018.Controllers
{
    public class JokeController : ApiController
    {
        [HttpGet] //attribute
        public string DadJokes()
        {
            string[] dadJokes = {"What’s that Nevada city where all the dentists visit?: Floss Vegas.",
            "Want to hear a joke about paper?: Never mind, it’s tearable!",
            "MOM: How do I look? DAD: With your eyes.",
            "Don't trust atoms. They make up everything!"}; //array
            //use random number to select a joke
            Random r = new Random();
            int selected = r.Next(0, dadJokes.Length);

            //return the selected joke
            return dadJokes[selected];
        }
    }
}