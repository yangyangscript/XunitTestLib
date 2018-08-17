using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest
{
    public class _1_ConsoleWriteTest
    {
        private Xunit.Abstractions.ITestOutputHelper _outputHelper { get; set; }

        public _1_ConsoleWriteTest(Xunit.Abstractions.ITestOutputHelper iTestOutputHelper)
        {
            this._outputHelper = iTestOutputHelper;
        }

        [Fact]
        public void TestWirte()
        {
            this._outputHelper.WriteLine("wirte something！");
        }
    }
}
