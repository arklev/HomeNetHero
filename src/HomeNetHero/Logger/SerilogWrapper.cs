using Serilog;
using System;
using System.IO;

namespace HomeNetHeroApp
{
    public class SerilogWrapper
    {
        #region Members

        private string _loggerFileName;
        private string _loggerFileLocation;

        #endregion

        public SerilogWrapper(string logFileName, string logFileLocation)
        {
            // Validate and assign input values
            if (string.IsNullOrWhiteSpace(logFileName))
            {
                throw new ArgumentException("Log file name cannot be null or empty.", nameof(logFileName));
            }

            // Check for invalid characters in the log file name
            if (logFileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new ArgumentException("Log file name contains invalid characters.", nameof(logFileName));
            }

            _loggerFileName = logFileName;

            if (string.IsNullOrWhiteSpace(logFileLocation))
            {
                throw new ArgumentException("Log file location cannot be null or empty.", nameof(logFileLocation));
            }

            // Convert the log file location to an absolute path if it is a relative path
            if (!Path.IsPathRooted(logFileLocation))
            {
                logFileLocation = Path.GetFullPath(logFileLocation);
            }

            // Attempt to create the log file directory if it doesn't exist
            try
            {
                Directory.CreateDirectory(logFileLocation);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid log file location.", nameof(logFileLocation), ex);
            }

            // Validate file location
            if (!Directory.Exists(logFileLocation))
            {
                throw new ArgumentException("Invalid log file location.", nameof(logFileLocation));
            }

            _loggerFileLocation = logFileLocation;

            // Create the logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(logFileLocation, logFileName), rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }


}
