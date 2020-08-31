using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GC_Lab27_PoorMansReddit.Models
{
    public class RedditDAL
    {
        public string CallAPI()
        {
            //sets up our request
            HttpWebRequest request = WebRequest.CreateHttp("https://www.reddit.com/r/aww/.json?limit=10");

            //setup would go here if necessary

            //sends request to remote server and gets response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //sets up streamreader
            StreamReader rd = new StreamReader(response.GetResponseStream());

            //readtoend reads all data
            string output = rd.ReadToEnd();

            return output;
        }

        public RedditPost GetRedditPost()
        {
            string PersonJason = CallAPI();

            //Takes the Json data and puts it inot a Json object
            JObject json = JObject.Parse(PersonJason);


            RedditPost p = JsonConvert.DeserializeObject<RedditPost>(json.ToString());

            return p;
        }
    }
}
