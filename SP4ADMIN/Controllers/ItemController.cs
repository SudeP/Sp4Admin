using System.Web.Mvc;
using sp4net.StrongTypesNS;
using static SP4ADMIN.Models.Tools;
using static SP4ADMIN.Models.ReturnJson;
using static SP4ADMIN.Models.DalItem;
using System;
using SP4ADMIN.Models;

namespace SP4ADMIN.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
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
        public ActionResult Item_js()
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
                    string itemName,
                    string Category1,
                    string Category2,
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
                    || itemName is null
                    || Category1 is null
                    || Category2 is null
                    || Statu is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    DalList(Session["api"].ToString(),
                                 bastar,
                                 bittar,
                                 "",
                                 itemName,
                                 Category1,
                                 Category2,
                                 Statu);
                    if (!DalMessage.StartsWith("100"))
                    {
                        return Return(StatusType.False, SplitPipe(DalMessage));
                    }
                    else
                    {
                        try
                        {
                            ITEM_TTDataTable dataTable = DalDataTable;
                            Table +=
                            $@"
                            <thead>
                                <tr>
                                    <th>İşlemler</th>
                                    <th>{dataTable.itemCodeColumn.Caption}</th>
                                    <th>{dataTable.ItemNameColumn.Caption}</th>
                                    <th>{dataTable.qtyColumn.Caption}</th>
                                </tr>
                            </thead>
                            <tbody>
                        ";
                            for (int a = 0; a < dataTable.Count; a++)
                            {
                                ITEM_TTRow currentRow = dataTable.Rows[a] as ITEM_TTRow;
                                Table += $@"<tr class={'"'}gradeX{'"'}><td>";
                                if (currentRow.Statu.ToString().ToLower() == "true")
                                {
                                    Table +=
                                    $@"
                            <input type={'"'}button{'"'} class={'"'}btn btn-primary{'"'} data-toggle={'"'}modal{'"'} data-target={'"'}#popupArea{'"'} onclick={'"'}GetDetail({currentRow.CorpNum},{currentRow.CustNum},{"'"}{currentRow.itemCode}{"'"},'update');{'"'} value={'"'}Düzenle{'"'}/>
                            </td>";
                                    /*
                            <input type={'"'}button{'"'} class={'"'}btn btn-danger{'"'} onclick={'"'}DeActive({currentRow.CorpNum},{currentRow.CustNum},{"'"}{currentRow.itemCode}{"'"});{'"'} value={'"'}Pasife Çek{'"'}/>
                                     */
                                }
                                else
                                {
                                    Table +=
                                    $@"
                            <input type={'"'}button{'"'} class={'"'}btn btn-primary{'"'} data-target={'"'}#popupArea{'"'} data-toggle={'"'}modal{'"'} onclick={'"'}GetDetail({currentRow.CorpNum},{currentRow.CustNum},{"'"}{currentRow.itemCode}{"'"},'detail');{'"'} value={'"'}İncele{'"'}/>";
                                    /*
                            <input type={'"'}button{'"'} class={'"'}btn btn-success{'"'} onclick={'"'}Active({currentRow.CorpNum},{currentRow.CustNum},{"'"}{currentRow.itemCode}{"'"});{'"'} value={'"'}Aktife Çek{'"'}/>
                                 */
                                }
                                Table += $@"</td>
                            <td>{currentRow.itemCode}</td>
                            <td>{currentRow.ItemName}</td>
                            <td>{currentRow.qty}</td>
                            </tr>";
                            }
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
        public string Get(string corp,
                          string cust,
                          string code)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (corp is null
                    || cust is null
                    || code is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ITEM_TTRow ttrow = DalDataTable.FindByCorpNumCustNumitemCode(int.Parse(corp), int.Parse(cust), code);
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
                                    ttrow.ItemName,
                                    ttrow.itemCode,
                                    ttrow.Category1,
                                    ttrow.Category2,
                                    ttrow.Price,
                                    ttrow.DiscRate,
                                    ttrow.TaxRate,
                                    ttrow.Weight,
                                    ttrow.qty,
                                    ttrow.Barcode,
                                    ttrow.BuyeritemCode,
                                    ttrow.CargoCampCode,
                                    ttrow.itemUrl,
                                    ttrow.Special,
                                    ttrow.itemDesc
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
                             string code)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (corp is null
                    || cust is null
                    || code is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ITEM_TTRow ttrow = DalDataTable.FindByCorpNumCustNumitemCode(int.Parse(corp), int.Parse(cust), code);
                        if (ttrow is null)
                        {
                            return Return(StatusType.False, "Bulunamadı");
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
                               string code)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (corp is null
                    || cust is null
                    || code is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        ITEM_TTRow ttrow = DalDataTable.FindByCorpNumCustNumitemCode(int.Parse(corp), int.Parse(cust), code);
                        if (ttrow is null)
                        {
                            return Return(StatusType.False, "Bulunamadı");
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
        public string New(string itemName,
                          string itemCode,
                          string Category1,
                          string Category2,
                          string Price,
                          string DiscRate,
                          string TaxRate,
                          string Weight,
                          string Qty,
                          string BarCode,
                          string BuyeritemCode,
                          string CargoCampCode,
                          string itemUrl,
                          string Special,
                          string itemDesc)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (itemName is null
                    || itemCode is null
                    || Category1 is null
                    || Category2 is null
                    || Price is null
                    || DiscRate is null
                    || TaxRate is null
                    || Weight is null
                    || Qty is null
                    || BarCode is null
                    || BuyeritemCode is null
                    || CargoCampCode is null
                    || itemUrl is null
                    || Special is null
                    || itemDesc is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    try
                    {
                        ITEM_TTDataTable dataTable = new ITEM_TTDataTable();
                        ITEM_TTRow row = dataTable.NewITEM_TTRow();
                        /*New */
                        row.ItemName = itemName;
                        row.itemCode = itemCode;
                        row.Category1 = Category1;
                        row.Category2 = Category2;
                        row.Price = Price != "" ? decimal.Parse(Price.Replace(".", ",")) : 0;
                        row.DiscRate = DiscRate != "" ? decimal.Parse(DiscRate.Replace(".", ",")) : 0;
                        row.TaxRate = TaxRate != "" ? decimal.Parse(TaxRate.Replace(".", ",")) : 0;
                        row.Weight = Weight != "" ? decimal.Parse(Weight.Replace(".", ",")) : 0;
                        row.qty = Qty != "" ? decimal.Parse(Qty.Replace(".", ",")) : 0;
                        row.Barcode = BarCode;
                        row.BuyeritemCode = BuyeritemCode;
                        row.CargoCampCode = CargoCampCode;
                        row.itemUrl = itemUrl;
                        row.Special = Special;
                        row.itemDesc = itemDesc;
                        /*New */
                        /*Old */
                        row.Onhand = 0;
                        row.Minqty = 0;
                        row.ReOrder = 0;
                        row.OnOrder = 0;
                        row.BackOrder = 0;
                        row.Allocated = 0;
                        row.CorpNum = 0;
                        row.CustNum = 0;
                        row.CrtUser = "";
                        row.UpdUser = "";
                        row.recSt = "N";
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
        public string Update(string CorpNum,
                             string CustNum,
                             string itemName,
                             string itemCode,
                             string Category1,
                             string Category2,
                             string Price,
                             string DiscRate,
                             string TaxRate,
                             string Weight,
                             string Qty,
                             string BarCode,
                             string BuyeritemCode,
                             string CargoCampCode,
                             string itemUrl,
                             string Special,
                             string itemDesc)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, "", "/Home/Index");
            }
            else
            {
                if (CorpNum is null || CustNum is null || itemCode is null)
                {
                    return Return(StatusType.False, "Hatalı alan");
                }
                else
                {
                    ITEM_TTRow oldRow = DalDataTable.FindByCorpNumCustNumitemCode(int.Parse(CorpNum), int.Parse(CustNum), itemCode);
                    if (oldRow is null)
                    {
                        return Return(StatusType.False, "Bulunamadı");
                    }
                    else
                    {
                        if (itemName is null
                            || itemCode is null
                            || Category1 is null
                            || Category2 is null
                            || Price is null
                            || DiscRate is null
                            || TaxRate is null
                            || Weight is null
                            || Qty is null
                            || BarCode is null
                            || BuyeritemCode is null
                            || CargoCampCode is null
                            || itemUrl is null
                            || Special is null
                            || itemDesc is null)
                        {
                            return Return(StatusType.False, "Hatalı alan");
                        }
                        else
                        {
                            try
                            {
                                ITEM_TTDataTable dataTable = new ITEM_TTDataTable();
                                ITEM_TTRow row = dataTable.NewITEM_TTRow();
                                /*New */
                                row.ItemName = itemName;
                                row.itemCode = itemCode;
                                row.Category1 = Category1;
                                row.Category2 = Category2;
                                row.Price = Price != "" ? int.Parse(Price) : 0;
                                row.DiscRate = DiscRate != "" ? int.Parse(DiscRate) : 0;
                                row.TaxRate = TaxRate != "" ? int.Parse(TaxRate) : 0;
                                row.Weight = Weight != "" ? int.Parse(Weight) : 0;
                                row.qty = Qty != "" ? int.Parse(Qty) : 0;
                                row.Barcode = BarCode;
                                row.BuyeritemCode = BuyeritemCode;
                                row.CargoCampCode = CargoCampCode;
                                row.itemUrl = itemUrl;
                                row.Special = Special;
                                row.itemDesc = itemDesc;
                                /*New */
                                /*Old */
                                row.Onhand = oldRow.Onhand;
                                row.Minqty = oldRow.Minqty;
                                row.ReOrder = oldRow.ReOrder;
                                row.OnOrder = oldRow.OnOrder;
                                row.BackOrder = oldRow.BackOrder;
                                row.Allocated = oldRow.Allocated;
                                row.CorpNum = oldRow.CorpNum;
                                row.CustNum = oldRow.CustNum;
                                row.Cdate = oldRow.Cdate;
                                row.Udate = oldRow.Udate;
                                row.CrtUser = oldRow.CrtUser;
                                row.UpdUser = oldRow.UpdUser;
                                row.recSt = "U";
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
}