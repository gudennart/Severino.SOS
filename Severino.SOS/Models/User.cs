using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Severino.SOS.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("whatsapp")]
        public string Whatsapp { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password_hash")]
        public string PasswordHash { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("is_proff")]
        public bool IsProff { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("Images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("Services")]
        public List<Service> Services { get; set; }

        [JsonPropertyName("Addresses")]
        public List<Address> Address { get; set; }
    }
}
