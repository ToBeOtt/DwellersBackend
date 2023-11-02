using Dwellers.Common.Data.Models.Household;
using Dwellers.Common.Persistance;

namespace TestDomain
{
    public class TestService
    {
        private readonly ITestRepository project;

        public TestService(ITestRepository project)
        {
            this.project = project;
        }

        public void GetWine()
        {
            TestEntity YESDOMAIN = new TestEntity();
            DwellerUserEntity YES = new();
            project.GetDestilledWine();
        }
    }
}
