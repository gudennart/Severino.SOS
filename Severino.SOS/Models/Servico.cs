using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Severino.SOS.Models
{
    public partial class Service
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("categoria")]
        public int Categoria { get; set; }

        [JsonPropertyName("tipo")]
        public int Tipo { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("titulo")]
        public string Title { get; set; }

        [JsonPropertyName("tag")]
        public string Tags { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("User")]
        public User User { get; set; }

        [JsonPropertyName("Schedules")]
        public List<Schedule> Schedules { get; set; }

        [JsonPropertyName("Assessments")]
        public List<Assessment> Assessments { get; set; }

        [JsonPropertyName("Address")]
        public Address Address { get; set; }
    }

    public partial class Assessment
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nota")]
        public int Nota { get; set; }

        [JsonPropertyName("conteudo")]
        public string Conteudo { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("service_id")]
        public int ServiceId { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
    }

    public partial class Schedule
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dia")]
        public int Dia { get; set; }
        public string DiaSemana { get; set; }

        [JsonPropertyName("de")]
        public string De { get; set; }

        [JsonPropertyName("ate")]
        public string Ate { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("service_id")]
        public int ServiceId { get; set; }
    }

}
