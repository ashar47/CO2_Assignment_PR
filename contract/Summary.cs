using System;
using System.Collections.Generic;
using System.Text;

namespace PR_Assignment1_CO2Data.contract
{
    public class Summary
    {
        public decimal MaxValue { get; set; }
        public decimal MeanValue { get; set; }
        public decimal PerChange { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
    } 
}
