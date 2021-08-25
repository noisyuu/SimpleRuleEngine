using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVC_.model.entity
{
    public abstract class BaseModel : DynamicObject, IComparable
    {
        public Dictionary<string, object> dict;

        public BaseModel()
        {
            dict = new Dictionary<string, object>();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string key = binder.Name.ToLower();
            if (dict.ContainsKey(key))
            {
                result = dict[key];
                return true;
            }

            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dict[binder.Name.ToLower()] = value;
            return true;
        }


    }
    //public abstract class BaseModel : IComparable
    //{
    //    public Dictionary<string, string> arguments;

    //    public int CompareTo(object obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public string GetArgumentValue(string argumentName)
    //    {
    //        if (arguments.ContainsKey(argumentName))
    //        {
    //            return arguments[argumentName];
    //        }
    //        else
    //        {
    //            throw new KeyNotFoundException(argumentName + " not exits");
    //        }
    //    }

    //    public void SetArgumentValue(string argumentName, string value)
    //    {
    //        if (arguments.ContainsKey(argumentName))
    //        {
    //            arguments[argumentName] = value;
    //        }
    //        else
    //        {
    //            throw new KeyNotFoundException(argumentName + " not exits");
    //        }

    //    }

    //}





    //public abstract class BaseModel1 : DynamicObject, IComparable
    //{
    //    public XElement node;
    //    public BaseModel1(XElement node)
    //    {
    //        this.node = node;
    //    }

    //    public int CompareTo(object obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool TryGetMember(GetMemberBinder binder, out object result)
    //    {
    //        var elements = node.Elements().ToList();
    //        var currentElement = elements.FirstOrDefault(x => x.Name == binder.Name);
    //        if (currentElement != null)
    //        {
    //            result = currentElement.Value;
    //            return true;
    //        }
    //        else
    //        {
    //            result = null;
    //            return false;
    //        }
    //    }

    //    public override bool TrySetMember(SetMemberBinder binder, object value)
    //    {
    //        var elements = node.Elements().ToList();
    //        var currentElement = elements.FirstOrDefault(x => x.Name == binder.Name);
    //        if(currentElement != null)
    //        {
    //            currentElement.Value = value as string;
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }

    //    }

    //}











}
