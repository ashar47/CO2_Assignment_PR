using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR_Assignment1_CO2Data.Contract
{

    public class Attributes
    {
        [JsonProperty("site_code")]
        public string Site_Code { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
        [JsonProperty("month")]
        public int Month { get; set; }
        [JsonProperty("day")]
        public int Day { get; set; }
        [JsonProperty("hour")]
        public int Hour { get; set; }
        [JsonProperty("minute")]
        public int Minute { get; set; }
        [JsonProperty("second")]
        public int Second { get; set; }
        [JsonProperty("value")]
        public decimal Value { get; set; }
        [JsonProperty("value_unc")]
        public decimal Value_Unc { get; set; }
        [JsonProperty("nvalue")]
        public decimal NValue { get; set; }
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
        [JsonProperty("altitude")]
        public decimal Altitude { get; set; }
        [JsonProperty("elevation")]
        public decimal Elevation { get; set; }
        [JsonProperty("intake_height")]
        public decimal Intake_Height { get; set; }
        [JsonProperty("instrument")]
        public string Instrument { get; set; }
        [JsonProperty("qcflag")]
        public string QcFlag { get; set; }
    }
}
