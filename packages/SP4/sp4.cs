
/*
**
**    Created by PROGRESS ProxyGen (Progress Version 11.6) Wed Apr 24 16:43:33 EEST 2019
**
*/

//
// sp4
//


namespace sp4net
{
    using System;
    using Progress.Open4GL;
    using Progress.Open4GL.Exceptions;
    using Progress.Open4GL.Proxy;
    using Progress.Open4GL.DynamicAPI;
    using Progress.Common.EhnLog;
    using System.Collections.Specialized;
    using System.Configuration;

    /// <summary>
    /// 
    /// 
    /// 
    /// </summary>
    public class sp4 : AppObject
    {
        private static int proxyGenVersion = 1;
        private const  int PROXY_VER = 5;

    // Create a MetaData object for each temp-table parm used in any and all methods.
    // Create a Schema object for each method call that has temp-table parms which
    // points to one or more temp-tables used in that method call.


	static DataTableMetaData ProParsBankTransZiraat_cr_MetaData1;



	static DataTableMetaData dlltest_tt_MetaData1;



	static DataTableMetaData BankTransList_Get_app_MetaData1;



	static DataTableMetaData CustRetail_Set_app_MetaData1;



	static DataTableMetaData CustRetailList_Get_app_MetaData1;



	static DataTableMetaData item_Set_app_MetaData1;



	static DataTableMetaData itemList_get_app_MetaData1;



	static DataTableMetaData OrderBc_Set_app_MetaData1;



	static DataTableMetaData OrderBcList_Get_app_MetaData1;




