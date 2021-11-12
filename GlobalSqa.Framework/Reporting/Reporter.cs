using System;
using System.IO;

namespace GlobalSqa.Framework.Reporting
{
    public class Reporter
    {
        private readonly string _filePath;

        public Reporter(string testname, string filepath)
        {
            _filePath = filepath;
            using (var log = File.CreateText(_filePath))
            {
                log.WriteLine($"Starting timestamp: {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test: {testname}");
            }
        }

        public void Info(string message)
        {
            WriteLine($"[INFO]: {message}");
        }

        public void Step(string message)
        {
            WriteLine($"\t[STEP]: {message}");
        }

        public void Warning(string message)
        {
            WriteLine($"[WARNING]: {message}");
        }

        public void Error(string message)
        {
            WriteLine($"[ERROR]: {message}");
        }

        public void Fatal(string message)
        {
            WriteLine($"[FATAL]: {message}");
        }

        public void Screenshot(string message)
        {
            WriteLine($"[SCREENSHOT]: {message}");
        }

        private void WriteLine(string text)
        {
            using (var log = File.AppendText(_filePath))
            {
                log.WriteLine(text);
            }
        }
        private void Write(string text)
        {
            using (var log = File.AppendText(_filePath))
            {
                log.Write(text);
            }
        }
    }
}
