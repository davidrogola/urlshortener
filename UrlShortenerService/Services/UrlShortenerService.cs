using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using UrlShortenerService.Models;

namespace UrlShortenerService.Services
{

    public interface IUrlShortener
    {
        string ShortenUrl(string longUrl);

        string GetUrl(string shortUrl);

        string GetLongUrlById(Guid Id);
    }

    public class UrlShortenerImp : IUrlShortener
    {
        IRepository urlShortenerRepository = null;
        ISequentialGuidGenerator guidGenerator = null;

        public UrlShortenerImp()
        {
            urlShortenerRepository = new UrlShortenerRepository();
            guidGenerator = new SequentialGuidGenerator();
        }

        public string GetUrl(string shortUrl)
        {
            var existingUrl = urlShortenerRepository.GetAll<GeneratedShortUrl>().Where(x => x.ShortUrl == shortUrl)
                .SingleOrDefault();
            if (existingUrl != null)
                return existingUrl.ShortUrl;
            return null;
        }

        public string GetLongUrlById(Guid Id)
        {
            var url = urlShortenerRepository.Get<GeneratedShortUrl>(Id);
            return url.LongUrl;
        }

        public string ShortenUrl(string longUrl)
        {

            var existingUrl = urlShortenerRepository.GetAll<GeneratedShortUrl>()
                .Where(x => x.LongUrl == longUrl)
                .SingleOrDefault();
            if (existingUrl != null)
                return existingUrl.ShortUrl;
            var uniqueId = guidGenerator.New();
            var serviceWebEndpoint = ConfigurationManager.AppSettings["UrlWeb:Endpoint"];
            var generatedShortUrl = new GeneratedShortUrl(uniqueId, longUrl,new Uri($"{serviceWebEndpoint}{uniqueId.ToString()}")
                .ToString());
            urlShortenerRepository.Add(generatedShortUrl);

            return generatedShortUrl.ShortUrl;
        }
    }
}