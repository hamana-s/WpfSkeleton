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
        [TestDataGenerator(@"..\..\..\TestFiles\計算結果一致.csv")]
        public void SumTest1(int value1, int value2, int sum)
        {
            "値の計算(一致)"
                .x(() => { Calculation.Sum(value1, value2).Should().Be(sum, "値が一致"); });
        }

        /// <summary>
        /// 計算テスト
        /// </summary>
        [Scenario]
        [TestDataGenerator(@"..\..\..\TestFiles\計算結果不一致.csv")]
        public void SumTest2(int value1, int value2, int sum)
        {
            "値の計算(不一致)"
                .x(() => { Calculation.Sum(value1, value2).Should().NotBe(sum, "値が不一致"); });
        }
    }
}
