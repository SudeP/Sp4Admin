using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sp4net;
using sp4net.StrongTypesNS;

namespace SP4ADMIN.Models
{
    public class Tester
    {
        public void Testem(string PRAPIKEY,
                           string PRIP,
                           int PRBANK_TRANSID,
                           string PREXT_ORDERID,
                           out string PRMSG)
        {
            new sp4().BankTrans_Update(PRAPIKEY,
                                       PRIP,
                                       PRBANK_TRANSID,
                                       PREXT_ORDERID,
                                       out PRMSG);
        }
    }
}