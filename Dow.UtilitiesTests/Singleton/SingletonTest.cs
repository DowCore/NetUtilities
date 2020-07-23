using Dow.Utilities.Npoi;
using Dow.Utilities.Singleton;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Dow.UtilitiesTests.Singleton
{
    [TestClass()]
    public class SingletonTest
    {
        [TestMethod()]
        public void CreateSingleTonTest()
        {
            var singltonOne= SingletonBase<WorkbookFactory>.Instance.Singleton;
            var singletonTwo = SingletonBase<WorkbookFactory>.Instance.Singleton;

            for(int i=0;i<1000;i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine($"第{i + 1}次异步构造");
                    var singletonThere = SingletonBase<WorkbookFactory>.Instance.Singleton;
                    Assert.IsTrue(singltonOne == singletonThere, "多线程中的单例不可行");
                });
            }
            Assert.IsTrue(singltonOne== singletonTwo,"这样的单例不可行");
        }
    }
}
