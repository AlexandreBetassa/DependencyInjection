namespace Exercicio.Services.v1.Interfaces;

internal interface IOnlinePaymenteService
{
    public double PaymentFee(double amount);
    public double Interest(int mounth, double amount);
}
