using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MovieAPI.Models
{
    public partial class Favorites
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Year { get; set; }
        public int? Runtime { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
