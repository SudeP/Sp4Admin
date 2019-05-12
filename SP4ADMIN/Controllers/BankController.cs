using System.Web.Mvc;
using SP4ADMIN.Models;
using sp4net.StrongTypesNS;
using static SP4ADMIN.Models.Tools;
using static SP4ADMIN.Models.ReturnJson;
using static SP4ADMIN.Models.DalBank;
using System;
using System.Reflection;

namespace SP4ADMIN.Controllers
{
    public class BankController : Controller
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
        public ActionResult Bank_js()
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
        public string List(string SDATE,
                           string EDATE,
                           string BANKTRANS_ID,
                           string STATU)
        {
            var asd = MethodBase.GetCurrentMethod().GetParameters();
            string Table = "";
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: UrlLogin);
            }
            else
            {
                if (SDATE is null
                    || EDATE is null
                    || BANKTRANS_ID is null
                    || STATU is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    DalList(Session["api"].ToString(),
                                 SDATE,
                                 EDATE,
                                 BANKTRANS_ID,
                                 STATU);
                    if (!DalMessage.StartsWith("100"))
                    {
                        return Return(StatusType.False, SplitPipe(DalMessage));
                    }
                    else
                    {
                        try
                        {
                            BANKTRANS_TTDataTable dataTable = DalDataTable;
                            Table +=
                            $@"
                        <thead>
                            <tr>
                                <th>İşlemler</th>
                                <th>{dataTable.BankTransIDColumn.Caption}</th>
                                <th>{dataTable.BankCodeColumn.Caption}</th>
                                <th>{dataTable.CdateColumn.Caption}</th>
                                <th>{dataTable.BankTransDateColumn.Caption}</th>
                                <th>{dataTable.ExtOrderIDColumn.Caption}</th>
                                <th>{dataTable.ExtOrderIDupdColumn.Caption}</th>
                                <th>{dataTable.AmountColumn.Caption}</th>
                                <th>{dataTable.StatuColumn.Caption}</th>
                                <th>{dataTable._Desc_Column.Caption}</th>
                                <th>{dataTable._BankDesc_Column.Caption}</th>
                                <th>{dataTable.ExtCustIDColumn.Caption}</th>
                                <th>{dataTable.CorpNumColumn.Caption}</th>
                                <th>{dataTable.CustNumColumn.Caption}</th>
                            </tr>
                        </thead>
                        <tbody>
                        ";
                            if (dataTable != null)
                                for (int a = 0; a < dataTable.Rows.Count; a++)
                                {
                                    BANKTRANS_TTRow currentRow = dataTable.Rows[a] as BANKTRANS_TTRow;
                                    Table += "<tr>";
                                    if (true/*currentRow.Statu.StartsWith("02")*/)
                                    {
                                        Table += $@"<td><input type={'"'}button{'"'} class={'"'}btn btn-primary{'"'} onclick={'"'}SetExtOrdId('{currentRow.BankTransID}','{currentRow.ExtOrderIDupd}');{'"'} value={'"'}Id değiştir{'"'} /></td>";
                                    }
                                    else
                                    {
#pragma warning disable CS0162 // Unreachable code detected
                                        Table += "<td></td>";
#pragma warning restore CS0162 // Unreachable code detected
                                    }
                                    Table +=
                                    $@"
                                <td>{currentRow.BankTransID}</td>
                                <td>{currentRow.BankCode}</td>
                                <td>{currentRow.Cdate}</td>
                                <td>{currentRow.BankTransDate}</td>
                                <td>{currentRow.ExtOrderID}</td>
                                <td>{currentRow.ExtOrderIDupd}</td>
                                <td>{currentRow.Amount}</td>
                                <td>{GetStatu(currentRow.Statu)}</td>
                                <td>{SplitPipe(currentRow._Desc_)}</td>
                                <td>{currentRow._BankDesc_}</td>
                                <td>{currentRow.ExtCustID}</td>
                                <td>{currentRow.CorpNum}</td>
                                <td>{currentRow.CustNum}</td>
                                ";
                                    Table += "</tr>";
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
        public string SetExtOrdId(int? BankTransID, string NewId)
        {
            if (!IsLogin(this, "api"))
            {
                return Return(StatusType.Logout, location: UrlLogin);
            }
            else
            {
                if (BankTransID is null
                    || NewId is null)
                {
                    return Return(StatusType.False, "Hatalı Alan");
                }
                else
                {
                    try
                    {
                        DalSetId(Session["api"].ToString(), (int)BankTransID, NewId);
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