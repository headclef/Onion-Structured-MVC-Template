using Infrastructure.Enums;
using Infrastructure.Services.Abstract;
using System.Diagnostics;
using System.IO.Compression;

namespace Infrastructure.Services.Concrete
{
    public class LogService : ILogService
    {
        #region Properties
        private string _logPath;
        private string _lastLogFilePath;
        #endregion
        #region Constructors
        public LogService()
        {
            _logPath = EnsureLogPathExists();
            EnsureLogFileExists("Error");
            EnsureLogFileExists("Information");
        }
        #endregion
        #region Methods
        public void WriteLog(LogLevel level, string message)
        {
            // Prepare log environment
            PrepareLogEnvironment(level.ToString());

            var logEntry = $"{DateTime.Now:HH:mm:ss} [{level}] - {message}";
            var path = Path.Combine(_logPath, $"{DateTime.Today:dd.MM.yyyy}-{level}-Log.txt");

            // Yaz dosyaya
            File.AppendAllText(path, logEntry + Environment.NewLine);

            // Seviye bazlı ek loglama (Debug, Console, Trace)
            if (level == LogLevel.Debug || level == LogLevel.Trace)
            {
                Debug.WriteLine(logEntry);
            }

            if (level == LogLevel.Warning || level == LogLevel.Error || level == LogLevel.Critical)
            {
                Trace.WriteLine(logEntry);
            }

            // Üretimde sadece önemli logları göster
            #if DEBUG
            Console.WriteLine(logEntry);
            #endif
        }

        /// <summary>
        /// Prepares the environment to safely write logs:
        /// - Ensures the log directory exists
        /// - Ensures the log file exists
        /// - Rotates large or outdated log files to OldLogs
        /// - Archives OldLogs folder to zip if any files exist
        /// </summary>
        /// <param name="logType"></param>
        private void PrepareLogEnvironment(string logType)
        {
            EnsureLogPathExists();           // 1️⃣
            EnsureLogFileExists(logType);    // 2️⃣
            RotateLogFile(logType);          // 3️⃣
            ArchiveOldLogsToZip();           // 4️⃣
        }

        private void RotateLogFile(string logType)
        {
            // Check if log file is too large or old
            string fileName = $"{DateTime.Today:dd.MM.yyyy}-{logType}-Log.txt";
            string logFilePath = Path.Combine(_logPath, fileName);
            string oldLogsPath = Path.Combine(_logPath, "OldLogs");

            // Max size of log file
            const long maxSize = 10 * 1024 * 1024; // 10 MB

            // Check if log file exists
            if (!File.Exists(logFilePath))
                return;

            // Check if log file is too large or old
            var fileInfo = new FileInfo(logFilePath);

            // Check if log file is too large or old
            bool isTooLarge = fileInfo.Length >= maxSize;
            bool isOld = fileInfo.CreationTime.Date < DateTime.Today;

            // If log file is too large or old, move it to old logs folder
            if (isTooLarge || isOld)
            {
                // Create old logs folder if not exists
                Directory.CreateDirectory(oldLogsPath);

                // Move log file to old logs folder
                string newFileName = Path.GetFileNameWithoutExtension(fileName) + $"_{DateTime.Now:HHmmss}" + ".txt";
                string destinationPath = Path.Combine(oldLogsPath, newFileName);

                // Move log file
                File.Move(logFilePath, destinationPath);
                using (File.Create(logFilePath)) { }
            }
        }

        private void ArchiveOldLogsToZip()
        {
            // Check if old logs folder exists
            string oldLogsPath = Path.Combine(_logPath, "OldLogs");
            string archivePath = Path.Combine(_logPath, "ArchivedLogs");
            Directory.CreateDirectory(archivePath);

            // Check if any old log exists
            var oldLogFiles = Directory.GetFiles(oldLogsPath, "*.txt");
            if (oldLogFiles.Length == 0)
                return;

            // Create zip file
            string zipFileName = $"ArchivedLogs_{DateTime.Today:dd.MM.yyyy}_{DateTime.Now:HHmmss}.zip";
            string zipFilePath = Path.Combine(archivePath, zipFileName);

            // Archive old logs
            using (var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var file in oldLogFiles)
                {
                    // Add file to archive
                    archive.CreateEntryFromFile(file, Path.GetFileName(file));

                    // Delete file
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// Generates log file depending on log type
        /// </summary>
        /// <param name="logType"></param>
        private void EnsureLogFileExists(string logType)
        {
            // Get path
            var path = Path.Combine(_logPath, $"{DateTime.Today:dd.MM.yyyy}-{logType}Log.txt");

            // Create file if not exists
            if (!File.Exists(path))
            {
                // Create file
                File.Create(path).Dispose();
            }

            // Set last log file path
            _lastLogFilePath = path;
        }

        /// <summary>
        /// Generates log folder and it's path
        /// </summary>
        /// <returns></returns>
        private string EnsureLogPathExists()
        {
            // Get path
            var path = Path.Combine(AppContext.BaseDirectory, "Log");

            // Create directory if not exists
            Directory.CreateDirectory(path);

            // Return path
            return path;
        }
        #endregion
    }
}