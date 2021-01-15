namespace Models.Services
{
    /// <summary>計算クラス</summary>
    public sealed class Calculation : ICalculation
    {
        /// <summary>合計算出</summary>
        /// <param name="a">対象A</param>
        /// <param name="b">対象B</param>
        /// <returns>計算結果</returns>
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
}