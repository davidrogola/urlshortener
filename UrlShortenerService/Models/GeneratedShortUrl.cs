using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortenerService.Models
{
    public class GeneratedShortUrl
    {
        public GeneratedShortUrl()
        {

        }
        public GeneratedShortUrl(Guid id,string longUrl,string shortUrl)
        {
            Id = id;
            LongUrl = longUrl;
            ShortUrl = shortUrl;
            DateCreated = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ? DateDeactivated { get; set; }

    }
}