using Progress.Open4GL.Proxy;
using sp4net;
using sp4net.StrongTypesNS;
using System;
using System.IO;
using System.Net;
using System.Web.Configuration;

namespace SP4ADMIN.Models
{
    public class Veriables
    {
        private static int? retailNum;
        private static string sideBarHTML;
        private static string itemMessage;
        private static string retailMessage;
        private static readonly string ip = WebConfigurationManager.AppSettings["Ip"];
        private static sp4 _Sp4;
        private static Connection connection;
        private static ITEM_TTDataTable item_TTDataTable = new ITEM_TTDataTable();
        private static RETAIL_TTDataTable rETAIL_TTDataTable = new RETAIL_TTDataTable();
        public static string Ip { get => ip; }
        public static int? RetailNum
        {
            get
            {
                var gecici = retailNum;
                retailNum = null;
                return gecici;
            }
            set { retailNum = value; }
        }
        public static string SideBarHTML
        {
            get { return sideBarHTML; }
            set { sideBarHTML = value; }
        }
        public static string RetailMessage => retailMessage;
        public static string ItemMessage => itemMessage;
        public static ITEM_TTDataTable ItemDataTable => item_TTDataTable;
        public static RETAIL_TTDataTable RetailDataTable => rETAIL_TTDataTable;
        public static void ListCustByName(string apikey, string CustName = "")
        {
            rETAIL_TTDataTable = null;
            try
            {
                ConnectionOpen();
                _Sp4.CustRetailList_Get_app(apikey,
                                            GetIp(),
                                            DateTime.MinValue.ToString("yyyy-MM-dd"),
                                            DateTime.MaxValue.ToString("yyyy-MM-dd"),
                                            "",
                                            CustName,
                                            "",
                                            "YES",
                                            out retailMessage,
                                            out rETAIL_TTDataTable);
                ConnectionDispose();
            }
            catch (Exception ex)
            {
                retailMessage = string.Empty;
                LocalWriter.L_LocalLog(
                    DateTime.Now.ToLongTimeString()
                    + Environment.NewLine
                    + ex.Message
                    + Environment.NewLine
                    + ex.StackTrace
                    + Environment.NewLine
                    );
                retailMessage = $"500|{ex.Message}";
                ConnectionDispose();
            }
        }
        public static void ListItem(string apikey)
        {
            item_TTDataTable = null;
            try
            {
                ConnectionOpen();
                _Sp4.itemList_get_app(apikey,
                                     GetIp(),
                                     DateTime.MinValue.ToString("yyyy-MM-dd"),
                                     DateTime.MaxValue.ToString("yyyy-MM-dd"),
                                     "",
                                     "",
                                     "",
                                     "",
                                     "YES",
                                     out itemMessage,
                                     out item_TTDataTable);
                ConnectionDispose();
            }
            catch (Exception ex)
            {
                retailMessage = string.Empty;
                LocalWriter.L_LocalLog(
                    DateTime.Now.ToLongTimeString()
                    + Environment.NewLine
                    + ex.Message
                    + Environment.NewLine
                    + ex.StackTrace
                    + Environment.NewLine
                    );
                itemMessage = $"500|{ex.Message}";
                ConnectionDispose();
            }
        }
        private static string GetIp()
        {
            return new StreamReader(((HttpWebResponse)((HttpWebRequest)HttpWebRequest.Create("http://185.119.82.114/ip.asp")).GetResponse()).GetResponseStream()).ReadToEnd();
        }
        private static void ConnectionOpen()
        {
            connection = new Connection(System.Web.Configuration.WebConfigurationManager.AppSettings["Connection"], "", "", "");
            _Sp4 = new sp4(connection);
        }
        private static void ConnectionDispose()
        {
            _Sp4.Dispose();
            connection.Dispose();
        }
    }
}