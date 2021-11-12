using System;
using System.IO;
using GlobalSqa.Framework.Reporting;

namespace GlobalSqa.Framework
{
    public class GlobalSqaFW
    {
        public static string wpd = Path.GetFullPath(@"../../../../");

        [ThreadStatic]
        public static DirectoryInfo CurrentTesDirectory;

        [ThreadStatic]
        private static Reporter report;
        public static Reporter Report => report ?? throw new NullReferenceException("report is null. SetReporter() first.");

        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = wpd + "TestResults";

            if (Directory.Exists(testDirectory))
            {
                Directory.Delete(testDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testDirectory);
        }

        public static void SetReporter(string testname, string testid)
        {
            lock (_setReporterLock)
            {
                var testResultsDir = wpd + "TestResults";
                var testName = testname;
                var fullPath = $"{testResultsDir}/{testName}";

                if (Directory.Exists(fullPath))
                {
                    CurrentTesDirectory = Directory.CreateDirectory(fullPath + testid);
                }
                else
                {
                    CurrentTesDirectory = Directory.CreateDirectory(fullPath);
                }

                report = new Reporter(testName, CurrentTesDirectory.FullName + "/TestResults.txt");
            }
        }

        private static object _setReporterLock = new object();
    }
}
