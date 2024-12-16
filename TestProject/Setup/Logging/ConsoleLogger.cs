using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace TestProject.Setup.Logging
{
    public static class ConsoleLogger
    {
        private static readonly List<string> _logs = new();

        public static void LogMessage(string message)
        {
            _logs.Add(message);
        }

        public static void OutputLogs(ITestOutputHelper testOutputHelper)
        {
            testOutputHelper.WriteLine("--------Browser console logs-----------");
            foreach (var log in _logs)
            {
                testOutputHelper.WriteLine(log);
            }
            _logs.Clear();
        }

        public static List<string> GetAllLogs() => new(_logs);
    }
}
