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
    public class BinarySearch1
    {
        [TestMethod]
        public void BinarySearch_TestPositive()
        {
            int[] arr = {1,2,3,4,5,6,7,8,9,10};

            for(int i = 0; i < arr.Length; i++)
            {
                int indexFound = BinarySearch(arr, arr[i]);
                Assert.IsTrue(indexFound == i);
            }
        }

        [TestMethod]
        public void BinarySearch_TestNegative1()
        {
            List<int> arr = new List<int>(new int[] { 1, 4, 7, 12, 20, 21 });
            int itemToSearch = 0;

            int indexFound = BinarySearch(arr, itemToSearch);
            Assert.IsTrue(indexFound == arr.BinarySearch(itemToSearch));
        }

        [TestMethod]
        public void BinarySearch_TestNegative2()
        {
            List<int> arr = new List<int>(new int[] { 1, 4, 7, 12, 20, 21 });
            int itemToSearch = 22;

            int indexFound = BinarySearch(arr, itemToSearch);
            Assert.IsTrue(indexFound == arr.BinarySearch(itemToSearch));
        }

        [TestMethod]
        public void BinarySearch_TestNegative3()
        {
            List<int> arr = new List<int>(new int[] { 1, 4, 7, 12, 20, 21 });
            int itemToSearch = 13;

            int indexFound = BinarySearch(arr, itemToSearch);
            Assert.IsTrue(indexFound == arr.BinarySearch(itemToSearch));
        }

        private int BinarySearch<T>(IList<T> list, T value)
            where T : IComparable<T>
        {
            if (list == null || list.Count == 0 || value == null)
            {
                return -1;
            }
            return SerchInRange<T>(list, value, 0, list.Count - 1);
        }

        private int SerchInRange<T>(IList<T> list, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            int index = (endIndex + startIndex) / 2;
            int rangeLength = endIndex - startIndex + 1;

            if (value.CompareTo(list[index]) == 0)
            {
                return index;
            }
            if (value.CompareTo(list[index]) < 0)
            {
                if(rangeLength > 1)
                {
                    return SerchInRange(list, value, startIndex, index - 1);
                }
                return ~index;
            }
            if (value.CompareTo(list[index]) > 0)
            {
                if (rangeLength > 1)
                {
                    return SerchInRange(list, value, index + 1, endIndex);
                }
                return (index == list.Count - 1) ? ~list.Count : ~(index + 1);
            }
            return -1;
        }
    }
}
