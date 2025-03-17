using FluentAssertions;
using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using LukeSkywalker.UI.Modules;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LukeSkywalker.UnitTest.ModuleTests;

public class InfoAboutStarshipsTest
{
    private IInfoAboutStarships _sut;
    private IStarshipService _starshipService = Substitute.For<IStarshipService>();
    private ILogger<IInfoAboutStarships> _logger = Substitute.For<ILogger<IInfoAboutStarships>>();
    public InfoAboutStarshipsTest()
    {
        _sut = new InfoAboutStarships(_starshipService, _logger);
        InitMocks();
    }

    private void InitMocks()
    {
        _starshipService.GetInfoAboutStarships(Arg.Any<List<int>>()).Returns(x => ((List<int>)x[0]).Any() ?
                                                                            Task.FromResult(new List<StarshipDto>()
                                                                            {
                                                                                new StarshipDto
                                                                                {
                                                                                    Name = ((List<int>)x[0])[0].ToString(),
                                                                                }
                                                                            })
                                                                            : Task.FromResult(new List<StarshipDto>()));
    }

    [Test]
    [TestCase(new object[] { "1", "https://swapi.dev/api/starship/1/" })]
    [TestCase(new object[] { "11", "lalalla11/" })]
    [TestCase(new object[] { "231", "/-231/" })]
    public async Task GetInfo_CorrectInput_ShouldReturnMovieList(params string[] input)
    {
        var expected = input[0];
        var urlCollection = new List<string> { input[1] };

        var actual = await _sut.GetInfo(urlCollection);

        actual.Should().NotBeNull();
        actual.Should().HaveCount(1);
        actual[0].Name.Should().Be(expected);
    }


    [Test]
    [TestCase(new object[] { "https://swapi.dev/api/films/foo/" })]
    [TestCase(new object[] { "lalalla/" })]
    [TestCase(new object[] { "/@#$%^&*()/" })]
    [TestCase(new object[] { "" })]
    public async Task GetInfo_IncorrectInput_ShouldReturnEmptyCollection(params string[] input)
    {
        var urlCollection = input.ToList();

        var actual = await _sut.GetInfo(urlCollection);

        actual.Should().NotBeNull();
        actual.Should().HaveCount(0);
    }
}

