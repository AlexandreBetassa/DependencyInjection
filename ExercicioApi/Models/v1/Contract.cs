using ExercicioApi.Contracts.v1;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ExercicioApi.Models.v1
{
    public class Contract : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [JsonPropertyName("Number")]
        public string Number { get; set; }
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("TotalValues")]
        public double TotalValue { get; set; }
        [JsonPropertyName("Installments")]
        public List<Installment> Installments { get; set; }

    }
}
