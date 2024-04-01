using System;
using System.Collections.Generic;

namespace Joke.Models
{
    public partial class Joke
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
    }
}