        static sp4()
        {
		ProParsBankTransZiraat_cr_MetaData1 = new DataTableMetaData(0, "BANKA_TT", 11, false, 0, null, null, null, "sp4net.StrongTypesNS.BANKA_TTDataTable");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(1, "CORPNUM", 0, Parameter.PRO_CHARACTER, 0, 0, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(2, "CUSTNUM", 0, Parameter.PRO_CHARACTER, 0, 1, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(3, "BANK_CODE", 0, Parameter.PRO_CHARACTER, 0, 2, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(4, "BRANCH_CODE", 0, Parameter.PRO_CHARACTER, 0, 3, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(5, "CHANNEL", 0, Parameter.PRO_CHARACTER, 0, 4, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(6, "BANKACCT_CODE", 0, Parameter.PRO_CHARACTER, 0, 5, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(7, "TARIH", 0, Parameter.PRO_CHARACTER, 0, 6, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(8, "GONDEREN", 0, Parameter.PRO_CHARACTER, 0, 7, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(9, "SIPARIS_ID", 0, Parameter.PRO_CHARACTER, 0, 8, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(10, "TUTAR", 0, Parameter.PRO_CHARACTER, 0, 9, 0, "", "", 0, null, "");
		ProParsBankTransZiraat_cr_MetaData1.setFieldDesc(11, "ERRDESC", 0, Parameter.PRO_CHARACTER, 0, 10, 0, "", "", 0, null, "");

		dlltest_tt_MetaData1 = new DataTableMetaData(0, "TEST_TT", 2, false, 0, null, null, null, "sp4net.StrongTypesNS.TEST_TTDataTable");
		dlltest_tt_MetaData1.setFieldDesc(1, "TT_ID", 0, Parameter.PRO_CHARACTER, 0, 0, 0, "", "", 0, null, "");
		dlltest_tt_MetaData1.setFieldDesc(2, "TT_NAME", 0, Parameter.PRO_CHARACTER, 0, 1, 0, "", "", 0, null, "");

		BankTransList_Get_app_MetaData1 = new DataTableMetaData(0, "BANKTRANS_TT", 27, false, 2, "1,BankTransID:ind1.CorpNum,CustNum,ExtOrderID:ind3", null, null, "sp4net.StrongTypesNS.BANKTRANS_TTDataTable");
		BankTransList_Get_app_MetaData1.setFieldDesc(1, "BankTransID", 0, Parameter.PRO_INT64, 0, 0, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(2, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(3, "CustNum", 0, Parameter.PRO_INTEGER, 0, 2, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(4, "BankCode", 0, Parameter.PRO_CHARACTER, 0, 3, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(5, "BranchCode", 0, Parameter.PRO_CHARACTER, 0, 4, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(6, "BankAcctCode", 0, Parameter.PRO_CHARACTER, 0, 5, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(7, "BankTransDateStr", 0, Parameter.PRO_CHARACTER, 0, 6, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(8, "Sender", 0, Parameter.PRO_CHARACTER, 0, 7, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(9, "Cdate", 0, Parameter.PRO_DATE, 0, 8, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(10, "BankTransDate", 0, Parameter.PRO_DATE, 0, 9, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(11, "ctime", 0, Parameter.PRO_DATETIME, 0, 10, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(12, "iban", 0, Parameter.PRO_CHARACTER, 0, 11, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(13, "Desc#", 0, Parameter.PRO_CHARACTER, 0, 12, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(14, "BankDesc#", 0, Parameter.PRO_CHARACTER, 0, 13, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(15, "Amount", 0, Parameter.PRO_DECIMAL, 0, 14, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(16, "Channel", 0, Parameter.PRO_CHARACTER, 0, 15, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(17, "Lineno", 0, Parameter.PRO_INTEGER, 0, 16, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(18, "Ordernum", 0, Parameter.PRO_INTEGER, 0, 17, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(19, "Statu", 0, Parameter.PRO_CHARACTER, 0, 18, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(20, "cuser", 0, Parameter.PRO_CHARACTER, 0, 19, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(21, "ExtOrderID", 0, Parameter.PRO_CHARACTER, 0, 20, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(22, "ExtOrderIDupd", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(23, "ExtCustID", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(24, "Siparis_Statu", 0, Parameter.PRO_CHARACTER, 0, 23, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(25, "Udate", 0, Parameter.PRO_DATE, 0, 24, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(26, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 25, 0, "", "", 0, null, "");
		BankTransList_Get_app_MetaData1.setFieldDesc(27, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 26, 0, "", "", 0, null, "");

		CustRetail_Set_app_MetaData1 = new DataTableMetaData(0, "RETAIL_TT", 48, false, 1, "1,CorpNum,CustNum,RetailNum:ind1", null, null, "sp4net.StrongTypesNS.RETAIL_TTDataTable");
		CustRetail_Set_app_MetaData1.setFieldDesc(1, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 0, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(2, "CustNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(3, "RetailNum", 0, Parameter.PRO_INTEGER, 0, 2, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(4, "Name", 0, Parameter.PRO_CHARACTER, 0, 3, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(5, "Address", 0, Parameter.PRO_CHARACTER, 0, 4, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(6, "Address2", 0, Parameter.PRO_CHARACTER, 0, 5, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(7, "City", 0, Parameter.PRO_CHARACTER, 0, 6, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(8, "State", 0, Parameter.PRO_CHARACTER, 0, 7, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(9, "PostalCode", 0, Parameter.PRO_CHARACTER, 0, 8, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(10, "Contact", 0, Parameter.PRO_CHARACTER, 0, 9, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(11, "Phone", 0, Parameter.PRO_CHARACTER, 0, 10, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(12, "Phone2", 0, Parameter.PRO_CHARACTER, 0, 11, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(13, "Gsm", 0, Parameter.PRO_CHARACTER, 0, 12, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(14, "SalesRep", 0, Parameter.PRO_CHARACTER, 0, 13, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(15, "CreditLimit", 0, Parameter.PRO_DECIMAL, 0, 14, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(16, "Balance", 0, Parameter.PRO_DECIMAL, 0, 15, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(17, "Terms", 0, Parameter.PRO_CHARACTER, 0, 16, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(18, "Discount", 0, Parameter.PRO_INTEGER, 0, 17, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(19, "Comments", 0, Parameter.PRO_CHARACTER, 0, 18, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(20, "Fax", 0, Parameter.PRO_CHARACTER, 0, 19, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(21, "CountryCode", 0, Parameter.PRO_CHARACTER, 0, 20, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(22, "Country", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(23, "CountyCode", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(24, "CountyName", 0, Parameter.PRO_CHARACTER, 0, 23, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(25, "Statu", 0, Parameter.PRO_LOGICAL, 0, 24, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(26, "Email", 0, Parameter.PRO_CHARACTER, 0, 25, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(27, "ServiceCharge", 0, Parameter.PRO_DECIMAL, 0, 26, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(28, "QueryCharge", 0, Parameter.PRO_DECIMAL, 0, 27, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(29, "PosRate", 0, Parameter.PRO_DECIMAL, 0, 28, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(30, "ChannelCode", 0, Parameter.PRO_CHARACTER, 0, 29, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(31, "CurrAcct", 0, Parameter.PRO_CHARACTER, 0, 30, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(32, "CurrAcctid", 0, Parameter.PRO_INTEGER, 0, 31, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(33, "ShortCut", 0, Parameter.PRO_CHARACTER, 0, 32, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(34, "CustCode", 0, Parameter.PRO_CHARACTER, 0, 33, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(35, "CityCode", 0, Parameter.PRO_CHARACTER, 0, 34, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(36, "BankTransKey", 0, Parameter.PRO_CHARACTER, 0, 35, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(37, "TaxNo", 0, Parameter.PRO_CHARACTER, 0, 36, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(38, "TaxOffice", 0, Parameter.PRO_CHARACTER, 0, 37, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(39, "BankCode", 0, Parameter.PRO_CHARACTER, 0, 38, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(40, "iban", 0, Parameter.PRO_CHARACTER, 0, 39, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(41, "CustType", 0, Parameter.PRO_CHARACTER, 0, 40, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(42, "Cdate", 0, Parameter.PRO_DATE, 0, 41, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(43, "Udate", 0, Parameter.PRO_DATE, 0, 42, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(44, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 43, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(45, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 44, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(46, "recSt", 0, Parameter.PRO_CHARACTER, 0, 45, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(47, "OrdNewCount", 0, Parameter.PRO_INTEGER, 0, 46, 0, "", "", 0, null, "");
		CustRetail_Set_app_MetaData1.setFieldDesc(48, "OrdWaitCount", 0, Parameter.PRO_INTEGER, 0, 47, 0, "", "", 0, null, "");

		CustRetailList_Get_app_MetaData1 = new DataTableMetaData(0, "RETAIL_TT", 48, false, 1, "1,CorpNum,CustNum,RetailNum:ind1", null, null, "sp4net.StrongTypesNS.RETAIL_TTDataTable");
		CustRetailList_Get_app_MetaData1.setFieldDesc(1, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 0, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(2, "CustNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(3, "RetailNum", 0, Parameter.PRO_INTEGER, 0, 2, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(4, "Name", 0, Parameter.PRO_CHARACTER, 0, 3, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(5, "Address", 0, Parameter.PRO_CHARACTER, 0, 4, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(6, "Address2", 0, Parameter.PRO_CHARACTER, 0, 5, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(7, "City", 0, Parameter.PRO_CHARACTER, 0, 6, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(8, "State", 0, Parameter.PRO_CHARACTER, 0, 7, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(9, "PostalCode", 0, Parameter.PRO_CHARACTER, 0, 8, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(10, "Contact", 0, Parameter.PRO_CHARACTER, 0, 9, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(11, "Phone", 0, Parameter.PRO_CHARACTER, 0, 10, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(12, "Phone2", 0, Parameter.PRO_CHARACTER, 0, 11, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(13, "Gsm", 0, Parameter.PRO_CHARACTER, 0, 12, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(14, "SalesRep", 0, Parameter.PRO_CHARACTER, 0, 13, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(15, "CreditLimit", 0, Parameter.PRO_DECIMAL, 0, 14, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(16, "Balance", 0, Parameter.PRO_DECIMAL, 0, 15, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(17, "Terms", 0, Parameter.PRO_CHARACTER, 0, 16, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(18, "Discount", 0, Parameter.PRO_INTEGER, 0, 17, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(19, "Comments", 0, Parameter.PRO_CHARACTER, 0, 18, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(20, "Fax", 0, Parameter.PRO_CHARACTER, 0, 19, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(21, "CountryCode", 0, Parameter.PRO_CHARACTER, 0, 20, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(22, "Country", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(23, "CountyCode", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(24, "CountyName", 0, Parameter.PRO_CHARACTER, 0, 23, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(25, "Statu", 0, Parameter.PRO_LOGICAL, 0, 24, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(26, "Email", 0, Parameter.PRO_CHARACTER, 0, 25, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(27, "ServiceCharge", 0, Parameter.PRO_DECIMAL, 0, 26, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(28, "QueryCharge", 0, Parameter.PRO_DECIMAL, 0, 27, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(29, "PosRate", 0, Parameter.PRO_DECIMAL, 0, 28, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(30, "ChannelCode", 0, Parameter.PRO_CHARACTER, 0, 29, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(31, "CurrAcct", 0, Parameter.PRO_CHARACTER, 0, 30, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(32, "CurrAcctid", 0, Parameter.PRO_INTEGER, 0, 31, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(33, "ShortCut", 0, Parameter.PRO_CHARACTER, 0, 32, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(34, "CustCode", 0, Parameter.PRO_CHARACTER, 0, 33, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(35, "CityCode", 0, Parameter.PRO_CHARACTER, 0, 34, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(36, "BankTransKey", 0, Parameter.PRO_CHARACTER, 0, 35, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(37, "TaxNo", 0, Parameter.PRO_CHARACTER, 0, 36, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(38, "TaxOffice", 0, Parameter.PRO_CHARACTER, 0, 37, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(39, "BankCode", 0, Parameter.PRO_CHARACTER, 0, 38, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(40, "iban", 0, Parameter.PRO_CHARACTER, 0, 39, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(41, "CustType", 0, Parameter.PRO_CHARACTER, 0, 40, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(42, "Cdate", 0, Parameter.PRO_DATE, 0, 41, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(43, "Udate", 0, Parameter.PRO_DATE, 0, 42, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(44, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 43, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(45, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 44, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(46, "recSt", 0, Parameter.PRO_CHARACTER, 0, 45, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(47, "OrdNewCount", 0, Parameter.PRO_INTEGER, 0, 46, 0, "", "", 0, null, "");
		CustRetailList_Get_app_MetaData1.setFieldDesc(48, "OrdWaitCount", 0, Parameter.PRO_INTEGER, 0, 47, 0, "", "", 0, null, "");

		item_Set_app_MetaData1 = new DataTableMetaData(0, "ITEM_TT", 29, false, 1, "1,CorpNum,CustNum,itemCode:ind1", null, null, "sp4net.StrongTypesNS.ITEM_TTDataTable");
		item_Set_app_MetaData1.setFieldDesc(1, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 0, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(2, "CustNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(3, "itemCode", 0, Parameter.PRO_CHARACTER, 0, 2, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(4, "ItemName", 0, Parameter.PRO_CHARACTER, 0, 3, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(5, "Price", 0, Parameter.PRO_DECIMAL, 0, 4, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(6, "qty", 0, Parameter.PRO_DECIMAL, 0, 5, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(7, "Onhand", 0, Parameter.PRO_DECIMAL, 0, 6, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(8, "Allocated", 0, Parameter.PRO_DECIMAL, 0, 7, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(9, "ReOrder", 0, Parameter.PRO_DECIMAL, 0, 8, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(10, "OnOrder", 0, Parameter.PRO_DECIMAL, 0, 9, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(11, "BackOrder", 0, Parameter.PRO_DECIMAL, 0, 10, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(12, "itemDesc", 0, Parameter.PRO_CHARACTER, 0, 11, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(13, "Category1", 0, Parameter.PRO_CHARACTER, 0, 12, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(14, "Category2", 0, Parameter.PRO_CHARACTER, 0, 13, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(15, "Special", 0, Parameter.PRO_CHARACTER, 0, 14, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(16, "Weight", 0, Parameter.PRO_DECIMAL, 0, 15, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(17, "Minqty", 0, Parameter.PRO_DECIMAL, 0, 16, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(18, "BuyeritemCode", 0, Parameter.PRO_CHARACTER, 0, 17, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(19, "TaxRate", 0, Parameter.PRO_DECIMAL, 0, 18, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(20, "DiscRate", 0, Parameter.PRO_DECIMAL, 0, 19, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(21, "Barcode", 0, Parameter.PRO_CHARACTER, 0, 20, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(22, "CargoCampCode", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(23, "itemUrl", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(24, "recSt", 0, Parameter.PRO_CHARACTER, 0, 23, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(25, "Cdate", 0, Parameter.PRO_DATE, 0, 24, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(26, "Udate", 0, Parameter.PRO_DATE, 0, 25, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(27, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 26, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(28, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 27, 0, "", "", 0, null, "");
		item_Set_app_MetaData1.setFieldDesc(29, "Statu", 0, Parameter.PRO_LOGICAL, 0, 28, 0, "", "", 0, null, "");

		itemList_get_app_MetaData1 = new DataTableMetaData(0, "ITEM_TT", 29, false, 1, "1,CorpNum,CustNum,itemCode:ind1", null, null, "sp4net.StrongTypesNS.ITEM_TTDataTable");
		itemList_get_app_MetaData1.setFieldDesc(1, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 0, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(2, "CustNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(3, "itemCode", 0, Parameter.PRO_CHARACTER, 0, 2, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(4, "ItemName", 0, Parameter.PRO_CHARACTER, 0, 3, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(5, "Price", 0, Parameter.PRO_DECIMAL, 0, 4, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(6, "qty", 0, Parameter.PRO_DECIMAL, 0, 5, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(7, "Onhand", 0, Parameter.PRO_DECIMAL, 0, 6, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(8, "Allocated", 0, Parameter.PRO_DECIMAL, 0, 7, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(9, "ReOrder", 0, Parameter.PRO_DECIMAL, 0, 8, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(10, "OnOrder", 0, Parameter.PRO_DECIMAL, 0, 9, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(11, "BackOrder", 0, Parameter.PRO_DECIMAL, 0, 10, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(12, "itemDesc", 0, Parameter.PRO_CHARACTER, 0, 11, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(13, "Category1", 0, Parameter.PRO_CHARACTER, 0, 12, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(14, "Category2", 0, Parameter.PRO_CHARACTER, 0, 13, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(15, "Special", 0, Parameter.PRO_CHARACTER, 0, 14, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(16, "Weight", 0, Parameter.PRO_DECIMAL, 0, 15, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(17, "Minqty", 0, Parameter.PRO_DECIMAL, 0, 16, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(18, "BuyeritemCode", 0, Parameter.PRO_CHARACTER, 0, 17, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(19, "TaxRate", 0, Parameter.PRO_DECIMAL, 0, 18, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(20, "DiscRate", 0, Parameter.PRO_DECIMAL, 0, 19, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(21, "Barcode", 0, Parameter.PRO_CHARACTER, 0, 20, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(22, "CargoCampCode", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(23, "itemUrl", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(24, "recSt", 0, Parameter.PRO_CHARACTER, 0, 23, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(25, "Cdate", 0, Parameter.PRO_DATE, 0, 24, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(26, "Udate", 0, Parameter.PRO_DATE, 0, 25, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(27, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 26, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(28, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 27, 0, "", "", 0, null, "");
		itemList_get_app_MetaData1.setFieldDesc(29, "Statu", 0, Parameter.PRO_LOGICAL, 0, 28, 0, "", "", 0, null, "");

		OrderBc_Set_app_MetaData1 = new DataTableMetaData(0, "ORDERBC_TT", 50, false, 1, "1,OrderBcNum:ind1", null, null, "sp4net.StrongTypesNS.ORDERBC_TTDataTable");
		OrderBc_Set_app_MetaData1.setFieldDesc(1, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 0, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(2, "CustNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(3, "cdate", 0, Parameter.PRO_DATE, 0, 2, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(4, "OrderBcNum", 0, Parameter.PRO_INT64, 0, 3, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(5, "RetailNum", 0, Parameter.PRO_INTEGER, 0, 4, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(6, "RetailName", 0, Parameter.PRO_CHARACTER, 0, 5, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(7, "itemCode", 0, Parameter.PRO_CHARACTER, 0, 6, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(8, "ItemName", 0, Parameter.PRO_CHARACTER, 0, 7, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(9, "qty", 0, Parameter.PRO_DECIMAL, 0, 8, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(10, "Price", 0, Parameter.PRO_DECIMAL, 0, 9, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(11, "TotalPrice", 0, Parameter.PRO_DECIMAL, 0, 10, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(12, "TaxRate1", 0, Parameter.PRO_DECIMAL, 0, 11, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(13, "TaxAmt1", 0, Parameter.PRO_DECIMAL, 0, 12, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(14, "TaxRate2", 0, Parameter.PRO_DECIMAL, 0, 13, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(15, "TaxAmt2", 0, Parameter.PRO_DECIMAL, 0, 14, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(16, "GrandTotal", 0, Parameter.PRO_DECIMAL, 0, 15, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(17, "CostAmt", 0, Parameter.PRO_DECIMAL, 0, 16, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(18, "CostType", 0, Parameter.PRO_LOGICAL, 0, 17, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(19, "CostRate", 0, Parameter.PRO_DECIMAL, 0, 18, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(20, "CustTransAmt", 0, Parameter.PRO_DECIMAL, 0, 19, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(21, "BankTransID", 0, Parameter.PRO_INT64, 0, 20, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(22, "BankSiparis_id", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(23, "xml_resp", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(24, "Lineno", 0, Parameter.PRO_INTEGER, 0, 23, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(25, "SysNote", 0, Parameter.PRO_CHARACTER, 0, 24, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(26, "Statu", 0, Parameter.PRO_CHARACTER, 0, 25, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(27, "Err_code", 0, Parameter.PRO_CHARACTER, 0, 26, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(28, "prm1", 0, Parameter.PRO_CHARACTER, 0, 27, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(29, "prm2", 0, Parameter.PRO_CHARACTER, 0, 28, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(30, "prm3", 0, Parameter.PRO_CHARACTER, 0, 29, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(31, "prm4", 0, Parameter.PRO_CHARACTER, 0, 30, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(32, "ctime", 0, Parameter.PRO_DATETIME, 0, 31, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(33, "Udate", 0, Parameter.PRO_DATE, 0, 32, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(34, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 33, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(35, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 34, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(36, "recSt", 0, Parameter.PRO_CHARACTER, 0, 35, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(37, "delst", 0, Parameter.PRO_LOGICAL, 0, 36, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(38, "RecCount", 0, Parameter.PRO_INTEGER, 0, 37, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(39, "Siparis_id", 0, Parameter.PRO_CHARACTER, 0, 38, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(40, "Siparis_Statu", 0, Parameter.PRO_CHARACTER, 0, 39, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(41, "Musteri_id", 0, Parameter.PRO_CHARACTER, 0, 40, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(42, "Musteri_adi", 0, Parameter.PRO_CHARACTER, 0, 41, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(43, "Telefon", 0, Parameter.PRO_CHARACTER, 0, 42, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(44, "Fatura_no", 0, Parameter.PRO_CHARACTER, 0, 43, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(45, "Tutar", 0, Parameter.PRO_DECIMAL, 0, 44, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(46, "Toplam_tutar", 0, Parameter.PRO_DECIMAL, 0, 45, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(47, "Olusturma_zamani", 0, Parameter.PRO_CHARACTER, 0, 46, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(48, "OlusturmaTrh", 0, Parameter.PRO_DATE, 0, 47, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(49, "Aciklama", 0, Parameter.PRO_CHARACTER, 0, 48, 0, "", "", 0, null, "");
		OrderBc_Set_app_MetaData1.setFieldDesc(50, "ExtOrderID", 0, Parameter.PRO_CHARACTER, 0, 49, 0, "", "", 0, null, "");

		OrderBcList_Get_app_MetaData1 = new DataTableMetaData(0, "ORDERBC_TT", 50, false, 1, "1,OrderBcNum:ind1", null, null, "sp4net.StrongTypesNS.ORDERBC_TTDataTable");
		OrderBcList_Get_app_MetaData1.setFieldDesc(1, "CorpNum", 0, Parameter.PRO_INTEGER, 0, 0, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(2, "CustNum", 0, Parameter.PRO_INTEGER, 0, 1, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(3, "cdate", 0, Parameter.PRO_DATE, 0, 2, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(4, "OrderBcNum", 0, Parameter.PRO_INT64, 0, 3, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(5, "RetailNum", 0, Parameter.PRO_INTEGER, 0, 4, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(6, "RetailName", 0, Parameter.PRO_CHARACTER, 0, 5, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(7, "itemCode", 0, Parameter.PRO_CHARACTER, 0, 6, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(8, "ItemName", 0, Parameter.PRO_CHARACTER, 0, 7, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(9, "qty", 0, Parameter.PRO_DECIMAL, 0, 8, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(10, "Price", 0, Parameter.PRO_DECIMAL, 0, 9, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(11, "TotalPrice", 0, Parameter.PRO_DECIMAL, 0, 10, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(12, "TaxRate1", 0, Parameter.PRO_DECIMAL, 0, 11, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(13, "TaxAmt1", 0, Parameter.PRO_DECIMAL, 0, 12, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(14, "TaxRate2", 0, Parameter.PRO_DECIMAL, 0, 13, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(15, "TaxAmt2", 0, Parameter.PRO_DECIMAL, 0, 14, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(16, "GrandTotal", 0, Parameter.PRO_DECIMAL, 0, 15, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(17, "CostAmt", 0, Parameter.PRO_DECIMAL, 0, 16, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(18, "CostType", 0, Parameter.PRO_LOGICAL, 0, 17, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(19, "CostRate", 0, Parameter.PRO_DECIMAL, 0, 18, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(20, "CustTransAmt", 0, Parameter.PRO_DECIMAL, 0, 19, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(21, "BankTransID", 0, Parameter.PRO_INT64, 0, 20, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(22, "BankSiparis_id", 0, Parameter.PRO_CHARACTER, 0, 21, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(23, "xml_resp", 0, Parameter.PRO_CHARACTER, 0, 22, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(24, "Lineno", 0, Parameter.PRO_INTEGER, 0, 23, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(25, "SysNote", 0, Parameter.PRO_CHARACTER, 0, 24, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(26, "Statu", 0, Parameter.PRO_CHARACTER, 0, 25, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(27, "Err_code", 0, Parameter.PRO_CHARACTER, 0, 26, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(28, "prm1", 0, Parameter.PRO_CHARACTER, 0, 27, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(29, "prm2", 0, Parameter.PRO_CHARACTER, 0, 28, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(30, "prm3", 0, Parameter.PRO_CHARACTER, 0, 29, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(31, "prm4", 0, Parameter.PRO_CHARACTER, 0, 30, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(32, "ctime", 0, Parameter.PRO_DATETIME, 0, 31, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(33, "Udate", 0, Parameter.PRO_DATE, 0, 32, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(34, "CrtUser", 0, Parameter.PRO_CHARACTER, 0, 33, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(35, "UpdUser", 0, Parameter.PRO_CHARACTER, 0, 34, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(36, "recSt", 0, Parameter.PRO_CHARACTER, 0, 35, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(37, "delst", 0, Parameter.PRO_LOGICAL, 0, 36, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(38, "RecCount", 0, Parameter.PRO_INTEGER, 0, 37, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(39, "Siparis_id", 0, Parameter.PRO_CHARACTER, 0, 38, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(40, "Siparis_Statu", 0, Parameter.PRO_CHARACTER, 0, 39, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(41, "Musteri_id", 0, Parameter.PRO_CHARACTER, 0, 40, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(42, "Musteri_adi", 0, Parameter.PRO_CHARACTER, 0, 41, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(43, "Telefon", 0, Parameter.PRO_CHARACTER, 0, 42, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(44, "Fatura_no", 0, Parameter.PRO_CHARACTER, 0, 43, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(45, "Tutar", 0, Parameter.PRO_DECIMAL, 0, 44, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(46, "Toplam_tutar", 0, Parameter.PRO_DECIMAL, 0, 45, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(47, "Olusturma_zamani", 0, Parameter.PRO_CHARACTER, 0, 46, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(48, "OlusturmaTrh", 0, Parameter.PRO_DATE, 0, 47, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(49, "Aciklama", 0, Parameter.PRO_CHARACTER, 0, 48, 0, "", "", 0, null, "");
		OrderBcList_Get_app_MetaData1.setFieldDesc(50, "ExtOrderID", 0, Parameter.PRO_CHARACTER, 0, 49, 0, "", "", 0, null, "");


        }


    //---- Constructors
    public sp4(Connection connectObj) : this(connectObj, false)
    {       
    }
    
    // If useWebConfigFile = true, we are creating AppObject to use with Silverlight proxy
    public sp4(Connection connectObj, bool useWebConfigFile)
    {
        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            if ((connectObj.Url == null) || (connectObj.Url.Equals("")))
                connectObj.Url = "asbroker1";

            if (useWebConfigFile == true)
                connectObj.GetWebConfigFileInfo("sp4");

            initAppObject("asbroker1",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
   
    public sp4(string urlString,
                        string userId,
                        string password,
                        string appServerInfo)
    {
        Connection connectObj;

        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            connectObj = new Connection(urlString,
                                        userId,
                                        password,
                                        appServerInfo);

            initAppObject("asbroker1",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

            /* release the connection since the connection object */
            /* is being destroyed.  the user can't do this        */
            connectObj.ReleaseConnection();

        }
        catch (System.Exception e)
        {
            throw e;
        }
    }


    public sp4(string userId,
                        string password,
                        string appServerInfo)
    {
        Connection connectObj;

        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            connectObj = new Connection("asbroker1",
                                        userId,
                                        password,
                                        appServerInfo);

            initAppObject("asbroker1",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

            /* release the connection since the connection object */
            /* is being destroyed.  the user can't do this        */
            connectObj.ReleaseConnection();
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public sp4()
    {
        Connection connectObj;

        try
        {
            if (RunTimeProperties.DynamicApiVersion != PROXY_VER)
                throw new Open4GLException(WrongProxyVer, null);

            connectObj = new Connection("asbroker1",
                                        null,
                                        null,
                                        null);

            initAppObject("asbroker1",
                          connectObj,
                          RunTimeProperties.tracer,
                          null, // requestID
                          proxyGenVersion);

            /* release the connection since the connection object */
            /* is being destroyed.  the user can't do this        */
            connectObj.ReleaseConnection();
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

        /// <summary>
	/// 
	/// </summary> 
	public string dlltest(string PRUNAME, string PRPWD, out string PRMSG)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(3);

		// Set up input parameters
		parms.setStringParameter(1, PRUNAME, ParameterSet.INPUT);
		parms.setStringParameter(2, PRPWD, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(3, null, ParameterSet.OUTPUT);


		// Setup local MetaSchema if any params are tables



		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("dlltest.p", parms);


		// Get output parameters
		outValue = parms.getOutputParameter(3);
		PRMSG = (string)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string ProParsBankTransZiraat_cr(sp4net.StrongTypesNS.BANKA_TTDataTable BANKA_TT)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		ParameterSet parms = new ParameterSet(1);

		// Set up input parameters
		parms.setDataTableParameter(1, BANKA_TT, ParameterSet.INPUT, "sp4net.StrongTypesNS.BANKA_TTDataTable");


		// Set up input/output parameters


		// Set up Out parameters


		// Setup local MetaSchema if any params are tables
		MetaSchema ProParsBankTransZiraat_cr_MetaSchema = new MetaSchema();
		ProParsBankTransZiraat_cr_MetaSchema.addDataTableSchema(ProParsBankTransZiraat_cr_MetaData1, 1, ParameterSet.INPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("ProParsBankTransZiraat_cr.p", parms, ProParsBankTransZiraat_cr_MetaSchema);


		// Get output parameters


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string dlltest_tt(string PRUNAME, string PRPWD, out string PRMSG, out sp4net.StrongTypesNS.TEST_TTDataTable TEST_TT)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(4);

		// Set up input parameters
		parms.setStringParameter(1, PRUNAME, ParameterSet.INPUT);
		parms.setStringParameter(2, PRPWD, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(3, null, ParameterSet.OUTPUT);
		parms.setDataTableParameter(4, null, ParameterSet.OUTPUT, "sp4net.StrongTypesNS.TEST_TTDataTable");


		// Setup local MetaSchema if any params are tables
		MetaSchema dlltest_tt_MetaSchema = new MetaSchema();
		dlltest_tt_MetaSchema.addDataTableSchema(dlltest_tt_MetaData1, 4, ParameterSet.OUTPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("dlltest_tt.p", parms, dlltest_tt_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(3);
		PRMSG = (string)outValue;
		outValue = parms.getOutputParameter(4);
		TEST_TT = (sp4net.StrongTypesNS.TEST_TTDataTable)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string BankTrans_Update(string PRAPIKEY, string PRIP, int PRBANK_TRANSID, string PREXT_ORDERID, out string PRMSG)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(5);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setIntegerParameter(3, PRBANK_TRANSID, ParameterSet.INPUT);
		parms.setStringParameter(4, PREXT_ORDERID, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(5, null, ParameterSet.OUTPUT);


		// Setup local MetaSchema if any params are tables



		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/BankTrans_Update.p", parms);


		// Get output parameters
		outValue = parms.getOutputParameter(5);
		PRMSG = (string)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string BankTransList_Get_app(string PRAPIKEY, string PRIP, string PRSDATE, string PREDATE, string PRBANKTRANS_ID, 
string PRSTATU, out string PRMSG, out sp4net.StrongTypesNS.BANKTRANS_TTDataTable BANKTRANS_TT)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(8);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setStringParameter(3, PRSDATE, ParameterSet.INPUT);
		parms.setStringParameter(4, PREDATE, ParameterSet.INPUT);
		parms.setStringParameter(5, PRBANKTRANS_ID, ParameterSet.INPUT);
		parms.setStringParameter(6, PRSTATU, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(7, null, ParameterSet.OUTPUT);
		parms.setDataTableParameter(8, null, ParameterSet.OUTPUT, "sp4net.StrongTypesNS.BANKTRANS_TTDataTable");


		// Setup local MetaSchema if any params are tables
		MetaSchema BankTransList_Get_app_MetaSchema = new MetaSchema();
		BankTransList_Get_app_MetaSchema.addDataTableSchema(BankTransList_Get_app_MetaData1, 8, ParameterSet.OUTPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/BankTransList_Get_app.p", parms, BankTransList_Get_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(7);
		PRMSG = (string)outValue;
		outValue = parms.getOutputParameter(8);
		BANKTRANS_TT = (sp4net.StrongTypesNS.BANKTRANS_TTDataTable)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string CustRetail_Set_app(string PRAPIKEY, string PRIP, sp4net.StrongTypesNS.RETAIL_TTDataTable RETAIL_TT, out string PRMSG)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(4);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setDataTableParameter(3, RETAIL_TT, ParameterSet.INPUT, "sp4net.StrongTypesNS.RETAIL_TTDataTable");


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(4, null, ParameterSet.OUTPUT);


		// Setup local MetaSchema if any params are tables
		MetaSchema CustRetail_Set_app_MetaSchema = new MetaSchema();
		CustRetail_Set_app_MetaSchema.addDataTableSchema(CustRetail_Set_app_MetaData1, 3, ParameterSet.INPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/CustRetail_Set_app.p", parms, CustRetail_Set_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(4);
		PRMSG = (string)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string CustRetailList_Get_app(string PRAPIKEY, string PRIP, string PRSDATE, string PREDATE, string PRRETAIL_NUM, 
string PRNAME, string PRGSM, string PRSTATU, out string PRMSG, out sp4net.StrongTypesNS.RETAIL_TTDataTable RETAIL_TT)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(10);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setStringParameter(3, PRSDATE, ParameterSet.INPUT);
		parms.setStringParameter(4, PREDATE, ParameterSet.INPUT);
		parms.setStringParameter(5, PRRETAIL_NUM, ParameterSet.INPUT);
		parms.setStringParameter(6, PRNAME, ParameterSet.INPUT);
		parms.setStringParameter(7, PRGSM, ParameterSet.INPUT);
		parms.setStringParameter(8, PRSTATU, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(9, null, ParameterSet.OUTPUT);
		parms.setDataTableParameter(10, null, ParameterSet.OUTPUT, "sp4net.StrongTypesNS.RETAIL_TTDataTable");


		// Setup local MetaSchema if any params are tables
		MetaSchema CustRetailList_Get_app_MetaSchema = new MetaSchema();
		CustRetailList_Get_app_MetaSchema.addDataTableSchema(CustRetailList_Get_app_MetaData1, 10, ParameterSet.OUTPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/CustRetailList_Get_app.p", parms, CustRetailList_Get_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(9);
		PRMSG = (string)outValue;
		outValue = parms.getOutputParameter(10);
		RETAIL_TT = (sp4net.StrongTypesNS.RETAIL_TTDataTable)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string item_Set_app(string PRAPIKEY, string PRIP, sp4net.StrongTypesNS.ITEM_TTDataTable ITEM_TT, out string PRMSG)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(4);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setDataTableParameter(3, ITEM_TT, ParameterSet.INPUT, "sp4net.StrongTypesNS.ITEM_TTDataTable");


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(4, null, ParameterSet.OUTPUT);


		// Setup local MetaSchema if any params are tables
		MetaSchema item_Set_app_MetaSchema = new MetaSchema();
		item_Set_app_MetaSchema.addDataTableSchema(item_Set_app_MetaData1, 3, ParameterSet.INPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/item_Set_app.p", parms, item_Set_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(4);
		PRMSG = (string)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string itemList_get_app(string PRAPIKEY, string PRIP, string PRSDATE, string PREDATE, string PRITEM_CODE, 
string PRCATEGORY1, string PRCATEGORY2, string PRNAME, string PRSTATU, out string PRMSG, 
out sp4net.StrongTypesNS.ITEM_TTDataTable ITEM_TT)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(11);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setStringParameter(3, PRSDATE, ParameterSet.INPUT);
		parms.setStringParameter(4, PREDATE, ParameterSet.INPUT);
		parms.setStringParameter(5, PRITEM_CODE, ParameterSet.INPUT);
		parms.setStringParameter(6, PRCATEGORY1, ParameterSet.INPUT);
		parms.setStringParameter(7, PRCATEGORY2, ParameterSet.INPUT);
		parms.setStringParameter(8, PRNAME, ParameterSet.INPUT);
		parms.setStringParameter(9, PRSTATU, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(10, null, ParameterSet.OUTPUT);
		parms.setDataTableParameter(11, null, ParameterSet.OUTPUT, "sp4net.StrongTypesNS.ITEM_TTDataTable");


		// Setup local MetaSchema if any params are tables
		MetaSchema itemList_get_app_MetaSchema = new MetaSchema();
		itemList_get_app_MetaSchema.addDataTableSchema(itemList_get_app_MetaData1, 11, ParameterSet.OUTPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/itemList_get_app.p", parms, itemList_get_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(10);
		PRMSG = (string)outValue;
		outValue = parms.getOutputParameter(11);
		ITEM_TT = (sp4net.StrongTypesNS.ITEM_TTDataTable)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string OrderBc_Set_app(string PRAPIKEY, string PRIP, sp4net.StrongTypesNS.ORDERBC_TTDataTable ORDERBC_TT, out string PRMSG)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(4);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setDataTableParameter(3, ORDERBC_TT, ParameterSet.INPUT, "sp4net.StrongTypesNS.ORDERBC_TTDataTable");


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(4, null, ParameterSet.OUTPUT);


		// Setup local MetaSchema if any params are tables
		MetaSchema OrderBc_Set_app_MetaSchema = new MetaSchema();
		OrderBc_Set_app_MetaSchema.addDataTableSchema(OrderBc_Set_app_MetaData1, 3, ParameterSet.INPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/OrderBc_Set_app.p", parms, OrderBc_Set_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(4);
		PRMSG = (string)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}

/// <summary>
	/// 
	/// </summary> 
	public string OrderBcList_Get_app(string PRAPIKEY, string PRIP, string PRSDATE, string PREDATE, string PRORDERBC_NUM, 
string PRRETAIL_NUM, string PRSIPARIS_ID, string PRMUSTERI_ID, string PRNAME, string PRSIPARIS_STATU, 
string PRSTATU, string PRDELST, out string PRMSG, out sp4net.StrongTypesNS.ORDERBC_TTDataTable ORDERBC_TT)
	{
		RqContext rqCtx = null;
		if (isSessionAvailable() == false)
			throw new Open4GLException(NotAvailable, null);

		Object outValue;
		ParameterSet parms = new ParameterSet(14);

		// Set up input parameters
		parms.setStringParameter(1, PRAPIKEY, ParameterSet.INPUT);
		parms.setStringParameter(2, PRIP, ParameterSet.INPUT);
		parms.setStringParameter(3, PRSDATE, ParameterSet.INPUT);
		parms.setStringParameter(4, PREDATE, ParameterSet.INPUT);
		parms.setStringParameter(5, PRORDERBC_NUM, ParameterSet.INPUT);
		parms.setStringParameter(6, PRRETAIL_NUM, ParameterSet.INPUT);
		parms.setStringParameter(7, PRSIPARIS_ID, ParameterSet.INPUT);
		parms.setStringParameter(8, PRMUSTERI_ID, ParameterSet.INPUT);
		parms.setStringParameter(9, PRNAME, ParameterSet.INPUT);
		parms.setStringParameter(10, PRSIPARIS_STATU, ParameterSet.INPUT);
		parms.setStringParameter(11, PRSTATU, ParameterSet.INPUT);
		parms.setStringParameter(12, PRDELST, ParameterSet.INPUT);


		// Set up input/output parameters


		// Set up Out parameters
		parms.setLongCharParameter(13, null, ParameterSet.OUTPUT);
		parms.setDataTableParameter(14, null, ParameterSet.OUTPUT, "sp4net.StrongTypesNS.ORDERBC_TTDataTable");


		// Setup local MetaSchema if any params are tables
		MetaSchema OrderBcList_Get_app_MetaSchema = new MetaSchema();
		OrderBcList_Get_app_MetaSchema.addDataTableSchema(OrderBcList_Get_app_MetaData1, 14, ParameterSet.OUTPUT);


		// Set up return type
		

		// Run procedure
		rqCtx = runProcedure("webservice/OrderBcList_Get_app.p", parms, OrderBcList_Get_app_MetaSchema);


		// Get output parameters
		outValue = parms.getOutputParameter(13);
		PRMSG = (string)outValue;
		outValue = parms.getOutputParameter(14);
		ORDERBC_TT = (sp4net.StrongTypesNS.ORDERBC_TTDataTable)outValue;


		if (rqCtx != null) rqCtx.Release();


		// Return output value
		return (string)(parms.ProcedureReturnValue);

	}



    }
}

