using sp4net.StrongTypesNS;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SP4ADMIN.Models;
using static SP4ADMIN.Models.DalOrder;
using static SP4ADMIN.Models.ReturnJson;
using static SP4ADMIN.Models.Tools;
using static SP4ADMIN.Models.Veriables;

namespace SP4ADMIN.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string status)
        {
            ViewBag.status = status?.Replace("0","");
            if (!IsLogin(this, "api"))
            {
                return Redirect(UrlLogin);
            }
            else
            {
                // STATİC MÜŞTERİ ÇEKME ALANI (Dynamic çağıralabilmesi için kapandı.)
                //ListCust(Session["api"].ToString());
                //if (RetailMessage is null || !RetailMessage.StartsWith("100"))
                //    return Redirect(UrlHome);
                //else
                //    ViewBag.Cust = RetailDataTable;
                ListItem(Session["api"].ToString());
                ViewBag.Item = ItemDataTable;
                NameFill(this);
                return View();
            }
        }
        public ActionResult Order_js()
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
        [Trace("runtime")]
        public string List(string bastar,
                   string bittar,
                   string OrderBCNum,
                   string Siparisid,
                   string Musteriid,
                   string PRNAME,
                   string SiparisStatu,
                   string Statu,
                   string PRDELST)
        {
            string Table = "";
            decimal qty = 0, Price = 0, TotalPrice = 0, GrandTotal = 0, /*TaxRate2 = 0,*/ TaxAmt2 = 0, CostAmt = 0, CustTransAmt = 0, /*CostRate = 0,*/ Tutar = 0, Toplam_tutar = 0;
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (bastar is null || bittar is null || OrderBCNum is null || Siparisid is null ||
                    Musteriid is null || PRNAME is null || SiparisStatu is null || Statu is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    DalList(Session["api"].ToString(), bastar, bittar, OrderBCNum,
                        Musteriid, Siparisid, "", PRNAME, SiparisStatu, Statu, PRDELST);
                    if (!DalMessage.StartsWith("100"))
                    {
                        return Return(StatusType.False, SplitPipe(DalMessage));
                    }
                    else
                    {
                        try
                        {
                            ORDERBC_TTDataTable dataTable = DalDataTable;
                            Table += $@"
                            <thead>
                                <tr>
                                    <th>İşlemler</th>
                                    <th>{dataTable.ExtOrderIDColumn.Caption}</th>
                                    <th>{dataTable.RetailNameColumn.Caption}</th>
                                    <th>{dataTable.GrandTotalColumn.Caption}</th>
                                    <th>{dataTable.StatuColumn.Caption}</th>
                                    <th>{dataTable.Err_codeColumn.Caption}</th>
                                    <th>{dataTable.OrderBcNumColumn.Caption}</th>
                                    <th>{dataTable.RetailNumColumn.Caption}</th>
                                    <th>{dataTable.ctimeColumn.Caption}</th>
                                    <th>{dataTable.itemCodeColumn.Caption}</th>
                                    <th>{dataTable.ItemNameColumn.Caption}</th>
                                    <th>{dataTable.qtyColumn.Caption}</th>
                                    <th>{dataTable.PriceColumn.Caption}</th>
                                    <th>{dataTable.TotalPriceColumn.Caption}</th>
                                    <th>{dataTable.TaxRate2Column.Caption}</th>
                                    <th>{dataTable.TaxAmt2Column.Caption}</th>
                                    <th>{dataTable.CostAmtColumn.Caption}</th>
                                    <th>{dataTable.CustTransAmtColumn.Caption}</th>
                                    <th>{dataTable.CostTypeColumn.Caption}</th>
                                    <th>{dataTable.CostRateColumn.Caption}</th>
                                    <th>{dataTable.BankTransIDColumn.Caption}</th>
                                    <th>{dataTable.BankSiparis_idColumn.Caption}</th>
                                    <th>{dataTable.Musteri_idColumn.Caption}</th>
                                    <th>{dataTable.Musteri_adiColumn.Caption}</th>
                                    <th>{dataTable.Siparis_StatuColumn.Caption}</th>
                                    <th>{dataTable.TutarColumn.Caption}</th>
                                    <th>{dataTable.Toplam_tutarColumn.Caption}</th>
                                    <th>{dataTable.AciklamaColumn.Caption}</th>
                                    <th>{dataTable.SysNoteColumn.Caption}</th>
                                </tr>
                            </thead>
                            <tbody>
                        ";
                            for (int a = 0; a < dataTable.Count; a++)
                            {
                                ORDERBC_TTRow currentRow = dataTable.Rows[a] as ORDERBC_TTRow;
                                Table += $"<tr class={'"'}gradeX{'"'}><td>";
                                if (currentRow.Statu.ToString().ToLower().StartsWith("03") == false && currentRow.Statu.ToString().ToLower().StartsWith("09") == false)
                                {
                                    Table += $@"
                                <input type={'"'}button{'"'} class={'"'}btn btn-success{'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupFast{'"'} onclick={'"'}GetDetailFast({currentRow.OrderBcNum});{'"'} value={'"'}Fiyat & Statu{'"'}/>
                                <input type={'"'}button{'"'} class={'"'}btn btn-primary{'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupArea{'"'} onclick={'"'}GetDetail({currentRow.OrderBcNum},'update');{'"'} value={'"'}Düzenle{'"'}/>";
                                    /*
                                    if (currentRow.delst.ToString().ToLower() == "true")
                                    {
                                        Table += $@"<input type={'"'}button{'"'} class={'"'}btn btn-danger{'"'} onclick={'"'}DeActive({currentRow.OrderBcNum});{'"'} value={'"'}Pasife Çek{'"'}/>";
                                    }
                                    else
                                    {
                                        Table += $@"<input type={'"'}button{'"'} class={'"'}btn btn-success{'"'} onclick={'"'}Active({currentRow.OrderBcNum});{'"'} value={'"'}Aktife Çek{'"'}/>";
                                    }
                                    */
                                }
                                else
                                {
                                    Table += $@"<input type={'"'}button{'"'} class={'"'}btn btn-primary{'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupArea{'"'} onclick={'"'}GetDetail({currentRow.OrderBcNum},'detail');{'"'} value={'"'}İncele{'"'}/>";
                                    /*
                                    if (currentRow.delst.ToString().ToLower() == "true")
                                    {
                                        Table += $@"<input type={'"'}button{'"'} class={'"'}btn btn-danger{'"'} onclick={'"'}DeActive({currentRow.OrderBcNum});{'"'} value={'"'}Pasife Çek{'"'}/>";
                                    }
                                    else
                                    {
                                        Table += $@"<input type={'"'}button{'"'} class={'"'}btn btn-success{'"'} onclick={'"'}Active({currentRow.OrderBcNum});{'"'} value={'"'}Aktife Çek{'"'}/>";
                                    }
                                    */
                                }
                                Table += $@"</td>
                        <td>{currentRow.ExtOrderID}</td>
                        <td>{currentRow.RetailName}</td>
                        <td>{currentRow.GrandTotal}</td>
                        <td>{GetStatu(currentRow.Statu.ToString())}</td>
                        <td>{currentRow.Err_code}</td>
                        <td>{currentRow.OrderBcNum}</td>
                        <td>{currentRow.RetailNum}</td>
                        <td>{currentRow.ctime}</td>
                        <td>{currentRow.itemCode}</td>
                        <td>{currentRow.ItemName}</td>
                        <td>{currentRow.qty}</td>
                        <td>{currentRow.Price}</td>
                        <td>{currentRow.TotalPrice}</td>
                        <td>{currentRow.TaxRate2}</td>
                        <td>{currentRow.TaxAmt2}</td>
                        <td>{currentRow.CostAmt}</td>
                        <td>{currentRow.CustTransAmt}</td>
                        <td>{currentRow.CostType}</td>
                        <td>{currentRow.CostRate}</td>
                        <td>{currentRow.BankTransID}</td>
                        <td>{currentRow.BankSiparis_id}</td>
                        <td>{currentRow.Musteri_id}</td>
                        <td>{currentRow.Musteri_adi}</td>
                        <td>{currentRow.Siparis_Statu}</td>
                        <td>{currentRow.Tutar}</td>
                        <td>{currentRow.Toplam_tutar}</td>
                        <td>{currentRow.Aciklama}</td>
                        <td>{currentRow.SysNote}</td>
                        ";
                                Table += $@"</tr>";
                                qty += currentRow.qty;
                                Price += currentRow.Price;
                                TotalPrice += currentRow.TotalPrice;
                                GrandTotal += currentRow.GrandTotal;
                                //TaxRate2 += currentRow.TaxRate2;
                                TaxAmt2 += currentRow.TaxAmt2;
                                CostAmt += currentRow.CostAmt;
                                CustTransAmt += currentRow.CustTransAmt;
                                //CostRate += currentRow.CostRate;
                                Tutar += currentRow.Tutar;
                                Toplam_tutar += currentRow.Toplam_tutar;
                            }
                            Table += $@"
<td>{dataTable.Rows.Count} Adet Toplamı</td>
<td></td>
<td></td>
<td>{GrandTotal}</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td>{qty}</td>
<td>{Price}</td>
<td>{TotalPrice}</td>
<td></td>
<td>{TaxAmt2}</td>
<td>{CostAmt}</td>
<td>{CustTransAmt}</td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td></td>
<td>{Tutar}</td>
<td>{Toplam_tutar}</td>
<td></td>
<td></td>";
                            Table += "</tbody>";
                            return Return(StatusType.True, new { Table, DalDataTable.Rows.Count }, "Listelendi", "");
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
        [Trace("runtime")]
        public string ListNew()
        {
            string Table = string.Empty;
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: "/Home/Index");
            }
            else
            {
                DalList(Session["api"].ToString(),
                    DateTime.MinValue.ToString("yyyy-MM-dd"), DateTime.MaxValue.ToString("yyyy-MM-dd"),
                    "", "", "", "", "", "", "01", "YES");
                if (!DalMessage.StartsWith("100"))
                {
                    return Return(StatusType.False, SplitPipe(DalMessage));
                }
                else
                {
                    try
                    {
                        ORDERBC_TTDataTable dataTable = DalDataTable;
                        Table += $@"
                            <thead>
                                <tr>
                                    <th>İşlemler</th>
                                    <th>{dataTable.ctimeColumn.Caption}</th>
                                    <th>{dataTable.OrderBcNumColumn.Caption}</th>
                                    <th>{dataTable.RetailNumColumn.Caption}</th>
                                    <th>{dataTable.RetailNameColumn.Caption}</th>
                                    <th>{dataTable.GrandTotalColumn.Caption}</th>
                                    <th>{dataTable.StatuColumn.Caption}</th>
                                    <th>{dataTable.Siparis_idColumn.Caption}</th>
                                    <th>{dataTable.BankSiparis_idColumn.Caption}</th>
                                </tr>
                            </thead>
                            <tbody>
                        ";
                        for (int a = 0; a < dataTable.Count; a++)
                        {
                            ORDERBC_TTRow currentRow = dataTable.Rows[a] as ORDERBC_TTRow;
                            if (currentRow.Statu.ToString().ToLower().StartsWith("01"))
                            {
                                Table +=
                                $@"
                            <tr class={'"'}gradeX{'"'}>
                            <td>
                            <input type={'"'}button{'"'} class={'"'}form-control btn-success{'"'} onclick={'"'}SetStatu({currentRow.OrderBcNum});{'"'} value={'"'}Ödeme Bekliyora Çek{'"'}/>
                            </td>
                            <td>{currentRow.ctime}</td>
                            <td>{currentRow.OrderBcNum}</td>
                            <td>{currentRow.RetailNum}</td>
                            <td>{currentRow.RetailName}</td>
                            <td>{currentRow.GrandTotal}</td>
                            <td>{GetStatu(currentRow.Statu.ToString())}</td>
                            <td>{currentRow.Siparis_id}</td>
                            <td>{currentRow.BankSiparis_id.ToString()}</td>
                            </tr>
                            ";
                            }
                        }
                        Table += "</tbody>";
                        return Return(StatusType.True, new { Table, DalDataTable.Rows.Count }, "Yeni Kayıtlar Listelendi.");
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
        [Trace("runtime")]
        public string ListCust(string CustName)
        {
            string Options = $"<option value={'"'}-1{ '"'}>Seçiniz</option>";
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: UrlLogin);
            }
            else
            {
                if (CustName is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ListCustByName(Session["api"].ToString(), CustName);
                        if (RetailMessage is null || !RetailMessage.StartsWith("100"))
                        {
                            return Return(StatusType.False, new { Options }, SplitPipe(RetailMessage));
                        }
                        else
                        {
                            RETAIL_TTDataTable dataTable = RetailDataTable;
                            for (int a = 0; a < dataTable.Rows.Count; a++)
                            {
                                RETAIL_TTRow currentRow = dataTable.Rows[a] as RETAIL_TTRow;
                                Options += $"<option value={'"'}{currentRow.RetailNum}{'"'}>{currentRow.Name}</option>";
                            }
                            return Return(StatusType.True, new { Options }, "Sorgulandı.");
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
        [Trace("runtime")]
        public string Get(long? OrderBcNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (OrderBcNum is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTRow row = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                        //ORDERBC_TTRow row = DataTable.AsEnumerable().Where(Row => (Row as ORDERBC_TTRow).OrderBcNum.ToString() == OrderBcNum).FirstOrDefault() as ORDERBC_TTRow;
                        if (row is null)
                        {
                            return Return(StatusType.False, "Bulunamadı");
                        }
                        else
                        {
                            row.Statu = row.Statu.Split(' ')[0];
                            return Return(
                                StatusType.True,
                                new
                                {
                                    User = $"<option value={'"'}{row.RetailNum}{'"'}>{row.RetailName}</option>",
                                    Item = new
                                    {
                                        row.itemCode
                                    },
                                    Order = new
                                    {
                                        row.OrderBcNum,
                                        row.Aciklama,
                                        row.Statu,
                                        row.Price,
                                        row.qty,
                                        row.TaxRate2,
                                        row.ExtOrderID
                                    }
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
        [Trace("runtime")]
        public string Active(long? OrderBcNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (OrderBcNum is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTRow row = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                        //ORDERBC_TTRow row = DataTable.AsEnumerable().Where(Row => (Row as ORDERBC_TTRow).OrderBcNum.ToString() == OrderBcNum).FirstOrDefault() as ORDERBC_TTRow;
                        if (row is null)
                        {
                            return Return(StatusType.False, "Bulunamadı.");
                        }
                        else
                        {
                            row.recSt = "D";
                            row.delst = true;
                            DalSet(Session["api"].ToString(), RowToNewTable(row));
                            if (!DalMessage.StartsWith("100"))
                            {
                                return Return(StatusType.False, SplitPipe(DalMessage));
                            }
                            else
                            {
                                return Return(StatusType.True, "Aktif edildi");
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
                        return Return(StatusType.False, ex.Message);
                    }
                }
            }
        }
        [Trace("runtime")]
        public string DeActive(long? OrderBcNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (OrderBcNum is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTRow row = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                        //ORDERBC_TTRow row = DataTable.AsEnumerable().Where(Row => (Row as ORDERBC_TTRow).OrderBcNum.ToString() == OrderBcNum).FirstOrDefault() as ORDERBC_TTRow;
                        if (row is null)
                        {
                            return Return(StatusType.False, "Bulunamadı.");
                        }
                        else
                        {
                            row.recSt = "D";
                            row.delst = false;
                            DalSet(Session["api"].ToString(), RowToNewTable(row));
                            if (!DalMessage.StartsWith("100"))
                            {
                                return Return(StatusType.False, SplitPipe(DalMessage));
                            }
                            else
                            {
                                return Return(StatusType.True, "Pasif edildi");
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
                        return Return(StatusType.False, ex.Message);
                    }
                }
            }
        }
        [Trace("runtime")]
        public string New(string RetailNum,
                          string Description,
                          string itemCode,
                          string qty,
                          string Price,
                          string TaxRate2,
                          string TaxAmt2,
                          string TotalPrice,
                          string GrandTotal)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (RetailNum is null || Description is null ||
                    itemCode is null || qty is null || TaxAmt2 is null ||
                    TotalPrice is null || GrandTotal is null ||
                    Price is null || TaxRate2 is null ||
                    !decimal.TryParse(TaxAmt2, out _) ||
                    !decimal.TryParse(TotalPrice, out _) ||
                    !decimal.TryParse(GrandTotal, out _))
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTDataTable dataTable = new ORDERBC_TTDataTable();
                        ORDERBC_TTRow row = dataTable.NewORDERBC_TTRow();
                        row.CorpNum = 0;
                        row.CustNum = 0;
                        row.cdate = DateTime.Now;
                        row.OrderBcNum = 0;
                        row.RetailNum = int.Parse(RetailNum);
                        row.Err_code = "";
                        row.Siparis_id = "";
                        row.BankSiparis_id = "";
                        row.Musteri_id = "";
                        row.Tutar = 0;
                        row.TaxRate1 = 0;
                        row.TaxRate2 = TaxRate2 == "" ? 1 : decimal.Parse(TaxRate2.Replace(".", ","));
                        row.Toplam_tutar = 0;
                        row.CostAmt = 0;
                        row.CostType = true;
                        row.CostRate = 0;
                        row.CustTransAmt = 0;
                        row.Aciklama = Description;
                        row.Musteri_adi = "";
                        row.Telefon = "";
                        row.Fatura_no = "";
                        row.Siparis_Statu = "";
                        row.Olusturma_zamani = "";
                        row.OlusturmaTrh = DateTime.Now;
                        row.xml_resp = "";
                        row.ctime = DateTime.Now;
                        row.BankTransID = 0;
                        row.Lineno = 0;
                        row.SysNote = "";
                        row.Statu = "0" + (int)OrderType.BEKLIYOR + " " + OrderType.BEKLIYOR.ToString().Replace("_", " ");
                        if (row.Statu == "Error404")
                        {
                            return Return(StatusType.False, "Hatalı Alan.");
                        }
                        row.prm1 = "";
                        row.prm2 = "";
                        row.prm3 = "";
                        row.prm4 = "";
                        row.Udate = DateTime.Now;
                        row.CrtUser = "";
                        row.UpdUser = "";
                        row.recSt = "N";
                        row.delst = true;
                        row.RetailName = "";
                        row.itemCode = itemCode;
                        row.ItemName = (ItemDataTable.AsEnumerable().Where(Row => (Row as ITEM_TTRow).itemCode == itemCode).FirstOrDefault() as ITEM_TTRow).ItemName;
                        row.qty = qty == "" ? 1 : decimal.Parse(qty.Replace(".", ","));
                        row.Price = Price == "" ? 1 : decimal.Parse(Price.Replace(".", ","));
                        row.TaxAmt1 = 0;
                        row.TaxAmt2 = TaxAmt2 == "" ? 1 : decimal.Parse(TotalPrice.Replace(".", ","));
                        row.TotalPrice = TotalPrice == "" ? 1 : decimal.Parse(TotalPrice.Replace(".", ","));
                        row.GrandTotal = GrandTotal == "" ? 1 : decimal.Parse(GrandTotal.Replace(".", ","));
                        row.ExtOrderID = row.RetailNum + "" + row.OrderBcNum;
                        row.RecCount = 0;
                        dataTable.Rows.Add(row);
                        DalSet(Session["api"].ToString(), dataTable);
                        if (!DalMessage.StartsWith("100"))
                        {
                            return Return(StatusType.False, SplitPipe(DalMessage));
                        }
                        else
                        {
                            return Return(StatusType.True, new
                            {
                                ExtOrdId = DalMessage.Split('|')[1]
                            }, "Oluşturuldu");
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
        [Trace("runtime")]
        public string Update(long? OrderBcNum,
                             string RetailNum,
                             string Statu,
                             string Description,
                             string itemCode,
                             string qty,
                             string Price,
                             string TaxRate2,
                             string TaxAmt2,
                             string TotalPrice,
                             string GrandTotal)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (OrderBcNum is null
                    || RetailNum is null
                    || Description is null
                    || itemCode is null
                    || Price is null
                    || TaxRate2 is null
                    || qty is null
                    || TaxAmt2 is null
                    || Statu is null
                    || TotalPrice is null
                    || GrandTotal is null
                    || !decimal.TryParse(TaxAmt2, out _)
                    || !decimal.TryParse(TotalPrice, out _)
                    || !decimal.TryParse(GrandTotal, out _))
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTRow oldRow = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                        //ORDERBC_TTRow oldRow = DataTable.AsEnumerable().Where(Row => (Row as ORDERBC_TTRow).OrderBcNum.ToString() == OrderBcNum).FirstOrDefault() as ORDERBC_TTRow;
                        if (oldRow is null)
                        {
                            return Return(StatusType.False, "Bulunamadı");
                        }
                        else
                        {
                            if (oldRow.Statu.StartsWith("09"))
                            {
                                return Return(StatusType.False, "Güncellenemez.");
                            }
                            else
                            {
                                ORDERBC_TTDataTable dataTable = new ORDERBC_TTDataTable();
                                ORDERBC_TTRow row = dataTable.NewORDERBC_TTRow();
                                row.CorpNum = oldRow.CorpNum;
                                row.CustNum = oldRow.CustNum;
                                row.cdate = oldRow.cdate;
                                row.OrderBcNum = oldRow.OrderBcNum;
                                row.RetailNum = int.Parse(RetailNum);
                                row.Err_code = oldRow.Err_code;
                                row.Siparis_id = oldRow.Siparis_id;
                                row.BankSiparis_id = oldRow.BankSiparis_id;
                                row.Musteri_id = oldRow.Musteri_id;
                                row.Tutar = oldRow.Tutar;
                                row.TaxRate1 = oldRow.TaxRate1;
                                row.TaxRate2 = oldRow.TaxRate2;
                                row.Toplam_tutar = oldRow.Toplam_tutar;
                                row.CostAmt = oldRow.CostAmt;
                                row.CostType = oldRow.CostType;
                                row.CostRate = oldRow.CostRate;
                                row.CustTransAmt = oldRow.CustTransAmt;
                                row.Aciklama = Description;
                                row.Musteri_adi = oldRow.Musteri_adi;
                                row.Telefon = oldRow.Telefon;
                                row.Fatura_no = oldRow.Fatura_no;
                                row.Siparis_Statu = oldRow.Siparis_Statu;
                                row.Olusturma_zamani = oldRow.Olusturma_zamani;
                                row.OlusturmaTrh = oldRow.OlusturmaTrh;
                                row.xml_resp = oldRow.xml_resp;
                                row.ctime = oldRow.ctime;
                                row.BankTransID = oldRow.BankTransID;
                                row.Lineno = oldRow.Lineno;
                                row.SysNote = oldRow.SysNote;
                                row.Statu = Statu + ' ' + GetStatu(Statu);
                                if (row.Statu == "Error404")
                                {
                                    return Return(StatusType.False, "Hatalı Alan.");
                                }
                                row.prm1 = oldRow.prm1;
                                row.prm2 = oldRow.prm2;
                                row.prm3 = oldRow.prm3;
                                row.prm4 = oldRow.prm4;
                                row.Udate = oldRow.Udate;
                                row.CrtUser = oldRow.CrtUser;
                                row.UpdUser = oldRow.UpdUser;
                                row.recSt = "U";
                                row.delst = oldRow.delst;
                                row.RetailName = oldRow.RetailName;
                                row.itemCode = oldRow.itemCode;
                                row.ItemName = oldRow.ItemName;
                                row.qty = qty == "" ? 0 : decimal.Parse(qty);
                                row.Price = Price == "" ? 0 : decimal.Parse(Price.Replace(".", ","));
                                row.TaxAmt1 = oldRow.TaxAmt1;
                                row.TaxAmt2 = TaxAmt2 == "" ? 0 : decimal.Parse(TaxAmt2.Replace(".", ","));
                                row.TotalPrice = TotalPrice == "" ? 0 : decimal.Parse(TotalPrice.Replace(".", ","));
                                row.GrandTotal = GrandTotal == "" ? 0 : decimal.Parse(GrandTotal.Replace(".", ","));
                                row.ExtOrderID = oldRow.ExtOrderID;
                                row.RecCount = oldRow.RecCount;
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
        [Trace("runtime")]
        public string GetItem(string itemCode)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (itemCode is null)
                {
                    return Return(StatusType.False, "Hatalı alan", "");
                }
                else
                {
                    try
                    {
                        ITEM_TTRow row = ItemDataTable.AsEnumerable().Where(Row => (Row as ITEM_TTRow).itemCode == itemCode).FirstOrDefault() as ITEM_TTRow;
                        if (row is null)
                        {
                            return Return(StatusType.False, "Bulunamadı", "");
                        }
                        else
                        {
                            return Return(StatusType.True, new
                            {
                                row.Price,
                                row.TaxRate,
                            }, "", "");
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
        [Trace("runtime")]
        public string SetStatu(long? OrderBcNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: "/Home/Index");
            }
            else
            {
                if (OrderBcNum is null)
                {
                    return Return(StatusType.False, "Hatalı Alan.");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTRow row = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                        if (row is null)
                        {
                            return Return(StatusType.False, "Hatalı Alan.");
                        }
                        else
                        {
                            ORDERBC_TTDataTable Table = RowToNewTable(row);
                            (Table.Rows[0] as ORDERBC_TTRow).Statu = "02 " + GetStatu("02");
                            (Table.Rows[0] as ORDERBC_TTRow).recSt = "U";
                            DalSet(Session["api"].ToString(), Table);
                            return Return(StatusType.True, "Değiştirildi.");
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
        [Trace("runtime")]
        public string GetOrderFast(long? OrderBcNum)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: UrlLogin);
            }
            else
            {
                if (OrderBcNum is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ORDERBC_TTRow row = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                        if (row is null)
                        {
                            return Return(StatusType.False, "Kayıt Bulunamadı");
                        }
                        else
                        {
                            return Return(StatusType.True, new
                            {
                                Statu = row.Statu.Split(' ')[0],
                                row.GrandTotal
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
        [Trace("runtime")]
        public string UpdateFast(long? OrderBcNum, string Statu, decimal? Total)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: UrlLogin);
            }
            else
            {
                if (OrderBcNum is null
                    || Statu is null
                    || Total is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    ORDERBC_TTRow row = DalDataTable.FindByOrderBcNum((long)OrderBcNum);
                    if (row is null)
                    {
                        return Return(StatusType.False, "Kayıt Bulunamadı");
                    }
                    else
                    {
                        try
                        {
                            string rawStatu = Statu + " " + GetStatu(Statu);
                            DalSetPrivate(Session["api"].ToString(),
                                          (int)OrderBcNum,
                                          rawStatu,
                                          (decimal)Total,
                                          out int resp_code);
                            if (resp_code == 900)
                            {
                                return Return(StatusType.False, DalMessage);
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
    }
}