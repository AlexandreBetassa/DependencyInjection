using Exercicio.Models.v1;
using Exercicio.Services.v1.Interfaces;

namespace Exercicio.Services.v1;

public class ContractService
{
    private readonly IOnlinePaymenteService _paypalService;

    public ContractService(PaypalService paypalService) => _paypalService = paypalService;

    public void ProcessContract(Contract contract, int month)
    {
        double baseValue = contract.TotalValue / month;
        for (int i = 1; i <= month; i++)
        {
            DateTime date = contract.Date.AddMonths(i);
            double updateValueQuota = baseValue + _paypalService.Interest(i, baseValue);
            double ValueFullQuota = updateValueQuota + _paypalService.PaymentFee(updateValueQuota);
            contract.AddInstallment(new Installment(date, ValueFullQuota));
        }

    }

}
