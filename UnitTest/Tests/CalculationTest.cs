using FluentAssertions;
using UnitTest.Infrastructures;
using Xbehave;

namespace UnitTest.Tests
{
    public class CalculationTest : TestBase
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CalculationTest() : base()
        { }

        /// <summary>
        /// 計算テスト
        /// </summary>
        /// <param name="value1">値</param>
        /// <param name="value2">値</param>
        /// <param name="sum">結果</param>
        [Scenario]
        [TestDataGenerator(@"..\..\..\TestFiles\計算結果一致.csv")]
        public void SumTest(int value1, int value2, int sum)
        {
            "値の計算(一致)"
                .x(() => { Calculation.Sum(value1, value2).Should().Be(sum, "値が一致"); });
        }
    }
}
