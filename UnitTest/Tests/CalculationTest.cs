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
            var result = 0;

            "値初期化"
                .x(() => { result = 30; });

            "値の計算(一致)"
                .x(() => { Calculation.Sum(10, 20).Should().Be(result, "値が一致"); });

            "値の計算(不一致)"
                .x(() => { Calculation.Sum(20, 20).Should().Be(result, "値が不一致"); });
        }
    }
}
