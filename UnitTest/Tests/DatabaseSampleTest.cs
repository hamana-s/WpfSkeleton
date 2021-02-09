using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Models.DB.Tables;
using UnitTest.Infrastructures;
using Xbehave;

namespace UnitTest.Tests
{
    public class DatabaseSampleTest : DBTestBase
    {
        [Scenario]
        public void GetSamplesTest()
        {
            "テーブルが空の際は空のデータが返却されること"
                .x(async () => (await dataContext.Samples.ToArrayAsync()).Should().BeEmpty());

            "レコードの追加に成功すること"
                .x(async () =>
                {
                    await dataContext.Samples.AddRangeAsync(new Sample[]{
                        new (){ Data = "データ1" },
                        new (){ Data = "データ2" },
                    });
                    await dataContext.SaveChangesAsync();
                    (await dataContext.Samples.ToArrayAsync()).Should().BeEquivalentTo(new Sample[]{
                        new (){ ID = 1, Data = "データ1" },
                        new (){ ID = 2, Data = "データ2" },
                    });
                });
        }
    }
}