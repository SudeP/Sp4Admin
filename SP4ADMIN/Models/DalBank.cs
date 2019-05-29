using System;
using sp4net;
using System.Net;
using sp4net.StrongTypesNS;
using Progress.Open4GL.Proxy;

namespace SP4ADMIN.Models
{
    public class DalBank
    {
        public enum BankType
        {
            BEKLIYOR = 01,
            HATALI = 02,
            KAPANDI = 03,
            KORUMA_HESABINDA = 04,
            IPTAL_EDILDI = 05,
            SUPHELI = 06,
            KORUMA_HESABINDAN_IADE = 07,
            IPTAL_BEKLEMEDE = 08,
            DIGER_BANKA_HRK = 99,
        }
        private static sp4 _sp4;
        private static Connection connection;

        private static string message;
        public static string DalMessage => message;

        private static BANKTRANS_TTDataTable _dataTable = new BANKTRANS_TTDataTable();
        public static BANKTRANS_TTDataTable DalDataTable => _dataTable;
        public static void DalSet(string PRAPIKEY,
                               string PRIP,
                               int PRBANK_TRANSID,
                               string PREXT_ORDERID)
        {
            try
            {
                ConnectionOpen();
                _sp4.BankTrans_Update(PRAPIKEY,
                                     PRIP,
                                     PRBANK_TRANSID,
                                     PREXT_ORDERID,
                                     out message);
                ConnectionDispose();
            }
            catch (Exception ex)
            {
                message = string.Empty;
                LocalWriter.L_LocalLog(
                    DateTime.Now.ToLongTimeString()
                    + Environment.NewLine
                    + ex.Message
                    + Environment.NewLine
                    + ex.StackTrace
                    + Environment.NewLine
                    );
                message = $"500|{ex.Message}";
            }
        }
        public static void DalSetId(string PRAPIKEY,
                             int PRBANK_TRANSID,
                             string PREXT_ORDERID)
        {
            try
            {
                ConnectionOpen();
                _sp4.BankTrans_Update(PRAPIKEY,
                                      GetIp(),
                                      PRBANK_TRANSID,
                                      PREXT_ORDERID,
                                      out message);
                ConnectionDispose();
            }
            catch (Exception ex)
            {
                LocalWriter.L_LocalLog(
                    DateTime.Now.ToLongTimeString()
                    + Environment.NewLine
                    + ex.Message
                    + Environment.NewLine
                    + ex.StackTrace
                    + Environment.NewLine
                    );
                message = $"500|{ex.Message}";
                ConnectionDispose();
            }
        }
        public static void DalList(string APIKEY,
                                string SDATE,
                                string EDATE,
                                string BANKTRANS_ID,
                                string STATU)
        {
            _dataTable = null;
            try
            {
                ConnectionOpen();
                _sp4.BankTransList_Get_app(APIKEY,
                                          GetIp(),
                                          SDATE,
                                          EDATE,
                                          BANKTRANS_ID,
                                          STATU,
                                          out message,
                                          out _dataTable);
                ConnectionDispose();
            }
            catch (Exception ex)
            {
                LocalWriter.L_LocalLog(
                    DateTime.Now.ToLongTimeString()
                    + Environment.NewLine
                    + ex.Message
                    + Environment.NewLine
                    + ex.StackTrace
                    + Environment.NewLine
                    );
                message = $"500|{ex.Message}";
                ConnectionDispose();
            }
        }
        public static string GetStatu(string obj)
        {
            switch (obj.Split(' ')[0])
            {
                case "1":
                case "01":
                    return BankType.BEKLIYOR.ToString().Replace("_", " ");
                case "2":
                case "02":
                    return BankType.HATALI.ToString().Replace("_", " ");
                case "3":
                case "03":
                    return BankType.KAPANDI.ToString().Replace("_", " ");
                case "4":
                case "04":
                    return BankType.KORUMA_HESABINDA.ToString().Replace("_", " ");
                case "5":
                case "05":
                    return BankType.IPTAL_EDILDI.ToString().Replace("_", " ");
                case "6":
                case "06":
                    return BankType.SUPHELI.ToString().Replace("_", " ");
                case "7":
                case "07":
                    return BankType.KORUMA_HESABINDAN_IADE.ToString().Replace("_", " ");
                case "8":
                case "08":
                    return BankType.IPTAL_BEKLEMEDE.ToString().Replace("_", " ");
                case "99":
                    return BankType.DIGER_BANKA_HRK.ToString().Replace("_", " ");
                default:
                    return "Error404";
            }
        }
        private static string GetIp()
        {
            return new System.IO.StreamReader(((HttpWebResponse)((HttpWebRequest)HttpWebRequest.Create("http://185.119.82.114/ip.asp")).GetResponse()).GetResponseStream()).ReadToEnd();
        }
        private static void ConnectionOpen()
        {
            connection = new Connection(System.Web.Configuration.WebConfigurationManager.AppSettings["Connection"], "", "", "");
            _sp4 = new sp4(connection);
        }
        private static void ConnectionDispose()
        {
            if (_sp4 != null)
                _sp4.Dispose();
            if (connection != null)
                connection.Dispose();
        }
    }
}