using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Spark_Project.Data;
using Spark_Project.Models;
using Spark_Project.Repositories.Interfaces;

namespace Spark_Project.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private ApplicationDbContext _db;

        public PaymentsRepository(ApplicationDbContext db) {
            _db = db;
        }

        public bool CreatePayment(Payment payment)
        {  
            _db.Payments.Add(payment);
            return SaveChanges();
        }

        public bool DeletePayment(Guid paymentId)
        {
            var payment = _db.Payments.FirstOrDefault(x => x.Id == paymentId);
            if (payment != null) { 
                _db.Payments.Remove(payment);
                return SaveChanges();

            }
            return false;
        }

        public List<Payment> GetAllPayments()
        {
            return _db.Payments.ToList();
        }

        public bool SaveChanges()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdatePayment(Payment payment, string name)
        {
            var userInput = "admin";
            var query = $"SELECT * FROM Users WHERE Username = '{userInput}'";
            var users = _db.Payments.FromSqlRaw(query).ToList();

            _db.Payments.Update(payment); return SaveChanges();  
        }
    }
}
