using System.Globalization;
using System.Text.Json.Serialization;

namespace Exercicio.Models.v1;

public class Installment
{
    [JsonPropertyName("DueDate")]
    public DateTime DueDate { get; set; }
    [JsonPropertyName("Amount")]
    public double Amount { get; set; }

    public Installment(DateTime dueDate, double amount)
    {
        DueDate = dueDate;
        Amount = amount;
    }

    public override string ToString()
    {
        return DueDate.ToString("dd/MM/yyyy")
            + " - "
            + Amount.ToString("F2");
    }
}
