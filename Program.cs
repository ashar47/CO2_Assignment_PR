namespace PR_Assignment1_CO2Data
{
    class Program
    {
        public static void Main(string[] args)
        {
            GetResults();
        }
        public static async void GetResults()
        {
            FileService fileService = new FileService(); 

            var alaskaTask = await fileService.UnmodifiedFileData("Alaska");
            var hawaiiTask = await fileService.UnmodifiedFileData("Hawaii");
             
            fileService.OutputFile(alaskaTask, hawaiiTask);
            var perChangeMeanAlaska = fileService.PerChangeMean(alaskaTask);
            var perChangeMeanHawaii = fileService.PerChangeMean(hawaiiTask);

            fileService.WriteLine(perChangeMeanAlaska, perChangeMeanHawaii);
        }
    }

}
