using System.Threading.Tasks;
using Herman.Base.Web.Controllers;
using Shouldly;
using Xunit;

namespace Herman.Base.Web.Tests.Controllers
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




