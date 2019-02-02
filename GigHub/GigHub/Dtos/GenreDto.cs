using Newtonsoft.Json;

namespace GigHub.Dtos
{
    public class GenreDto
    {
        [JsonProperty]
        public byte Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
    }
}