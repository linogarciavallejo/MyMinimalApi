using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using MyMinimalApi.Services;
using Moq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MyMinimalApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MyMinimalApi.Tests {
    public class ApiTests {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly Mock<IPetService> _mockPetService;

        public ApiTests() {
            _mockPetService = new Mock<IPetService>();

            _server = new TestServer(new WebHostBuilder()
                                              .UseStartup<Program>().ConfigureServices(services => {
                                                  services.AddRouting();
                                                  services.AddEndpointsApiExplorer();
                                                  services.AddSwaggerGen();
                                                  services.AddSingleton(_mockPetService.Object);
                                                  services.RemoveAll(typeof(PetContext));
                                                  services.AddDbContext<PetContext>(options => options.UseInMemoryDatabase("PetDb"));
                                              })
                                              .Configure((context,app) => {
                                                  app.UseRouting();
                                                  if (context.HostingEnvironment.IsDevelopment()) {
                                                      app.UseSwagger();
                                                      app.UseSwaggerUI();
                                                  }

                                                  app.UseHttpsRedirection();

                                                  EndpointConfiguration.MapEndpoints(app);
                                              }));
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Get_ReturnsOk_ForExistingPet() {

            //Arrange
            var petId = 1;
            _mockPetService.Setup(s => s.GetPet(petId)).ReturnsAsync(new Data.Models.Pet { Id = petId, Name = "Fido", Age = 3 });

            //Act
            var response = await _client.GetAsync($"/{petId}");

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}