using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest
{
    public class _4_AllDispose:IDisposable
    {
        private Xunit.Abstractions.ITestOutputHelper _outputHelper { get; set; }

        public _4_AllDispose(Xunit.Abstractions.ITestOutputHelper iTestOutputHelper)
        {
            this._outputHelper = iTestOutputHelper;
        }

        [Fact]
        public void First()
        {
            _outputHelper.WriteLine(nameof(First));
        }
        [Fact]
        public void Second()
        {
            _outputHelper.WriteLine(nameof(Second));
        }

        public static List<object[]> Members()
        {
            var ret =new List<object[]>();
            for (int i = 1; i <= 10; i++)
            {
                ret.Add(new object[]{ $"member:{i}"});
            }
            return ret;
        }

        [Theory]
        [MemberData(nameof(Members))]
        public void MemberThird(string ret)
        {
            _outputHelper.WriteLine(ret);
        }


        public void Dispose()
        {
            _outputHelper.WriteLine("Dispose！！！");
        }
    }
}
