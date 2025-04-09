using Spark_Project.Models;

namespace Spark_Project.Repositories.Interfaces
{
    public interface IPaymentsRepository
    {
        public bool CreatePayment(Payment payment);
        public bool UpdatePayment(Payment payment, string name);
        public bool DeletePayment(Guid paymentId);
        public List<Payment> GetAllPayments();
        public bool SaveChanges();
    }
}
