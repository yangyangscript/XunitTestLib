using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest
{
    public class OnceDClass : IDisposable
    {
        public static int countss { get; set; }

        public int times { get; set; } = 0;

        public string showStr {
            get { return $"this is {countss}/////////{times}"; }
             }

        public OnceDClass()
        {
            OnceDClass.countss++;
        }

        public void Dispose()
        {
            countss = 999;
        }
    }

    public class _5_OnleonceDispose: IClassFixture<OnceDClass>
    {
        private static int fTimes { get; set; } = 0;
        private Xunit.Abstractions.ITestOutputHelper _outputHelper { get; set; }

        private OnceDClass _onceDClass { get; set; }

        public _5_OnleonceDispose(Xunit.Abstractions.ITestOutputHelper iTestOutputHelper,OnceDClass item)
        {
            fTimes++;
            this._outputHelper = iTestOutputHelper;
            item.times = fTimes;
            this._onceDClass = item;
        }

        [Fact]
        public void First()
        {
            _outputHelper.WriteLine(_onceDClass.showStr);
        }
        [Fact]
        public void Second()
        {
            _outputHelper.WriteLine(_onceDClass.showStr);
        }
        [Fact]
        public void Third()
        {
            _outputHelper.WriteLine(_onceDClass.showStr);
        }
    }
}
