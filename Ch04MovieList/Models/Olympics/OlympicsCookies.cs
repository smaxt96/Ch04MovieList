using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ch04MovieList.Models.Olympics
{
    public class OlympicsCookies
    {
        private const string MyCountries = "mycountries";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public OlympicsCookies(IRequestCookieCollection cookies) {
            requestCookies = cookies;
        }

        public OlympicsCookies(IResponseCookies cookies) {
            responseCookies = cookies;
        }

        public void SetMyCountryIds (List<Country> mycountries) {
            List<string> ids = mycountries.Select(t => t.CountryID).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions {
                Expires = DateTime.Now.AddDays(30)
            };
            RemoveMyCountryIds();   // delete old cookie first
            responseCookies.Append(MyCountries, idsString, options);
        }

        public string[] GetMyCountryIds()
        {
            string cookie = requestCookies[MyCountries];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { }; // empty string array
            else
                return cookie.Split(Delimiter);

        }

        public void RemoveMyCountryIds() {
            responseCookies.Delete(MyCountries);
        }
    }
}
