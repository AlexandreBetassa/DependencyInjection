using ExercicioApi.Contracts.v1;
using MongoDB.Bson.Serialization.Attributes;

namespace Exercicio.Models.v1
{
    public class Contract : IEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public  string Id { get; set; }     
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract() => Installments = new List<Installment>();

        public void AddInstallment(Installment installment) => Installments.Add(installment);
    }
}
