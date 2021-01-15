using Models.Services;
using System;
using System.Text;
using Xbehave;

namespace UnitTest.Infrastructures
{
    public class TestBase : IDisposable
    {
        protected ICalculation Calculation { get; private set; } = null!;

        [Background]
        public void Background()
        {
            Calculation = new Calculation();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
