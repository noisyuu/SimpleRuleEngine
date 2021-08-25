using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_.model.rule
{
    interface ICalculationRule : IBaseRule
    {
        double Execute(double A, double B);
    }

}
