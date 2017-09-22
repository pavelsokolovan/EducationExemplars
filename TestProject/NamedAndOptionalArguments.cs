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
            MyDelegat del1 = Meth;
            del1(true, dt: DateTime.Now, i: 11);
            Meth(false, sss: "string", ii: 111);

            MyDelegat del2 = delegate(bool b, int i, string s, DateTime dt) {};
            MyDelegat del3 = (bool b, int i, string s, DateTime dt) => {};
        }

        private void Meth(bool bb, int ii = default(Int32), string sss = "S", DateTime dtt = default(DateTime))
        {
            bb = true;
            Console.WriteLine($"{bb.ToString()} {ii.ToString()} {sss} {dtt.ToString()}");
        }

        private delegate void MyDelegat(bool b, int i = default(Int32), string s = "S", DateTime dt = default(DateTime));
    }
}
