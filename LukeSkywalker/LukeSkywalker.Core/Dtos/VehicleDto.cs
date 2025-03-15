using Newtonsoft.Json;

namespace LukeSkywalker.Core.Dtos;
public class VehicleDto
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    [JsonProperty("cost_in_credits")]
    public string CostInCredits { get; set; }
    public double Length { get; set; }
    [JsonProperty("max_atmosphering_speed")]
    public int MaxAtmospheringSpeed { get; set; }
    public int Crew { get; set; }
    public int Passengers { get; set; }
    [JsonProperty("cargo_capacity")]
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; }
    [JsonProperty("vehicle_class")]
    public string VehicleClass { get; set; }
}