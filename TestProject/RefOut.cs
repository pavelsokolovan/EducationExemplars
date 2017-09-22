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
    public class RefOut
    {
        [TestMethod]
        public void ReferenceTypeByRef()
        {
            string st = "str";
            StringManipulationRef(ref st);
            StringManipulation(st);
            Console.Out.WriteLine(st);
        }

        [TestMethod]
        public void ValueTypeByRef()
        {
            int t = 11;
            IntManipulationRef(ref t);
            IntManipulation(t);
            Console.Out.WriteLine(t);
        }

        [TestMethod]
        public void ReferenceTypeByOut()
        {
            StringManipulationOut(out string t);
            Console.Out.WriteLine(t);
        }

        [TestMethod]
        public void ValueTypeByOut()
        {
            //int t = 11;  -  no sence  
            IntManipulationOut(out int t);
            Console.Out.WriteLine(t);
        }

        // overload
        private void OverloadMeth(ref int a) { }
        //private void OverloadMeth(out int a) { }   error  -  should be either ref or out
        private void OverloadMeth(int a) { }

        private void StringManipulation(string a)
        {
            a = "Manipulation";
        }

        private void StringManipulationRef(ref string a)
        {
            a = "ManipulationRef";
        }

        private void StringManipulationOut(out string a)
        {
            a = "ManipulationOut";
        }

        private void IntManipulation(int a)
        {
            a = 22;
        }

        private void IntManipulationRef(ref int a)
        {
            a = 33;
        }

        private void IntManipulationOut(out int a)
        {
            // int b = a;   error - 'a' should be initialized
            a = 22;
            int b = a;
        }
        
    }
}
