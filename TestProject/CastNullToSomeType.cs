using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class CastNullToSomeType
    {
        [TestMethod]
        public void CastNullToString()
        {
            // Imlicity
            string st1 = null;
            int? i = null; Nullable<int> i1 = null;
            // Explicity
            string st = (string)null;   // no exception
            Console.Out.WriteLine("'{0}'", st);            
        }
    }
}
