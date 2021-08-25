using MVC_.model.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_.model.rule
{

    public class Rule002 : IBaseRule
    {
        public void Execute(object o1)
        {
            dynamic datamodel = o1 as BaseModel;



            double debit = datamodel.debit;
            double credit = datamodel.credit;


            datamodel.Debit = credit - debit;
            datamodel.Credit = 0;
        }
    }

    public class Rule003 : IBaseRule
    {
        public void Execute(object o1)
        {
            dynamic datamodel = o1 as BaseModel;
            double debit = datamodel.debit;
            double credit = datamodel.credit;

            datamodel.Credit = (-credit + debit);
            datamodel.Debit = 0;
        }
    }

    public class Rule004 : IBaseRule
    {
        public void Execute(object o1)
        {
            dynamic datamodel = o1 as BaseModel;
            double debit = datamodel.debit;
            double credit = datamodel.credit;

            datamodel.Credit = (-113210010000 * (credit - debit) - 601110010000 * (credit - debit));
            datamodel.Debit = 0;
        }
    }

        //public class Rule001 : IBaseRule
        //{
        //    public void Execute(object o1)
        //    {
        //        BaseModel datamodel = o1 as BaseModel;
        //        double debit = double.Parse(datamodel.GetArgumentValue("Debit"));
        //        double credit = double.Parse(datamodel.GetArgumentValue("Credit"));
        //        string account = datamodel.GetArgumentValue("Account");
        //        if (account.StartsWith("6"))
        //        {
        //            datamodel.SetArgumentValue("Debit", (credit - debit).ToString());
        //            datamodel.SetArgumentValue("Credit", "0");
        //        }
        //        else
        //        {
        //            if (credit - debit > 0)
        //            {
        //                datamodel.SetArgumentValue("Debit", (credit - debit).ToString());
        //                datamodel.SetArgumentValue("Credit", "0");
        //            }
        //            else
        //            {
        //                datamodel.SetArgumentValue("Credit", (-credit + debit).ToString());
        //                datamodel.SetArgumentValue("Debit", "0");
        //            }
        //        }
        //    }
        //}

    

}
