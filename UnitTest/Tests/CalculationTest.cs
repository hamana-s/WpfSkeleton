using FluentAssertions;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xbehave;
using Xunit.Abstractions;
using WpfSkeleton.Services;
using Xunit;
using UnitTest.Infrastructures;

namespace UnitTest.Tests
{
    public class CalculationTest : TestBase
    {

        public CalculationTest() : base()
        {
        }

        /// <summary>
        /// 計算テスト
        /// </summary>
        [Scenario]
        public void SumTest()
        {
            int result = 0;
            int actual;

            "値初期化"
                .x(() => { result = 30; });

            "値の計算1"
                .x(() => { actual = Calculation.Sum(10, 20); Assert.Equal(result, actual); });

            "値の計算2"
                .x(() => { actual = Calculation.Sum(20, 20); Assert.Equal(result, actual); });
        }
    }
}
