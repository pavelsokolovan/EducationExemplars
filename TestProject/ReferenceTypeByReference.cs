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
    public class ReferenceTypeByReference
    {
        [TestMethod]
        public void RefTypeByRef()
        {
            string st = "str";
            StringManipulationRef(ref st);
            StringManipulation(st);
            Console.Out.WriteLine(st);
        }

        [TestMethod]
        public void ValTypeByRef()
        {
            int t = 11;
            IntManipulationRef(ref t);
            IntManipulation(t);
            Console.Out.WriteLine(t);
        }
                
        private void StringManipulation(string a)
        {
            a = "Manipulation";
        }

        private void StringManipulationRef(ref string a)
        {
            a = "ManipulationNoRef";
        }

        private void IntManipulation(int a)
        {
            a = 22;
        }

        private void IntManipulationRef(ref int a)
        {
            a = 33;
        }
    }
}
