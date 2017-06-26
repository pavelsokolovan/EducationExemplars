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
    public class NamedAndOptionalArguments
    {
        [TestMethod]
        public void NamedAndOptionalArgumentsTest()
        {
            Meth(true);
        }

        private void Meth(bool b, int i = default(Int32), string s = "S", DateTime dt = default(DateTime))
        {
            b = true;
            Console.WriteLine($"{b.ToString()} {i.ToString()} {s} {dt.ToString()}");
        }
    }
}
