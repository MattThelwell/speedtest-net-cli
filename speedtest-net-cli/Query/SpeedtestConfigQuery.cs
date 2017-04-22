﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpeedtestNetCli.Query
{
    public class SpeedtestConfigQuery : IHttpQuery<XDocument>
    {
        public async Task<XDocument> Execute(HttpClient client)
        {
            var response = await client.GetAsync("http://www.speedtest.net/speedtest-config.php?x=" + Guid.NewGuid().ToString());
            var xmlDocument = XDocument.Load(await response.Content.ReadAsStreamAsync());
            return xmlDocument;
        }
    }
}
