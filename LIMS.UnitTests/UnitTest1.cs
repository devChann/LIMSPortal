using System;
using Xunit;

namespace LIMS.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(5, Add(3, 2));

        }

        int Add(int x, int y) => x + y;
    }
}
