using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieAPI.Models
{
    public class MovieDAL
    {
        public string GetDataId(int Id)
        {
            string idUrl = $"https://api.themoviedb.org/3/movie/{Id}?api_key={Secret.apiKey}";
            HttpWebRequest request = WebRequest.CreateHttp(idUrl);
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;
        }
        public string GetDataString(string searchName)
        {
            string stringUrl = $"https://api.themoviedb.org/3/search/movie?api_key={Secret.apiKey}&query={searchName}";
            HttpWebRequest request = WebRequest.CreateHttp(stringUrl);
            HttpWebResponse response = null;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string json = rd.ReadToEnd();
            return json;
        }
        public Movie SearchMoviesId(int Id)
        {
            string json = GetDataId(Id);
            Movie r = JsonConvert.DeserializeObject<Movie>(json);
            if (r.title == null)
            {
                //validation here
                return r;
            }
            else
            {

            }
            return r;

        }
        public List<Result> SearchMoviesString(string query)
        {//return a list
            string json = GetDataString(query);
            SearchResults r = JsonConvert.DeserializeObject<SearchResults>(json);
            return r.results.ToList();
        }
    }
}

