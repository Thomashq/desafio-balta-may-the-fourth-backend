using MayTheFourth.Models;

namespace MayTheFourth.Domain.Responses;
public class GetPlanetWithPaginationResponse
{
    public int totalCount { get; set; } = 0;
    public int skip { get; set; } = 0;
    public int take { get; set; } = 0;
    public List<Planet> data { get; set; } = [];
}
