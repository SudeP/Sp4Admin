using System;
using System.IO;

namespace SP4ADMIN.Models
{
    public class LocalWriter
    {
        #region Fields
        private static string localLogFolderName = "Logs";
        private static string MonthFolder;
        private static string DayFolder;
        private static string NowFolder;
        private static readonly string NowFolderType = ".txt";
        private static String AppPath;
        private static StreamWriter streamWriter;
        private static DateTime dateTime;
        public string L_LocalLogFolderName { get => localLogFolderName; set => localLogFolderName = value; }
        #endregion
        #region Functions
        #region Consturactor
        internal LocalWriter()
        {
        }
        #endregion
        /// <summary>
        /// Auto Create Folder. Format : Debug/[localLogFolderName]/Month/Day/Now.txt
        /// </summary>
        /// <param name="Log"></param>
        public static void L_LocalLog(string Log)
        {
            AppPath = System.Web.HttpRuntime.AppDomainAppPath;
            DetermineDate();
            ControlFolder();
            if (!File.Exists(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder + "\\" + DayFolder + "\\" + NowFolder + NowFolderType))
            {
                streamWriter = File.CreateText(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder + "\\" + DayFolder + "\\" + NowFolder + ".txt");
            }
            else
            {
                streamWriter = File.AppendText(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder + "\\" + NowFolder + NowFolderType);
            }
            streamWriter.Write(Log + Environment.NewLine);
            streamWriter.Close();
        }
        /// <summary>
        /// Format : Debug/localLogFolderName/Folder/SubFolder/FileName.txt
        /// </summary>
        /// <param name="Folder"></param>
        /// <param name="SubFolder"></param>
        /// <param name="FileName"></param>
        /// <param name="Log"></param>
        public static void L_LocalLog(string Folder,
                                      string SubFolder,
                                      string FileName,
                                      string Log)
        {
            AppPath = AppDomain.CurrentDomain.BaseDirectory;
            ControlFolder(Folder, SubFolder);
            if (!File.Exists(AppPath + "\\" + localLogFolderName + "\\" + Folder + "\\" + SubFolder + "\\" + FileName + NowFolderType))
                streamWriter = File.CreateText(AppPath + "\\" + localLogFolderName + "\\" + Folder + "\\" + SubFolder + "\\" + FileName + NowFolderType);
            else
                streamWriter = File.AppendText(AppPath + "\\" + localLogFolderName + "\\" + Folder + "\\" + SubFolder + "\\" + FileName + NowFolderType);
            streamWriter.Write(DateTime.Now + " " + Log + Environment.NewLine);
            streamWriter.Close();
        }
        private static void DetermineDate()
        {
            dateTime = DateTime.Now;
            MonthFolder = dateTime.ToString("MM.yyyy");
            DayFolder = dateTime.Day.ToString();
            NowFolder = dateTime.ToString("HH.mm");
        }
        private static void ControlFolder()
        {
            if (!Directory.Exists(AppPath + "\\" + localLogFolderName + ""))
            {
                Directory.CreateDirectory(AppPath + "\\" + localLogFolderName + "");
            }
            if (!Directory.Exists(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder))
            {
                Directory.CreateDirectory(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder);
            }
            if (!Directory.Exists(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder + "\\" + DayFolder))
            {
                Directory.CreateDirectory(AppPath + "\\" + localLogFolderName + "\\" + MonthFolder + "\\" + DayFolder);
            }
        }
        private static void ControlFolder(string Folder, string SubFolder)
        {
            if (!Directory.Exists(AppPath + "\\" + localLogFolderName + ""))
                Directory.CreateDirectory(AppPath + "\\" + localLogFolderName);
            if (!Directory.Exists(AppPath + "\\" + localLogFolderName + "\\" + Folder))
                Directory.CreateDirectory(AppPath + "\\" + localLogFolderName + "\\" + Folder);
            if (!Directory.Exists(AppPath + "\\" + localLogFolderName + "\\" + Folder + "\\" + SubFolder))
                Directory.CreateDirectory(AppPath + "\\" + localLogFolderName + "\\" + Folder + "\\" + SubFolder);
        }
        #endregion
    }
}