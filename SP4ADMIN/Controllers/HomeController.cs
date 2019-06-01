using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SP4ADMIN.Models;
using sp4net.StrongTypesNS;
using static SP4ADMIN.Models.Tools;
using static SP4ADMIN.Models.DalOrder;
using static SP4ADMIN.Models.Veriables;
using static SP4ADMIN.Models.ReturnJson;
using static SP4ADMIN.Models.LocalWriter;
using System.Collections;
using System.Collections.Generic;

namespace SP4ADMIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (IsLogin(this, "api"))
            {
                return Redirect(UrlHome);
            }
            else
            {
                NameFill(this);
                return View();
            }
        }
        public ActionResult Main()
        {
            if (!IsLogin(this, "api"))
            {
                return Redirect(UrlLogin);
            }
            else
            {
                NameFill(this);
                return View();
            }
        }
        public ActionResult Main_js()
        {
            return PartialView();
        }
        public ActionResult Header()
        {
            if (!IsLogin(this, "api"))
            {
                return Redirect(UrlLogin);
            }
            else
            {
                return PartialView();
            }
        }
        public ActionResult Sidebar()
        {
            if (!IsLogin(this, "api"))
            {
                return Redirect(UrlLogin);
            }
            else
            {
                return PartialView();
            }
        }
        public ActionResult Footer()
        {
            if (!IsLogin(this, "api"))
            {
                return Redirect(UrlLogin);
            }
            else
            {
                return PartialView();
            }
        }
        public string Login(string userName, string password)
        {
            string xml = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create($"http://{Ip}/scripts/cgiip.exe/WService=wsbroker1/websrv/GetLogin.r?Uname={userName}&Pwd={password}");
                xml = new StreamReader(((HttpWebResponse)webRequest.GetResponse()).GetResponseStream()).ReadToEnd();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);
                if (xmlDocument.GetElementsByTagName("errcode").Count <= 0)
                {
                    L_LocalLog(xml);
                    return Return(StatusType.False);
                }
                else
                {
                    string Code = xmlDocument.GetElementsByTagName("errcode")[0].InnerText;
                    if (Code != "100")
                    {
                        return Return(StatusType.False, xmlDocument.GetElementsByTagName("errdesc")[0].InnerText);
                    }
                    else
                    {
                        Session["api"] = xmlDocument.GetElementsByTagName("errdesc")[0].InnerText.Split('!')[0];
                        SidebarParse();
                        return Return(StatusType.True, location: UrlHome);
                    }
                }
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
                    + xml
                    + Environment.NewLine
                    );
                return Return(StatusType.False, ex.Message);
            }

        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return Redirect(UrlLogin);
        }
        private void SidebarParse()
        {
            try
            {
                string returned = new StreamReader(((HttpWebResponse)((HttpWebRequest)WebRequest.Create(new Uri($"http://{Ip}/scripts/cgiip.exe/WService=wsbroker1/websrv/GetProgram.r?Apikey=" + Session["api"]))).GetResponse()).GetResponseStream()).ReadToEnd();
                if (returned != "")
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(returned);
                    string sideBar = "";
                    if (xmlDocument.GetElementsByTagName("PROGRAM_TTRow").Count > 0)
                    {
                        for (int a = 0; a < xmlDocument.GetElementsByTagName("PROGRAM_TTRow").Count; a++)
                        {
                            string yol = xmlDocument.GetElementsByTagName("PROGRAM_TTRow")[a]["PRGPATH"].InnerText;
                            string baslik = xmlDocument.GetElementsByTagName("PROGRAM_TTRow")[a]["PRGTITLE"].InnerText;
                            sideBar += $@"<li><a href={'"'}{yol}{'"'}><i class={'"'}fa fa-circle{'"'}></i><span>{baslik}</span></a></li>";
                        }
                        SideBarHTML = sideBar;
                    }
                }
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
            }
        }
        public string GetCounts()
        {
            //System.Threading.Thread.Sleep(20000);
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, UrlLogin);
            }
            else
            {
                try
                {
                    DalOrder.DalList(Session["api"].ToString(),
                                     DateTime.Now.ToString("yyy-MM-dd"),
                                     DateTime.Now.ToString("yyy-MM-dd"),
                                     "",
                                     "",
                                     "",
                                     "",
                                     "",
                                     "",
                                     "",
                                     "");
                    if (!DalOrder.DalMessage.StartsWith("100"))
                    {
                        return Return(StatusType.False, SplitPipe(DalOrder.DalMessage));
                    }
                    else
                    {
                        int waitOrder = 0, errorOrder = 0, closedOrder = 0, reconciliationOrder = 0;
                        DalOrder.DalDataTable.AsEnumerable().ToList().ForEach(Row =>
                        {
                            ORDERBC_TTRow row = Row as ORDERBC_TTRow;
                            if (row.Statu.StartsWith("01"))
                                waitOrder++;
                            else if (row.Statu.StartsWith("02"))
                                errorOrder++;
                            else if (row.Statu.StartsWith("03"))
                                closedOrder++;
                            else if (row.Statu.StartsWith("09"))
                                reconciliationOrder++;
                        });
                        return Return(StatusType.True, new
                        {
                            waitOrder,
                            errorOrder,
                            closedOrder,
                            reconciliationOrder
                        }, "Güncellendi");
                    }
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
                    return Return(StatusType.False, ex.Message);
                }
            }
        }
        public string GetReport(string startDate, string endDate)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (startDate is null || endDate is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    string htmlTable = string.Empty;
                    DalList(Session["api"].ToString(), startDate, endDate, "", "", "", "", "", "", "", "");
                    if (!DalMessage.StartsWith("100"))
                    {
                        return Return(StatusType.False, SplitPipe(DalMessage));
                    }
                    else
                    {
                        try
                        {
                            var responseList = from row in DalDataTable.AsEnumerable()
                                               orderby (row as ORDERBC_TTRow).cdate
                                               select row;
                            var dataTable = responseList.ToList();
                            bool IsNewDate = true;
                            DateTime lastDate = (dataTable[0] as ORDERBC_TTRow).cdate;
                            List<ReportColumn> reportColumns = new List<ReportColumn>();
                            for (int a = 0; a < dataTable.Count; a++)
                            {
                                ORDERBC_TTRow currentRow = dataTable[a] as ORDERBC_TTRow;
                                ReportColumn currentColumn = new ReportColumn()
                                {
                                    Id = currentRow.Statu.Split(' ')[0],
                                    Name = currentRow.Statu.Split(' ')[1],
                                    Amount = currentRow.GrandTotal,
                                    Piece = 1
                                };
                                var oldColumn = reportColumns.FirstOrDefault(row => row.Id == currentColumn.Id) as ReportColumn;
                                bool hasStatus = oldColumn is null ? false : true;
                                if (dataTable.Count == 1)
                                {
                                    ReportColumn currentReport = currentColumn;
                                    htmlTable += $@"
<thead>
    <tr>
        <th class={'"'}datecolor{'"'} colspan={'"'}3{'"'}>{currentRow.cdate.ToShortDateString()} Tarihine ait kayıtlar</th>
    </tr>
    <tr>
        <th scope={'"'}col{'"'}>Statu</th>
        <th scope={'"'}col{'"'}>Adet</th>
        <th scope={'"'}col{'"'}>Tutar</th>
    </tr>
</thead>
<tbody>
<tr>
<td>{currentReport.Name}</td>
<td>{currentReport.Piece}</td>
<td>{currentReport.Amount}</td>
</tr>
</tbody>";
                                }
                                else
                                {
                                    if (hasStatus)
                                    {
                                        reportColumns.ForEach((column) =>
                                        {
                                            if (column == oldColumn)
                                            {
                                                column.Amount += currentColumn.Amount;
                                                column.Piece += currentColumn.Piece;
                                            }
                                        });
                                    }
                                    else
                                    {
                                        reportColumns.Add(currentColumn);
                                    }
                                    if (lastDate != currentRow.cdate || (a + 1) == dataTable.Count)
                                    {
                                        if ((a + 1) != dataTable.Count)
                                        {
                                            IsNewDate = true;
                                        }
                                        for (int b = 0; b < reportColumns.Count; b++)
                                        {
                                            ReportColumn currentReport = reportColumns[b];
                                            htmlTable += $@"
<tr>
<td>{currentReport.Name}</td>
<td>{currentReport.Piece}</td>
<td>{currentReport.Amount}</td>
</tr>
";
                                        }
                                        reportColumns.Clear();
                                    }
                                    if (IsNewDate)
                                    {
                                        IsNewDate = false;
                                        lastDate = currentRow.cdate;
                                        if (a != 0)
                                        {
                                            htmlTable += "</tbody>";
                                        }
                                        htmlTable += $@"
<thead>
    <tr>
        <th class={'"'}datecolor{'"'} colspan={'"'}3{'"'}>{currentRow.cdate.ToShortDateString()} Tarihine ait kayıtlar</th>
    </tr>
    <tr>
        <th scope={'"'}col{'"'}>Statu</th>
        <th scope={'"'}col{'"'}>Adet</th>
        <th scope={'"'}col{'"'}>Tutar</th>
    </tr>
</thead>
<tbody>";
                                    }
                                }
                            }
                            return Return(StatusType.True, new
                            {
                                Table = htmlTable
                            }, text: "Listelendi");
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
                            return Return(StatusType.False, ex.Message);
                        }
                    }
                }
            }
        }
    }

    class ReportColumn
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Piece { get; set; }
        public decimal Amount { get; set; }
    }
}