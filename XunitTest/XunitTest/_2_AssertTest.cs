using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XunitTest
{
    public class _2_AssertTest
    {
        #region Equal
        [Fact]
        public void SimpleEqual()
        {
            Assert.Equal(1,1);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(1, 2)]
        public void EqualWithParams(int a,int b)
        {
            Assert.Equal(a,b);
        }
        #endregion

        #region Contain

        [Theory]
        [InlineData("A")]
        [InlineData("a")]
        public void SimpContain(string p)
        {
            var list = new List<string>(){"a","b","c","A","B","C"};
            Assert.Contains(p, list);
        }

        private class MyClass : IEqualityComparer<MyClass>
        {
            public int Id { get; set; }

            public string Name { get; set; }
            public bool Equals(MyClass x, MyClass y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(MyClass obj)
            {
                return obj.ToString().GetHashCode();
            }
        }

        [Fact]
        public void ClassContain()
        {
            var items = new List<MyClass>(){new MyClass(){Id = 2,Name ="name222"},new MyClass(){Id = 222,Name = "name222" } };
            Assert.Contains(new MyClass(){Id = 222,Name = "222"}, items,new MyClass());
        }

        #endregion


        #region Throws 判断抛什么异常
        [Fact]
        public void WitchThrow()
        {
            Assert.Throws<Exception>(() =>
            {
                throw new Exception("this is an exception!");
                return;
            });
        }
        #endregion
    }
}
