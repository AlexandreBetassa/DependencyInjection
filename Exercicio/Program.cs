using Exercicio.Models.v1;
using Exercicio.Services.v1;

Console.Write("Informe o número do contrato: ");
int.TryParse(Console.ReadLine(), out var numberContract);
Console.Write("Informe o valor total do contrato: ");
double.TryParse(Console.ReadLine(), out var value);
Console.Write("Informe o número de parcelas: ");
int.TryParse(Console.ReadLine(), out var mounths);

Contract contract = new() { Number = numberContract, Date = DateTime.Now, TotalValue = value };

ContractService contractService = new(new PaypalService());

contractService.ProcessContract(contract, mounths);
Console.WriteLine("### VALORES ###");
contract.Installments.ForEach(installments => Console.WriteLine(installments));