using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HorusXamarinApp.Models
{
    public class LoginResponseModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("authorizationToken")]
        public string AuthorizationToken { get; set; }

    }
}
