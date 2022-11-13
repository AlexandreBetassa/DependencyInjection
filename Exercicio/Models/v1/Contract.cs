using System.Text.Json.Serialization;

namespace Exercicio.Models.v1
{
    public class Contract
    {
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
            return $"Número contrato: {Number}\nData de assinatura: {Date: dd/MM/yyyy hh:mm:ss}\nValor Contratato: R${TotalValue:F} " +
                $"Valor a ser pago: R${Installments.Sum(installment => installment.Amount):F}".ToString();
        }
    }
}
