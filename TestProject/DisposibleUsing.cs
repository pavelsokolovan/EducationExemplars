using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class DisposibleUsing
    {
        [TestMethod]
        public void Using()
        {
            using (StreamWriter streamWriter1 = new StreamWriter("someFile1.txt"),
                streamWriter2 = new StreamWriter("someFile11.txt"))
            {
                streamWriter1.Write("some string");
                streamWriter2.Write("some string");
            }
        }

        [TestMethod]
        public void UsingWrong()
        {
            StreamWriter streamWriter1 = new StreamWriter("someFile1.txt");
            using (streamWriter1)
            {
                streamWriter1.Write("some string");
            }
            streamWriter1.WriteLine();
        }

        [TestMethod]
        public void TryCatch()
        {
            string fileName = "someFile2.txt";
            using (var streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write("some string");
            }

            string txt = string.Empty;
            //var streamReader = new StreamReader(fileName);
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(fileName);
                GC.SuppressFinalize(streamReader);
                txt = streamReader.ReadToEnd();                
            }
            catch(FileNotFoundException e){}
            catch (Exception e) { }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }                
            }            
        }

        [TestMethod]
        public void MyDisposable()
        {
            using(var myResource = new DerivedResourceClass())
            {
                myResource.Meth();
            }
        }

        [TestMethod]
        public void DisposableInForeach()
        {
            // Dispose is implemented in Enumerator and is not colled in foreach
            List<string> list2 = new List<string>();
            foreach (string item in list2)
            {

            }
            
        }
    }


    class BaseResourceClass : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            disposed = true;
        }

        ~BaseResourceClass()
        {
            Dispose(false);
        }
    }

    class DerivedResourceClass : BaseResourceClass
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //

            disposed = true;
            // Call base class implementation.
            base.Dispose(disposing);
        }

        public void Meth()
        {
            
        }

        ~DerivedResourceClass()
        {
            Dispose(false);
        }
    }
}
