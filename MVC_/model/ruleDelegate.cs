using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC_.model
{
    
    public class RuleDelegate
    {
        public delegate void RuleHandler(object o1);

        public static Delegate CreateHandler(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
                throw new ArgumentNullException(ruleName);

            Type type = Type.GetType("MVC_.model.rule." + ruleName + ", MVC_");      // 通过类名获取同名类
            Object obj = System.Activator.CreateInstance(type);       // 创建实例
            MethodInfo method = type.GetMethod("Execute", new Type[] { typeof(object) });
            return Delegate.CreateDelegate(typeof(RuleHandler), obj, method);
        }
    }
    

}
