using Progress.Open4GL.Proxy;
using sp4net;
using sp4net.StrongTypesNS;
using System;
using System.Net;

namespace SP4ADMIN.Models
{
    public class DalOrder
    {
        public enum OrderType
        {
            BEKLIYOR = 01,
            HATALI = 02,
            KAPANDI = 03,
            KORUMA_HESABINDA = 04,
            IPTAL_EDILDI = 05,
            SUPHELI = 06,
            KORUMA_HESABINDAN_IADE = 07,
            MUTABAKATA_ALINDI = 09
        }
        private static sp4 _sp4;
        private static Connection connection;
        private static string message;
        private static ORDERBC_TTDataTable _dataTable = new ORDERBC_TTDataTable();
        public static string DalMessage => message;
        public static ORDERBC_TTDataTable DalDataTable => _dataTable;
        public static void DalSet(string apikey,
                       ORDERBC_TTDataTable dataTable)
        {
            try
            {
                ConnectionOpen();
                _sp4.OrderBc_Set_app(apikey, GetIp(), dataTable, out message);
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
                ConnectionDispose();
            }
        }
        public static void DalList(string apikey,
                                string sdate,
                                string edate,
                                string PRORDERBC_NUM,
                                string PRRETAIL_NUM,
                                string PRSIPARIS_ID,
                                string PRMUSTERI_ID,
                                string PRNAME,
                                string PRSIPARIS_STATU,
                                string PRSTATU,
                                string PRDELST)
        {
            _dataTable = null;
            try
            {
                ConnectionOpen();
                _sp4.OrderBcList_Get_app(apikey,
                                        GetIp(),
                                        sdate,
                                        edate,
                                        PRORDERBC_NUM,
                                        PRRETAIL_NUM,
                                        PRSIPARIS_ID,
                                        PRMUSTERI_ID,
                                        PRNAME,
                                        PRSIPARIS_STATU,
                                        PRSTATU,
                                        PRDELST,
                                        out message,
                                        out _dataTable);
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
        public static void DalSetPrivate(string api_key,
                                         int order_id,
                                         string update_st,
                                         decimal amount,
                                         out int resp_code)
        {
            resp_code = -1;
            try
            {
                ConnectionOpen();
                _sp4.OrderBcStatuUpd(api_key,
                                     GetIp(),
                                     order_id,
                                     update_st,
                                     amount,
                                     out resp_code,
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
        public static ORDERBC_TTDataTable RowToNewTable(ORDERBC_TTRow row)
        {
            ORDERBC_TTDataTable dataTable = new ORDERBC_TTDataTable();
            ORDERBC_TTRow defaultrow = dataTable.NewRow() as ORDERBC_TTRow;
            defaultrow.CorpNum = row.CorpNum;
            defaultrow.CustNum = row.CustNum;
            defaultrow.cdate = row.cdate;
            defaultrow.OrderBcNum = row.OrderBcNum;
            defaultrow.RetailNum = row.RetailNum;
            defaultrow.Err_code = row.Err_code;
            defaultrow.Siparis_id = row.Siparis_id;
            defaultrow.BankSiparis_id = row.BankSiparis_id;
            defaultrow.Musteri_id = row.Musteri_id;
            defaultrow.Tutar = row.Tutar;
            defaultrow.TaxRate1 = row.TaxRate1;
            defaultrow.TaxRate2 = row.TaxRate2;
            defaultrow.Toplam_tutar = row.Toplam_tutar;
            defaultrow.CostAmt = row.CostAmt;
            defaultrow.CostType = row.CostType;
            defaultrow.CostRate = row.CostRate;
            defaultrow.CustTransAmt = row.CustTransAmt;
            defaultrow.Aciklama = row.Aciklama;
            defaultrow.Musteri_adi = row.Musteri_adi;
            defaultrow.Telefon = row.Telefon;
            defaultrow.Fatura_no = row.Fatura_no;
            defaultrow.Siparis_Statu = row.Siparis_Statu;
            defaultrow.Olusturma_zamani = row.Olusturma_zamani;
            defaultrow.OlusturmaTrh = row.OlusturmaTrh;
            defaultrow.xml_resp = row.xml_resp;
            defaultrow.ctime = row.ctime;
            defaultrow.BankTransID = row.BankTransID;
            defaultrow.Lineno = row.Lineno;
            defaultrow.SysNote = row.SysNote;
            defaultrow.Statu = row.Statu;
            defaultrow.prm1 = row.prm1;
            defaultrow.prm2 = row.prm2;
            defaultrow.prm3 = row.prm3;
            defaultrow.prm4 = row.prm4;
            defaultrow.Udate = row.Udate;
            defaultrow.CrtUser = row.CrtUser;
            defaultrow.UpdUser = row.UpdUser;
            defaultrow.recSt = row.recSt;
            defaultrow.delst = row.delst;
            defaultrow.RetailName = row.RetailName;
            defaultrow.itemCode = row.itemCode;
            defaultrow.ItemName = row.ItemName;
            defaultrow.qty = row.qty;
            defaultrow.Price = row.Price;
            defaultrow.TaxAmt1 = row.TaxAmt1;
            defaultrow.TaxAmt2 = row.TaxAmt2;
            defaultrow.TotalPrice = row.TotalPrice;
            defaultrow.GrandTotal = row.GrandTotal;
            defaultrow.ExtOrderID = row.ExtOrderID;
            defaultrow.RecCount = row.RecCount;
            dataTable.Rows.Add(defaultrow);
            return dataTable;
        }
        public static string GetStatu(string obj)
        {
            switch (obj.Split(' ')[0])
            {
                case "1":
                case "01":
                    return OrderType.BEKLIYOR.ToString().Replace("_", " ");
                case "2":
                case "02":
                    return OrderType.HATALI.ToString().Replace("_", " ");
                case "3":
                case "03":
                    return OrderType.KAPANDI.ToString().Replace("_", " ");
                case "4":
                case "04":
                    return OrderType.KORUMA_HESABINDA.ToString().Replace("_", " ");
                case "5":
                case "05":
                    return OrderType.IPTAL_EDILDI.ToString().Replace("_", " ");
                case "6":
                case "06":
                    return OrderType.SUPHELI.ToString().Replace("_", " ");
                case "7":
                case "07":
                    return OrderType.KORUMA_HESABINDAN_IADE.ToString().Replace("_", " ");
                case "9":
                case "09":
                    return OrderType.MUTABAKATA_ALINDI.ToString().Replace("_", " ");
                default:
                    return "Error404";
            }
        }
        private static string GetIp()
        {
            return new System.IO.StreamReader(((HttpWebResponse)((HttpWebRequest)WebRequest.Create("http://185.119.82.114/ip.asp")).GetResponse()).GetResponseStream()).ReadToEnd();
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