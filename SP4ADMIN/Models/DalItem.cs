using System;
using System.Net;
using sp4net;
using sp4net.StrongTypesNS;
using Progress.Open4GL.Proxy;

namespace SP4ADMIN.Models
{
    public class DalItem
    {
        private static sp4 _sp4;
        private static Connection connection;
        private static string message;
        private static ITEM_TTDataTable _dataTable = new ITEM_TTDataTable();
        public static string DalMessage => message;
        public static ITEM_TTDataTable DalDataTable
        {
            get
            {
                return _dataTable;
            }
        }
        public static void DalSet(string apikey, ITEM_TTDataTable dataTable)
        {
            try
            {
                ConnectionOpen();
                _sp4.item_Set_app(apikey,
                                 GetIp(),
                                 dataTable,
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
        public static void DalList(string apikey,
                                string sdate,
                                string edate,
                                string itemNum,
                                string itemName,
                                string Category1,
                                string Category2,
                                string statu)
        {
            _dataTable = null;
            try
            {
                ConnectionOpen();
                _sp4.itemList_get_app(apikey,
                                     GetIp(),
                                     sdate,
                                     edate,
                                     itemNum,
                                     Category1,
                                     Category2,
                                     itemName,
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
        public static ITEM_TTDataTable RowToNewTable(ITEM_TTRow row)
        {
            ITEM_TTDataTable dataTable = new ITEM_TTDataTable();
            ITEM_TTRow defaultrow = dataTable.NewRow() as ITEM_TTRow;
            defaultrow.ItemName = row.ItemName;
            defaultrow.itemCode = row.itemCode;
            defaultrow.Category1 = row.Category1;
            defaultrow.Category2 = row.Category2;
            defaultrow.Price = row.Price;
            defaultrow.DiscRate = row.DiscRate;
            defaultrow.TaxRate = row.TaxRate;
            defaultrow.Weight = row.Weight;
            defaultrow.qty = row.qty;
            defaultrow.Allocated = row.Allocated;
            defaultrow.Onhand = row.Onhand;
            defaultrow.Minqty = row.Minqty;
            defaultrow.ReOrder = row.ReOrder;
            defaultrow.OnOrder = row.OnOrder;
            defaultrow.BackOrder = row.BackOrder;
            defaultrow.Barcode = row.Barcode;
            defaultrow.BuyeritemCode = row.BuyeritemCode;
            defaultrow.CargoCampCode = row.CargoCampCode;
            defaultrow.Special = row.Special;
            defaultrow.itemDesc = row.itemDesc;
            defaultrow.itemUrl = row.itemUrl;
            defaultrow.CorpNum = row.CorpNum;
            defaultrow.CustNum = row.CustNum;
            defaultrow.Cdate = row.Cdate;
            defaultrow.Udate = row.Udate;
            defaultrow.UpdUser = row.UpdUser;
            defaultrow.recSt = row.recSt;
            defaultrow.Statu = row.Statu;
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