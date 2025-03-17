using FluentAssertions;
using LukeSkywalker.Services.Abstractions;
using LukeSkywalker.UI.Modules;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LukeSkywalker.UnitTest.ModuleTests;

public class InfoAboutLukeTest
{
    private IInfoAboutLuke _sut;
    private ICharacterService _characterService = Substitute.For<ICharacterService>();
    private ILogger<IInfoAboutLuke> _logger = Substitute.For<ILogger<IInfoAboutLuke>>();
    public InfoAboutLukeTest()
    {
        _sut = new InfoAboutLuke(_characterService, _logger);
    }

    [Theory]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public async Task GetInfo_PositiveInput_ShouldReturnCharacterFullInfo(int id)
    {
        _characterService.GetInfoByCharacter(Arg.Any<int>()).Returns(Task.FromResult(new Core.CharacterFullInfo { Name = "lorem Ipsum" }));

        var actual = await _sut.GetInfo(id);

        actual.Should().NotBeNull();
        actual.Name.Should().Be("lorem Ipsum");
    }
}

