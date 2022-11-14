using ExercicioApi.Models.v1;
using ExercicioApi.Repositories.v1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExercicioApi.Controllers.v1.Tests
{
    [TestClass()]
    public class ContractControllerTests
    {
        [TestMethod()]
        public async Task PostTest()
        {
            var controller = new ContractController(new ContractRepositoryStub());
            var contract = new Contract() { Date = DateTime.Now, Id = "1234", Installments = new(), Number = "123456", TotalValue = 2500 };
            var result = controller.Post(contract);
            Assert.AreEqual(result.Result, contract);
        }

        [TestMethod()]
        public void GetTest()
        {
            var controller = new ContractController(new ContractRepositoryStub());
            var result = controller.Get().Result;
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }
    }
}