namespace Exercicio.Contracts;

public interface IOnlinePaymenteService
{
    public double PaymentFee(double amount);
    public double Interest(int mounth, double amount);
}
