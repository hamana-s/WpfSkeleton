using System;
using System.Text;
using Xbehave;

namespace UnitTest.Infrastructures
{
    public class TestBase : IDisposable
    {

        [Background]
        public static void Background()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
