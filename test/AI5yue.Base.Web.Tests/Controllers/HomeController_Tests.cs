using System.Threading.Tasks;
using AI5yue.Base.Web.Controllers;
using Shouldly;
using Xunit;

namespace AI5yue.Base.Web.Tests.Controllers
{
    public class HomeController_Tests: BaseWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}


