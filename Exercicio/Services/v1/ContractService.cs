using Exercicio.Contracts;
using Exercicio.Models.v1;

namespace Exercicio.Services.v1;

public class ContractService : IContractService
{
    private readonly IOnlinePaymenteService _paypalService;
    private readonly IContractRepository _contractRepository;

    public ContractService(IOnlinePaymenteService paypalService, IContractRepository contractRepository)
    {
        _paypalService = paypalService;
        _contractRepository = contractRepository;
    }

    public ContractService(IContractRepository contractRepository) => _contractRepository = contractRepository;

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

    public void Get()
    {
        var lstContracts = _contractRepository.Get().Result;
        foreach (Contract contract in lstContracts)
        {
            Console.WriteLine(contract.ToString());
            PrintInstallments(contract);
            Console.WriteLine();
        }

    }

    public void GetOne()
    {
        Console.Write("Informe o numero do contrato: ");
        var numberContract = Console.ReadLine();
        var contract = _contractRepository.Get(numberContract).Result;
        if (contract != null)
        {
            Console.WriteLine(contract.ToString());
            PrintInstallments(contract);
            Console.WriteLine();
        }
        else Console.WriteLine("Nao encontrado");
    }

    public void NewContract()
    {
        Console.Write("Informe o número do contrato: ");
        var numberContract = Console.ReadLine();
        Console.Write("Informe o valor total do contrato: ");
        double.TryParse(Console.ReadLine(), out var value);
        Console.Write("Informe o número de parcelas: ");
        int.TryParse(Console.ReadLine(), out var mounths);
        Contract contract = new() { Number = numberContract, Date = DateTime.Now, TotalValue = value };
        ProcessContract(contract, mounths);
        if (_contractRepository.Create(contract).Result)
        {
            Console.WriteLine("### VALORES ###");
            contract.Installments.ForEach(installments => Console.WriteLine(installments));
        }
        else Console.WriteLine("Erro");
    }

    private void PrintInstallments(Contract contract) => contract.Installments.ForEach(item => Console.WriteLine("R$:" + item.ToString()));

}
