using GlobalSqa.Test.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GlobalSqa.Test.Services
{
    public class TestdataService
    {
        private static string wpd = Directory.GetCurrentDirectory();

        public static List<TestdataModel> Testdata()
        {
            string testdataFile = Path.Combine(wpd.Substring(0, wpd.LastIndexOf("bin")), "Testdata", "testdata.json");
            string readTestdata = File.ReadAllText(testdataFile);

            var testdataModel = JsonConvert.DeserializeObject<List<TestdataModel>>(readTestdata);

            return testdataModel;
        }
    }
}
