using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPI.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? MovieId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
