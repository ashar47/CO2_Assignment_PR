using PR_Assignment1_CO2Data.contract;
using PR_Assignment1_CO2Data.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PR_Assignment1_CO2Data
{
    public class FileService
    {
        private readonly string _filePath_Alaska = "co2_hawaii.txt";
        private readonly string _filePath_Hawaii = "co2_alaska.txt";
        private readonly string outputFile = "annual_co2.txt";
        private string _filePath;
        public async Task<List<Summary>> UnmodifiedFileData(string fileName)
        {
            if (fileName.ToLower().Equals("alaska"))
                _filePath = _filePath_Alaska;
            else
                _filePath = _filePath_Hawaii;

            try
            {
                List<Attributes> data = new List<Attributes>();
                List<string> rawData = File.ReadLines(_filePath).ToList();
                rawData.RemoveAll(x => x.StartsWith('#'));

                while (rawData.Count > 0)
                {
                    data.Add(SeggregateData(rawData[0]));
                    rawData.RemoveAt(0);
                }
                Console.WriteLine("--- Data of " + fileName + " has been saved into a data structure ---");
                Console.WriteLine("--- Removing the invalid data for  " + fileName + " --- \n");
                Console.WriteLine("--- BEFORE removing the invalid data, number of rows for " + fileName + " ---" + data.Count);

                var cleanedData = ModifiedFileData(data);
                Console.WriteLine("--- AFTER removing the invalid data, number of rows for " + fileName + " ---" + cleanedData.Count);

                return CalculationsPerYear(cleanedData, fileName);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to read the data for  " + fileName + " ...");
                throw;
            }
        }
        /// <summary>
        /// Writing Data onto the output file in Write Mode
        /// </summary>
        /// <param name="alaska"></param>
        /// <param name="hawaii"></param>
        public void OutputFile(List<Summary> alaska, List<Summary> hawaii)
        {
            Console.WriteLine("--- Writing combined data of Alaska and Hawaii on a file ---");
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            File.AppendAllLines(outputFile, new List<string>() { "\tAlaska " + "\t\t\t\t\t" + " Hawaii " + "\n" + "Year" + " " + "Max_Level" + " " + "Mean_Level" + " " + "%Change" + " " + "Max_Level" + " " + "Mean_Level" + " " + "%Change" });
            var yearsInTotal = alaska.Select(x => x.Year).Concat(hawaii.Select(y => y.Year)).Distinct().OrderBy(x => x).ToList();
            int a_i = 0;
            int h_i = 0;
            for (int i = 0; i < yearsInTotal.Count(); i++)
            {
                if (alaska[a_i].Year == yearsInTotal[i] && hawaii[h_i].Year == yearsInTotal[i])
                {
                    File.AppendAllLines(outputFile, new List<string>() { alaska[a_i].Year.ToString() + "\t" + string.Format("{0:0.00}", alaska[a_i].MaxValue) + "\t" + string.Format("{0:0.00}", alaska[a_i].MeanValue) + "\t" + string.Format("{0:0.00}", alaska[a_i].PerChange) + "\t" + string.Format("{0:0.00}", hawaii[h_i].MaxValue) + "\t" + string.Format("{0:0.00}", hawaii[h_i].MeanValue) + "\t" + string.Format("{0:0.00}", hawaii[h_i].PerChange) });
                    a_i += 1;
                    h_i += 1;
                }
                else if (alaska[a_i].Year == yearsInTotal[i])
                {
                    File.AppendAllLines(outputFile, new List<string>() { alaska[a_i].Year.ToString() + "\t" + string.Format("{0:0.00}", alaska[a_i].MaxValue) + "\t" + string.Format("{0:0.00}", alaska[a_i].MeanValue) + "\t" + string.Format("{0:0.00}", alaska[a_i].PerChange) + "\t" + string.Format("{0:0.00}", "000.00") });
                    a_i += 1;
                }
                else if (hawaii[h_i].Year == yearsInTotal[i])
                {
                    File.AppendAllLines(outputFile, new List<string>() { hawaii[h_i].Year.ToString() + "\t" + string.Format("{0:0.00}", "000.00") + "\t" + string.Format("{0:0.00}", "000.00") + "\t" + string.Format("{0:0.00}", "0.00") + "\t" + string.Format("{0:0.00}", hawaii[h_i].MaxValue) + "\t" + string.Format("{0:0.00}", hawaii[h_i].MeanValue) + "\t" + string.Format("{0:0.00}", hawaii[h_i].PerChange) });
                    h_i += 1;
                }
            }
            Console.WriteLine("--- File Updated ---");
        }
        /// <summary>
        /// Calculating %Change Mean for individual places
        /// </summary>
        /// <param name="summary"></param>
        /// <returns></returns>
        public decimal PerChangeMean(List<Summary> summary)
        {
            Console.WriteLine("--- Calculating %Change Mean individually ---");
            decimal mean = 0;
            foreach (var item in summary)
                mean += item.PerChange;
            return Math.Round(mean / summary.Count(), 2);

        }
        /// <summary>
        /// Appending the % Change of the places onto the output file
        /// </summary>
        /// <param name="perChangeMeanAlaska"></param>
        /// <param name="perChangeMeanHawaii"></param>
        public void WriteLine(decimal perChangeMeanAlaska, decimal perChangeMeanHawaii)
        {
            Console.WriteLine("--- Updating the file with %Change mean for Alaska and Hawaii ---");
            File.AppendAllLines(outputFile, new List<String>() { "%Change Mean " + "\t" + perChangeMeanAlaska.ToString() + "\t" + perChangeMeanHawaii.ToString() });
        }

        #region Private Methods
        /// <summary>
        /// Putting data from file into data structure
        /// Tightly coupled
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Attributes SeggregateData(string row)
        {
            var rowData = row.Split(" ");
            var attribute = new Attributes();
            attribute.Site_Code = rowData[0];
            attribute.Year = Convert.ToInt32(rowData[1]);
            attribute.Month = Convert.ToInt32(rowData[2]);
            attribute.Day = Convert.ToInt32(rowData[3]);
            attribute.Hour = Convert.ToInt32(rowData[4]);
            attribute.Minute = Convert.ToInt32(rowData[5]);
            attribute.Second = Convert.ToInt32(rowData[6]);
            attribute.Value = Convert.ToDecimal(rowData[7]);
            attribute.Value_Unc = Convert.ToDecimal(rowData[8]);
            attribute.NValue = Convert.ToDecimal(rowData[9]);
            attribute.Latitude = Convert.ToDecimal(rowData[10]);
            attribute.Longitude = Convert.ToDecimal(rowData[11]);
            attribute.Altitude = Convert.ToDecimal(rowData[12]);
            attribute.Elevation = Convert.ToDecimal(rowData[13]);
            attribute.Intake_Height = Convert.ToDecimal(rowData[14]);
            attribute.Instrument = rowData[15];
            attribute.QcFlag = rowData[16];
            return attribute;
        }
        /// <summary>
        /// Removing the invalid data from the data structure
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        private List<Attributes> ModifiedFileData(List<Attributes> rawData)
        {
            int index = 0;
            while (index < rawData.Count)
            {
                if (rawData[index].QcFlag.Equals("*.."))
                    rawData.RemoveAt(index);
                else index += 1;
            }
            return rawData;
        }
        /// <summary>
        /// Computing MaxValue, MeanValue and % Change for individual places
        /// </summary>
        /// <param name="modifiedData"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        private List<Summary> CalculationsPerYear(List<Attributes> modifiedData, string place)
        {
            Console.WriteLine("--- Calculating Max Value, Mean and % Change for " + place + " ---");
            var yearWiseGroupedElements = modifiedData.GroupBy(x => x.Year).ToList();
            var summarisedData = new List<Summary>();
            decimal max_level = 0; decimal mean_level = 0;
            foreach (var item in yearWiseGroupedElements)
            {
                summarisedData.Add(new Summary() { Year = item.Key, Place = place });

                foreach (var value in item)
                {
                    if (max_level < value.Value)
                        max_level = value.Value;
                    mean_level += value.Value;

                }
                summarisedData.LastOrDefault().MaxValue = max_level;
                max_level = 0;
                summarisedData.LastOrDefault().MeanValue = Math.Round(mean_level / item.Count(), 2);
                if (summarisedData.Count == 1)
                {
                    summarisedData.LastOrDefault().PerChange = 0;
                }
                else
                {
                    var previousMean = summarisedData[summarisedData.Count() - 2].MeanValue;
                    summarisedData.LastOrDefault().PerChange =
                       Math.Round(((summarisedData.LastOrDefault().MeanValue - previousMean) / previousMean) * 100, 2);
                }

                mean_level = 0;
            }
            Console.WriteLine("--- Calculation done for " + place + " ---");
            return summarisedData;
        }
        #endregion
    }
}
