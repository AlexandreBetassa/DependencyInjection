using System.Text.Json.Serialization;

namespace Exercicio.Models.v1
{
    public class Contract
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }
        [JsonPropertyName("Number")]
        public string Number { get; set; }
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("TotalValues")]
        public double TotalValue { get; set; }
        [JsonPropertyName("Installments")]
        public List<Installment> Installments { get; set; }

        public Contract() => Installments = new List<Installment>();

        public void AddInstallment(Installment installment) => Installments.Add(installment);

        public override string ToString()
        {
            return $"ID: {Id}\nNúmero contrato: {Number}\nData de assinatura: {Date: dd/MM/yyyy hh:mm:ss}\n" +
                $"Valor Contratato: R${TotalValue:F}\n" +
                $"Valor a ser pago: R${Installments.Sum(installment => installment.Amount):F}".ToString();
        }
    }
}
