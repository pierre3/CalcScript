using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace CalcScript
{
    public class ScriptingHost
    {
        public static double cos(double degree)
        {
            return Math.Cos(degree * Math.PI/180);
        }

        public static double sin(double degree)
        {
            return Math.Sin(degree * Math.PI/180);
        }
    }
}
