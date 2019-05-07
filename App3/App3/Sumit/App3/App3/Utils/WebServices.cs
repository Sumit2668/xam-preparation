using App3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App3.Utils
{
    class WebServices
    {
        public readonly string BaseURL = @"https://xam-tutorial.herokuapp.com/api/v1/control-desc?control=";

        #region Login WebService
        public async Task<MainHeading> ControlDetails(string ctrname)
        {
            MainHeading jsonResponse = new MainHeading();
            try
            {
                HttpResponseMessage response;

                var RestURL = BaseURL + ctrname;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestURL);
                JObject j = new JObject();

                //j.Add("Id", model.Id);
                //j.Add("DeviceID", model.DeviceID);
                //j.Add("DeviceType", model.DeviceType);
                //j.Add("DayStarts", model.DayStarts);
                //j.Add("DayEnds", model.DayEnds);
                //j.Add("Sun", model.Sun);
                //j.Add("Mon", model.Mon);
                //j.Add("Tue", model.Tue);
                //j.Add("Wed", model.Wed);
                //j.Add("Thu", model.Thu);
                //j.Add("Fri", model.Fri);
                //j.Add("Sat", model.Sat);
                //j.Add("AlertTone", model.AlertTone);
                //j.Add("MoveFreq", model.MoveFreq);
                //j.Add("TimeZone", model.TimeZone);
                //j.Add("utcTime", model.utcTime);
                //j.Add("DeviceSrNo", model.DeviceSrNo);

                //var json = JsonConvert.SerializeObject(j);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                // response = client.PostAsync(RestURL, content).Result; // Blocking call!
                response = await client.GetAsync(RestURL); // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = response.Content.ReadAsStringAsync().Result;
                    JObject.Parse(jsonresult);
                    jsonResponse = JsonConvert.DeserializeObject<MainHeading>(jsonresult,
                                   new JsonSerializerSettings
                                   {
                                       NullValueHandling = NullValueHandling.Ignore
                                   });
                }
            }
            catch (Exception ex)
            {
                //StaticMethods.ShowToast(ex.Message);
            }
            return jsonResponse;
        }
        #endregion
    }
}
