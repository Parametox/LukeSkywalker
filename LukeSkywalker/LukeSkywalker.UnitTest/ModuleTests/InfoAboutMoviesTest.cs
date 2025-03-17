using FluentAssertions;
using LukeSkywalker.Core.Dtos;
using LukeSkywalker.Services.Abstractions;
using LukeSkywalker.UI.Modules;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LukeSkywalker.UnitTest.ModuleTests;

public class InfoAboutMoviesTest
{
    private IInfoAboutMovies _sut;
    private IMovieService _movieService = Substitute.For<IMovieService>();
    private ILogger<IInfoAboutMovies> _logger = Substitute.For<ILogger<IInfoAboutMovies>>();
    public InfoAboutMoviesTest()
    {
        _sut = new InfoAboutMovies(_movieService, _logger);
        InitMocks();
    }

    private void InitMocks()
    {
        _movieService.GetInfoAboutMovies(Arg.Any<List<int>>()).Returns(x => ((List<int>)x[0]).Any()? 
                                                                            Task.FromResult(new List<MovieDto>()
                                                                            {
                                                                                new MovieDto
                                                                                {
                                                                                    Title = ((List<int>)x[0])[0].ToString(),
                                                                                }
                                                                            }) 
                                                                            : Task.FromResult(new List<MovieDto>()));
    }

    [Test]
    [TestCase(new object[] { "1", "https://swapi.dev/api/films/1/" })]
    [TestCase(new object[] { "11", "lalalla11/" })]
    [TestCase(new object[] { "231", "/-231/" })]
    public async Task GetInfo_CorrectInput_ShouldReturnMovieList(params string[] input)
    {
        var expected = input[0];
        var urlCollection = new List<string> { input[1] };

        var actual = await _sut.GetInfo(urlCollection);

        actual.Should().NotBeNull();
        actual.Should().HaveCount(1);
        actual[0].Title.Should().Be(expected);  
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

