using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Linq;
using System.Linq;

namespace MeteoParser
{
    class DataProvaider
    {
        static string[] urls;

        static DataProvaider()
        {
            urls = new string[]
            {@"https://xml.meteoservice.ru/export/gismeteo/point/32277.xml"};
        }

    HttpClient httpClient;
    public DataProvaider()
        {
            httpClient = new HttpClient();
        }
        public ObservableCollection<WetherModel> GetWetherModels()
        {
            ObservableCollection<WetherModel> temp = new ObservableCollection<WetherModel>();

            foreach (var url in urls)
            {
               var req =  httpClient.GetStringAsync(url).Result;
                // Debug.WriteLine(req);
                var ColWeather = XDocument.Parse(req)
                      .Descendants("MMWEATHER")
                      .Descendants("REPORT")
                      .Descendants("TOWN")
                      .Descendants("FORECAST")
                      .ToList();
            foreach (var FORECAST in ColWeather)
            {
                    temp.Add(
                                new WetherModel()
                                {
                                    DATE = FORECAST.Attribute("day").Value,
                                    TEMPERATURE = FORECAST.Element("TEMPERATURE").Attribute("max").Value,
                                    PRESSURE = FORECAST.Element("PRESSURE").Attribute("max").Value,
                                    WIND = FORECAST.Element("WIND").Attribute("max").Value,
                                }
                             );
            }
            }
            return temp;
        }
    }
}
