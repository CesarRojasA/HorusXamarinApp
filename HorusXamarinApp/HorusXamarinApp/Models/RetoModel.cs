using Newtonsoft.Json;

namespace HorusXamarinApp.Models
{
    public class RetoModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currentPoints")]
        public int CurrentPoints { get; set; }

        [JsonProperty("totalPoints")]
        public int TotalPoints { get; set; }

        public string PorcentajeDeAvance => (CurrentPoints * 100 / TotalPoints).ToString() + "%";
        public double ValorDelProgreso => CurrentPoints * 100 / TotalPoints * 0.01;
    }
}
