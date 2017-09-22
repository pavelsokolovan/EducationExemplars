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
    public class ArrayType
    {
        [TestMethod]
        public void Array1()
        {
            var ints = new int[11];
            Console.Out.WriteLine(ints.GetType());

            // create object of type Array/MyStruct[] in heap and put reference to stack
            var myStructs = new MyStruct[11];
            Console.Out.WriteLine(myStructs.GetType());

            var myClasses = new MyClass[11];
            Console.Out.WriteLine(myClasses.GetType());

            var myClass = new MyClass();
            Console.Out.WriteLine(myClass.GetType());

            IList list = myStructs;
            Console.Out.WriteLine(list.IsFixedSize); // true
            // list.Add(new MyStruct { A = 12, S = "12" });  error - collection has fixed size

        }

        //class MyClassArray: Array { }  // - error - can't derive from special class Array

        struct MyStruct
        {
            public int A { get; set; }
            public string S { get; set; }
        }

        class MyClass
        {
            public int A { get; set; }
            public string S { get; set; }
        }

        
    }
}
