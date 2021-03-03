using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static ProjectMovieAPI.Models.Movie;
using static ProjectMovieAPI.Secret;

namespace ProjectMovieAPI.Models
{
    public class MovieDAL
    {
        public string GetData(string searchName)
        {
            string url = $"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={searchName}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = null;

            response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string json = rd.ReadToEnd();
            return json;

        }

        public List<Movie> SearchMovies(string name)
        {
            string json = GetData(name);

            Rootobject r = JsonConvert.DeserializeObject<Rootobject>(json);
            List<Movie> movies;
            if (r.data == null)
            {
                movies = new List<Movie>();
            }
            else
            {
                movies = r.data.ToList();
            }
            return movies;
        }
    }

}
