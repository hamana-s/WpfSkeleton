using System;
using System.IO;
using System.Text;
using Xbehave;
using Xunit.Abstractions;
using WpfSkeleton.Services;

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
