using Progress.Open4GL.Proxy;
using sp4net;
using sp4net.StrongTypesNS;
using System.Net;
using System;

namespace SP4ADMIN.Models
{
    public class DalCustomer
    {
        private static sp4 _sp4;
        private static Connection connection;
        private static string message;
        private static RETAIL_TTDataTable _dataTable = new RETAIL_TTDataTable();
        public static string DalMessage => message;
        public static RETAIL_TTDataTable DalDataTable
        {
            get
            {
                return _dataTable;
            }
        }
        public static void DalSet(string apikey, RETAIL_TTDataTable dataTable)
        {
            try
            {
                ConnectionOpen();
                _sp4.CustRetail_Set_app(apikey, GetIp(), dataTable, out message);
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
        public static void DalList(string apikey,
                                string sdate,
                                string edate,
                                string retailnum,
                                string name,
                                string gsm,
                                string statu)
        {
            _dataTable = null;
            try
            {
                ConnectionOpen();
                _sp4.CustRetailList_Get_app(apikey,
                                           GetIp(),
                                           sdate,
                                           edate,
                                           retailnum,
                                           name,
                                           gsm,
                                           statu,
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
        public static RETAIL_TTDataTable RowToNewTable(RETAIL_TTRow row)
        {
            RETAIL_TTDataTable dataTable = new RETAIL_TTDataTable();
            RETAIL_TTRow defaultrow = dataTable.NewRow() as RETAIL_TTRow;
            defaultrow.Statu = row.Statu;
            defaultrow.Name = row.Name;
            defaultrow.CustCode = row.CustCode;
            defaultrow.BankTransKey = row.BankTransKey;
            defaultrow.Contact = row.Contact;
            defaultrow.CustType = row.CustType;
            defaultrow.Terms = row.Terms;
            defaultrow.Address = row.Address;
            defaultrow.Address2 = row.Address2;
            defaultrow.CityCode = row.CityCode;
            defaultrow.CountryCode = row.CountryCode;
            defaultrow.Country = row.Country;
            defaultrow.CountyName = row.CountyName;
            defaultrow.City = row.City;
            defaultrow.State = row.State;
            defaultrow.PostalCode = row.PostalCode;
            defaultrow.Email = row.Email;
            defaultrow.Phone = row.Phone;
            defaultrow.Phone2 = row.Phone2;
            defaultrow.Gsm = row.Gsm;
            defaultrow.Fax = row.Fax;
            defaultrow.iban = row.iban;
            defaultrow.TaxOffice = row.TaxOffice;
            defaultrow.TaxNo = row.TaxNo;
            defaultrow.Comments = row.Comments;
            defaultrow.recSt = row.recSt;
            defaultrow.CorpNum = row.CorpNum;
            defaultrow.RetailNum = row.RetailNum;
            defaultrow.CustNum = row.CustNum;
            defaultrow.Cdate = row.Cdate;
            defaultrow.SalesRep = row.SalesRep;
            defaultrow.CurrAcct = row.CurrAcct;
            defaultrow.CurrAcctid = row.CurrAcctid;
            defaultrow.Balance = row.Balance;
            defaultrow.Discount = row.Discount;
            defaultrow.ServiceCharge = row.ServiceCharge;
            defaultrow.QueryCharge = row.QueryCharge;
            defaultrow.PosRate = row.PosRate;
            defaultrow.ChannelCode = row.ChannelCode;
            defaultrow.BankCode = row.BankCode;
            defaultrow.ShortCut = row.ShortCut;
            defaultrow.Phone2 = row.Phone2;
            defaultrow.CreditLimit = row.CreditLimit;
            dataTable.Rows.Add(defaultrow);
            return dataTable;
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