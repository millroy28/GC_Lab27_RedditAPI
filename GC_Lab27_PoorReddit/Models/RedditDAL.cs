using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

using System.Threading.Tasks;

namespace GC_Lab27_PoorReddit.Models
{
    public class RedditDAL
    {
        public string GetAPIJson(string subreddit)
        {
            string url = $"https://www.reddit.com/r/{subreddit}/.json";

            HttpWebRequest request = WebRequest.CreateHttp(url);                //requires using System.Net
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());       //req system.io
            string output = sr.ReadToEnd();
            return output;
        }

        public List<RedditPost> GetPost(string subreddit)
        {
            List<RedditPost> posts = new List<RedditPost>();

            string redditData = GetAPIJson(subreddit);
            JObject json = JObject.Parse(redditData);
            List<JToken> modelData = json["data"]["children"].ToList();  //filters by tag name ... grabbing each of the children from the mess and putting them into a list
            for (int i = 0; i < 10; i++)
            {
                string s = modelData[i]["data"].ToString();         //
                RedditPost p = JsonConvert.DeserializeObject<RedditPost>(modelData[i]["data"].ToString());
                posts.Add(p);
            }
            return posts;
        }
    }
}
