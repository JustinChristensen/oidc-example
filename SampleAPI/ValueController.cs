using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleAPI
{
    [Route("values")]
    public class ValueController : ApiController
    {
        private static readonly Random _random = new Random();

        public IEnumerable<string> Get() 
        {
            var random = new Random();

            return new[]
            {
                _random.Next(0, 10).ToString(),
                _random.Next(0, 10).ToString(),
            };
        }

    }
}