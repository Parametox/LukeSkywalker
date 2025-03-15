using Newtonsoft.Json;

namespace LukeSkywalker.Core.Dtos;

public class MovieDto
{
    public string Title { get; set; }
    [JsonProperty("episode_id")]
    public int EpisodeId { get; set; }
    [JsonProperty("opening_crawl")]
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    [JsonProperty("release_date")]
    public DateTime ReleaseDate { get; set; }
}

