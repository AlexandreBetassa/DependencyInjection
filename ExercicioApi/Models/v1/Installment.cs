using ExercicioApi.Contracts.v1;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ExercicioApi.Models.v1;

public class Installment : IEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    [JsonPropertyName("DueDate")]
    public DateTime DueDate { get; set; }
    [JsonPropertyName("Amount")]
    public double Amount { get; set; }
}
