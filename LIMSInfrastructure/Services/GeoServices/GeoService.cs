using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace LIMSInfrastructure.Services.GeoServices
{
	public class GeoService : IGeoService
	{
        private readonly HttpClient _httpClient;
        private readonly IHostingEnvironment _env;

        public GeoService(HttpClient httpClient, IHostingEnvironment env)
        {
            _httpClient = httpClient;
            _env = env;
        }

        public string GetLandParcel(string featuretypename, string attribute, string filter)
        {			

			var RequestEndPoint = $"LIMSParcels2/Service.svc/get?request=GetFeature&service=WFS&version=1.1.0&typename={featuretypename}&outputformat=application/vnd.geo%2Bjson&FILTER=%3CFilter%20xmlns=%22http://www.opengis.net/ogc%22%3E%3CPropertyIsLike%20wildCard=%22*%22%20singleChar=%22!%22%20escapeChar=%22\\%22%3E%3CPropertyName%3E{attribute}%3C/PropertyName%3E%3CLiteral%3E{filter}%3C/Literal%3E%3C/PropertyIsLike%3E%3C/Filter%3E";
          

            var request = new HttpRequestMessage(HttpMethod.Post, RequestEndPoint);

            request.Headers.Clear();
            request.Headers.Add("Accept", "application/vnd.geo+json; charset=utf-8");
            request.Headers.Add("Accept-Encoding", "*");
            request.Headers.Add("User-Agent", "LIMS-Portal");

            _httpClient.Timeout = TimeSpan.FromSeconds(120);

            var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();

            var data = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();

            var json = DeserializeFromStream(data);

            Console.WriteLine(json);

            var output = JsonConvert.SerializeObject(json);

            return output;
        }

		public static object DeserializeFromStream(Stream stream)
		{
			var serializer = new JsonSerializer();

			using (var strm = new StreamReader(stream))
			using (var jsonTextReader = new JsonTextReader(strm))
			{
				return serializer.Deserialize(jsonTextReader);
			}
		}
	}
}
