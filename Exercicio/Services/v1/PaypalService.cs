using Exercicio.Contracts;

namespace Exercicio.Services.v1;

public class PaypalService : IOnlinePaymenteService
{
    private const double _feePercentage = 0.02;
    private const double _monthlyInterest = 0.01;

    public double Interest(int mounth, double amount) => amount * _monthlyInterest * (double)mounth;

    public double PaymentFee(double amount) => amount * _feePercentage;
}
