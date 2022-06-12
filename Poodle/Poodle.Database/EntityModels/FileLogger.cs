using Poodle.Data.EntityModels.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Data.EntityModels
{
    public class FileLogger : ILogger
    {
        private readonly string mLogPath;

        public FileLogger(string logPath)
        {
            this.mLogPath = logPath;
            //the the folder of the log path
            var directory = Path.GetDirectoryName(mLogPath);
            //ensure the folder exists
            Directory.CreateDirectory(directory);
        }
        public void LogMessage(string message)
        {
            using (var fileStream = new StreamWriter(File.OpenWrite(mLogPath)))
            {
                //move to the en dof the file
                fileStream.BaseStream.Seek(0, SeekOrigin.End);
                //write new line
                fileStream.WriteLine(message);
            }
        }
    }
}
