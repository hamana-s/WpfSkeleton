using FluentAssertions;
using Models.Services;
using System;
using UnitTest.Infrastructures;
using Xbehave;

namespace UnitTest.Tests
{
    public class CalculationTest
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CalculationTest()
        { }

        /// <summary>
        /// 計算テスト
        /// </summary>
        /// <param name="value1">値</param>
        /// <param name="value2">値</param>
        /// <param name="sum">結果</param>
        [Scenario(DisplayName = "計算テスト")]
        [CSVAttribute(@"..\..\..\TestFiles\計算結果一致.csv")]
        public void SumTest(uint value1, uint value2, uint sum)
        {
            var cal = new Calculation();

            "加算した値が正しい事"
                .x(() => { cal.Sum(value1, value2).Should().Be(sum, "値が一致"); });


            "計算結果がオーバーフローすること"
                .x(() =>
                {
                    Action action = () => cal.Sum(uint.MaxValue, 1);
                    action.Should().Throw<OverflowException>();
                });
        }
    }
}
