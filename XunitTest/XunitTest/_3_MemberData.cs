using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest
{
    public class _3_MemberData
    {
        private Xunit.Abstractions.ITestOutputHelper _outputHelper { get; set; }

        public _3_MemberData(Xunit.Abstractions.ITestOutputHelper iTestOutputHelper)
        {
            this._outputHelper = iTestOutputHelper;
        }

        public class MyClass
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public static List<object[]> MemberDatas()
        {
            var ret = new List<object[]>();
            for (int i = 1; i < 100; i++)
            {
                ret.Add(new object[]{new MyClass(){Id = i,Name = $"name_{i}"}});
            }
            return ret;
        }

        [Theory]
        [MemberData(nameof(MemberDatas))]
        public void WiterClass(MyClass item)
        {
            _outputHelper.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
        }

    }
}
