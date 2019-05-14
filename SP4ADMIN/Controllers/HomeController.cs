using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Web.Mvc;
using static SP4ADMIN.Models.Tools;
using static SP4ADMIN.Models.Veriables;
using static SP4ADMIN.Models.ReturnJson;
using static SP4ADMIN.Models.LocalWriter;
using SP4ADMIN.Models;
using System.Data;
using System.Linq;
using sp4net.StrongTypesNS;

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
                        return Return(StatusType.True, location: "/Home/Main");
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
            string returned = string.Empty;
            try
            {
                returned = new StreamReader(((HttpWebResponse)((HttpWebRequest)WebRequest.Create(new Uri($"http://{Ip}/scripts/cgiip.exe/WService=wsbroker1/websrv/GetProgram.r?Apikey=" + Session["api"]))).GetResponse()).GetResponseStream()).ReadToEnd();
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
                        int waitOrder = 0,errorOrder = 0,closedOrder = 0, reconciliationOrder = 0;
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
    }
}