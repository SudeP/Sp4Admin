using System.Web.Mvc;
using SP4ADMIN.Models;
using System.Linq;
using sp4net.StrongTypesNS;
using static SP4ADMIN.Models.Tools;
using static SP4ADMIN.Models.ReturnJson;
using static SP4ADMIN.Models.DalCustomer;
using System;
using System.Data;

namespace SP4ADMIN.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            if (!IsLogin(this, "api"))
            {
                return Redirect(UrlLogin);
            }
            else
            {
                Veriables.ListItem(Session["api"].ToString());
                ViewBag.Item = Veriables.ItemDataTable;
                NameFill(this);
                return View();
            }
        }
        public ActionResult Customer_js()
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
        public string List(string bastar,
                   string bittar,
                   string RetailNum,
                   string RetailName,
                   string Gsm,
                   string Statu)
        {
            string Table = "";
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (bastar is null
                    || bittar is null
                    || RetailNum is null
                    || RetailName is null
                    || Gsm is null
                    || Statu is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    DalList(Session["api"].ToString(),
                                   bastar,
                                   bittar,
                                   RetailNum,
                                   RetailName,
                                   Gsm,
                                   Statu);
                    if (!DalMessage.StartsWith("100"))
                    {
                        return Return(StatusType.False, SplitPipe(DalMessage));
                    }
                    else
                    {
                        try
                        {
                            RETAIL_TTDataTable dataTable = DalDataTable;
                            Table +=
                            $@"
                                <thead>
                                    <tr>
                                        <th>İşlemler</th>
                                        <th>{dataTable.RetailNumColumn.Caption}</th>
                                        <th>{dataTable.NameColumn.Caption}</th>
                                        <th>{dataTable.GsmColumn.Caption}</th>
                                        <th>{dataTable.OrdNewCountColumn.Caption}</th>
                                        <th>{dataTable.OrdWaitCountColumn.Caption}</th>
                                    </tr>
                                </thead>
                                <tbody>
                        ";
                            if (dataTable != null)
                                for (int a = 0; a < dataTable.Count; a++)
                                {
                                    RETAIL_TTRow currentRow = dataTable.Rows[a] as RETAIL_TTRow;
                                    Table += $@"<tr class={'"'}gradeX{'"'} id={'"'}{currentRow.RetailNum}{'"'}><td>";
                                    if (currentRow.Statu.ToString().ToLower() == "true")
                                    {
                                        Table +=
                                         $@"
                                 <input type={'"'}button{'"'} class={'"'}btn btn-success{'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupAreaOrder{'"'} onclick={'"'}NewPopupOrder('{currentRow.Name}','{currentRow.RetailNum}');{'"'} value={'"'}Sip. Ekle{'"'}/>
                                 <input type={'"'}button{'"'} class={'"'}btn btn-primary {'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupArea{'"'} onclick={'"'}GetDetail({currentRow.CorpNum},{currentRow.CustNum},{currentRow.RetailNum},'update');{'"'} value={'"'}Düzenle{'"'}/>
                                 ";

                                        /*
                                        <input type={'"'}button{'"'} class={'"'}btn btn-danger {'"'} onclick={'"'}DeActive({currentRow.CorpNum},{currentRow.CustNum},{currentRow.RetailNum});{'"'} value={'"'}Pasife Çek{'"'}/>
                                     */
                                    }
                                    else
                                    {
                                        Table +=
                                         $@"
                                 <button type={'"'}button{'"'} class={'"'}btn btn-primary {'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupArea{'"'} onclick={'"'}GetDetail({currentRow.CorpNum},{currentRow.CustNum},{currentRow.RetailNum},'detail');{'"'}>
                                 İncele
                                 </button>";
                                        /*
                                 <input type={'"'}button{'"'} class={'"'}btn btn-success {'"'} onclick={'"'}Active({currentRow.CorpNum},{currentRow.CustNum},{currentRow.RetailNum});{'"'} value={'"'}Aktife Çek{'"'}/>
                                     */
                                    }
                                    Table += $@"
                                 <input type={'"'}button{'"'} class={'"'}btn btn-info{'"'} onclick={'"'}Conserve({currentRow.RetailNum});{'"'} value={'"'}Tüm Sip.{'"'}/>
                                </td>
                                <td>{currentRow.RetailNum}</td>
                                <td>{currentRow.Name}</td>
                                <td>{currentRow.Gsm}</td>
                                <td id='new'>{currentRow.OrdNewCount}</td>
                                <td>{currentRow.OrdWaitCount}</td>
                                </tr>";
                                }
                            Table += "</tbody>";
                            return Return(StatusType.True, new { Table, DalDataTable.Rows.Count }, "Listelendi");
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
        public string Get(string corp,
                          string cust,
                          string retail)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (corp is null
                    || cust is null
                    || retail is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        RETAIL_TTRow ttrow = DalDataTable.FindByCorpNumCustNumRetailNum(int.Parse(corp), int.Parse(cust), int.Parse(retail));
                        if (ttrow is null)
                        {
                            return Return(StatusType.False, "Bulunamadı");
                        }
                        else
                        {
                            return Return(
                                StatusType.True,
                                new
                                {
                                    ttrow.CorpNum,
                                    ttrow.CustNum,
                                    ttrow.RetailNum,
                                    ttrow.Name,
                                    ttrow.CustCode,
                                    ttrow.BankTransKey,
                                    ttrow.Contact,
                                    ttrow.CustType,
                                    ttrow.Terms,
                                    ttrow.Address,
                                    ttrow.CityCode,
                                    ttrow.CountryCode,
                                    ttrow.City,
                                    ttrow.Country,
                                    ttrow.State,
                                    ttrow.CountyName,
                                    ttrow.PostalCode,
                                    ttrow.Email,
                                    ttrow.Phone,
                                    ttrow.Gsm,
                                    ttrow.Fax,
                                    ttrow.BankCode,
                                    ttrow.iban,
                                    ttrow.TaxOffice,
                                    ttrow.TaxNo,
                                    ttrow.Comments
                                });
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
        public string Active(string corp,
                             string cust,
                             string retail)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (corp is null
                    || cust is null
                    || retail is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        RETAIL_TTRow ttrow = DalDataTable.FindByCorpNumCustNumRetailNum(int.Parse(corp), int.Parse(cust), int.Parse(retail));
                        if (ttrow is null)
                        {
                            return Return(StatusType.False, "Bulunamadı.");
                        }
                        else
                        {
                            ttrow.recSt = "U";
                            ttrow.Statu = true;
                            DalSet(Session["api"].ToString(), RowToNewTable(ttrow));
                            return Return(StatusType.True, "Aktif edildi");
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
        public string DeActive(string corp,
                               string cust,
                               string retail)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (corp is null
                    || cust is null
                    || retail is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        RETAIL_TTRow ttrow = DalDataTable.FindByCorpNumCustNumRetailNum(int.Parse(corp), int.Parse(cust), int.Parse(retail));
                        if (ttrow is null)
                        {
                            return Return(StatusType.False, "Bulunamadı.");
                        }
                        else
                        {
                            ttrow.recSt = "D";
                            ttrow.Statu = false;
                            DalSet(Session["api"].ToString(), RowToNewTable(ttrow));
                            return Return(StatusType.True, "Pasif edildi");
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
        public string New(string Name,
                          string CustCode,
                          string BankTransKey,
                          string Contact,
                          string CustType,
                          string Terms,
                          string Address1,
                          string Address2,
                          string CityCode,
                          string CountryCode,
                          string Country,
                          string County,
                          string City,
                          string State,
                          string BankCode,
                          string Postal,
                          string Email,
                          string Phone,
                          string Gsm,
                          string Fax,
                          string iban,
                          string Tax,
                          string TaxNo,
                          string Comments)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (Name is null
                    || CustCode is null
                    || BankTransKey is null
                    || Contact is null
                    || CustType is null
                    || Terms is null
                    || Address1 is null
                    || Address2 is null
                    || CityCode is null
                    || CountryCode is null
                    || Country is null
                    || County is null
                    || City is null
                    || State is null
                    || BankCode is null
                    || Postal is null
                    || Email is null
                    || Phone is null
                    || Gsm is null
                    || Fax is null
                    || iban is null
                    || Tax is null
                    || TaxNo is null
                    || Comments is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    try
                    {
                        RETAIL_TTDataTable dataTable = new RETAIL_TTDataTable();
                        RETAIL_TTRow row = dataTable.NewRETAIL_TTRow();
                        /*New */
                        row.Name = Name;
                        row.CustCode = CustCode;
                        row.BankTransKey = BankTransKey;
                        row.Contact = Contact;
                        row.CustType = CustType;
                        row.Terms = Terms;
                        row.Address = Address1;
                        row.Address2 = Address2;
                        row.CountryCode = CountryCode;
                        row.CityCode = CityCode;
                        row.Country = Country;
                        row.CountyName = County;
                        row.City = City;
                        row.State = State;
                        row.PostalCode = Postal;
                        row.Email = Email;
                        row.Phone = Phone;
                        row.Gsm = Gsm;
                        row.Fax = Fax;
                        row.BankCode = BankCode;
                        row.iban = iban;
                        row.TaxOffice = Tax;
                        row.TaxNo = TaxNo;
                        row.Comments = Comments;
                        row.recSt = "N";
                        /*New */
                        /*Old */
                        row.CorpNum = 0;
                        row.RetailNum = 0;
                        row.CurrAcctid = 0;
                        row.Discount = 0;
                        row.Balance = 0;
                        row.QueryCharge = 0;
                        row.ServiceCharge = 0;
                        row.PosRate = 0;
                        row.CreditLimit = 0;
                        row.CustNum = 0;
                        row.CountyCode = "";
                        row.Phone2 = "";
                        row.SalesRep = "";
                        row.CurrAcct = "";
                        row.ChannelCode = "";
                        row.ShortCut = "";
                        row.Statu = true;
                        /*Old */
                        dataTable.Rows.Add(row);
                        DalSet(Session["api"].ToString(), dataTable);
                        if (!DalMessage.StartsWith("100"))
                        {
                            return Return(StatusType.False, SplitPipe(DalMessage));
                        }
                        else
                        {
                            return Return(StatusType.True, "Oluşturuldu");
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
        public string Update(string Name,
                             string CustCode,
                             string BankTransKey,
                             string Contact,
                             string CustType,
                             string Terms,
                             string Address1,
                             string Address2,
                             string CityCode,
                             string CountryCode,
                             string Country,
                             string County,
                             string City,
                             string State,
                             string BankCode,
                             string Postal,
                             string Email,
                             string Phone,
                             string Gsm,
                             string Fax,
                             string iban,
                             string Tax,
                             string TaxNo,
                             string Comments,
                             string CorpNum,
                             string CustNum,
                             string RetailNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: "/Home/Index");
            }
            else
            {
                if (CorpNum is null
                    || CustNum is null
                    || RetailNum is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                RETAIL_TTRow oldRow = DalDataTable.FindByCorpNumCustNumRetailNum(int.Parse(CorpNum), int.Parse(CustNum), int.Parse(RetailNum));
                if (oldRow is null)
                {
                    return Return(StatusType.False, "Bulunamadı");
                }
                else
                {
                    if (Name is null
                        || CustCode is null
                        || BankTransKey is null
                        || Contact is null
                        || CustType is null
                        || Terms is null
                        || Address1 is null
                        || Address2 is null
                        || CityCode is null
                        || CountryCode is null
                        || Country is null
                        || County is null
                        || City is null
                        || State is null
                        || BankCode is null
                        || Postal is null
                        || Email is null
                        || Phone is null
                        || Gsm is null
                        || Fax is null
                        || iban is null
                        || Tax is null
                        || TaxNo is null
                        || Comments is null)
                    {
                        return Return(StatusType.False, "Hatalı alan");
                    }
                    else
                    {
                        try
                        {
                            RETAIL_TTDataTable dataTable = new RETAIL_TTDataTable();
                            RETAIL_TTRow row = dataTable.NewRETAIL_TTRow();
                            /*New */
                            row.Name = Name;
                            row.CustCode = CustCode;
                            row.BankTransKey = BankTransKey;
                            row.Contact = Contact;
                            row.CustType = CustType;
                            row.Terms = Terms;
                            row.Address = Address1;
                            row.Address2 = Address2;
                            row.CountryCode = CountryCode;
                            row.CityCode = CityCode;
                            row.Country = Country;
                            row.CountyName = County;
                            row.City = City;
                            row.State = State;
                            row.PostalCode = Postal;
                            row.Email = Email;
                            row.Phone = Phone;
                            row.Gsm = Gsm;
                            row.Fax = Fax;
                            row.BankCode = BankCode;
                            row.iban = iban;
                            row.TaxOffice = Tax;
                            row.TaxNo = TaxNo;
                            row.Comments = Comments;
                            row.recSt = "U";
                            /*New */
                            /*Old */
                            row.CountyCode = oldRow.CountyCode;
                            row.CorpNum = oldRow.CorpNum;
                            row.RetailNum = oldRow.RetailNum;
                            row.CustNum = oldRow.CustNum;
                            row.Phone2 = oldRow.Phone2;
                            row.SalesRep = oldRow.SalesRep;
                            row.CurrAcct = oldRow.CurrAcct;
                            row.CurrAcctid = oldRow.CurrAcctid;
                            row.Balance = oldRow.Balance;
                            row.Discount = oldRow.Discount;
                            row.ServiceCharge = oldRow.ServiceCharge;
                            row.QueryCharge = oldRow.QueryCharge;
                            row.PosRate = oldRow.PosRate;
                            row.ChannelCode = oldRow.ChannelCode;
                            row.ShortCut = oldRow.ShortCut;
                            row.CreditLimit = oldRow.CreditLimit;
                            row.Statu = oldRow.Statu;
                            row.Cdate = oldRow.Cdate;
                            /*Old */
                            dataTable.Rows.Add(row);
                            DalSet(Session["api"].ToString(), dataTable);
                            if (!DalMessage.StartsWith("100"))
                            {
                                return Return(StatusType.False, SplitPipe(DalMessage));
                            }
                            else
                            {
                                return Return(StatusType.True, "Güncellendi");
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
        public string Conserve(int? RetailNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: "/Order/Index");
            }
            else
            {
                if (RetailNum is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        Veriables.RetailNum = RetailNum;
                        return Return(StatusType.True, location: "/Order/Index");
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