using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVC_.model.entity
{
    public class CustEventArgs : EventArgs
    {

    }



    public class EntityWithDelegate : BaseModel
    {
        public event RuleDelegate.RuleHandler RegisteredRules;

        public void Calculate()
        {

            RegisteredRules(this);
        }

        public void display()
        {
            foreach (string key in base.dict.Keys)
            {
                Console.WriteLine($"{key} :    {base.dict[key]}");
            }
        }
    }














    //public class TestModel:BaseModel
    //{
    //    public event RuleDelegate.RuleHandler RegisteredRules;

    //    public TestModel(Dictionary<string, string> arguments)
    //    {
    //        this.arguments = arguments;

    //    }

    //    public void Calculate()
    //    {

    //        RegisteredRules(this);
    //    }

    //    public void display()
    //    {
    //        foreach(string key in base.arguments.Keys)
    //        {
    //            Console.WriteLine(base.arguments[key]);
    //        }
    //    }
    //}

    ////xml读取
    //public class TestModel1 : BaseModel1
    //{
    //    public TestModel1(XElement node): base(node)
    //    {

    //    }
    //}





    //public class TestXml
    //{
    //    public int id;
    //    public string name;

    //    public TestXml()
    //    {
    //        id = 1;
    //        name = "phq";
    //    }
    //}

}
