using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrlShortenerService.Models
{
    public class ShortenUrlViewModel
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please enter the long url")]
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public Guid Id { get; set; }

    }
}