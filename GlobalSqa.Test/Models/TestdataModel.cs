using Newtonsoft.Json;

namespace GlobalSqa.Test.Models
{
    public class TestdataModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("experience")]
        public string Experience { get; set; }

        [JsonProperty("expertise")]
        public string Expertise { get; set; }

        [JsonProperty("education")]
        public string Education { get; set; }
    }
}
