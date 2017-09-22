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
    public class ParamsInMethod
    {
        [TestMethod]
        public void ParamsInMethod1()
        {
            int sum = Sum(1, 2, 3, 4);
            Console.WriteLine(sum);
        }       

        private int Sum(params int[] values)
        {
            return values.Sum();
        }
    }
}
