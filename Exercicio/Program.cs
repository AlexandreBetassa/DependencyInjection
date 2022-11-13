using Exercicio.Controllers.v1;
using Exercicio.Services.v1;

Main();
void Main()
{
    ContractController contractController = new();
    do
    {
        var op = Menu();
        switch (op)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                contractController.NewContract();
                break;
            case 2:
                contractController.Get();
                break;
            case 3:
                contractController.GetOne();
                break;
            default:
                Console.WriteLine("Opção invélida");
                break;
        }
    } while (true);
}

int Menu()
{
    Console.Write("Informe a opção:\n0- Sair\n1 - Novo Contrato\n2 - Listar Todos\n3 - Buscar Contrato\n> ");
    int.TryParse(Console.ReadLine(), out int op);
    return op;
}