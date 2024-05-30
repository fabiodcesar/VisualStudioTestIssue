using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Core.Service.Test.AppSettings;

public class AppSettingsTests
{
    [Fact]
    public void ShouldHaveTestSetting()
    {
        // Arrange
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = builder.Build();

        string appsettingsContent = File.ReadAllText($"{AppContext.BaseDirectory}/appsettings.json");

        // Act
        string testSetting = configuration.GetSection("TestSetting").Value;

        // Assert
        testSetting.Should().NotBeNull(appsettingsContent);
    }
}
