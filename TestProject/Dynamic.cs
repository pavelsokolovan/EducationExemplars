using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class DynamicType
    {
        [TestMethod]
        public void DynamicType1()
        {
            dynamic d = new MyClass();
            Object obj = d;  //  implicit cust 
            //string st = d;
        }       

        class MyClass
        {
            public int A { get; set; }
            public string S { get; set; }
        }

        
    }
}
