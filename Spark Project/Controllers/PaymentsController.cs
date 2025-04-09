using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Spark_Project.Models;
using Spark_Project.Repositories.Interfaces;

namespace Spark_Project.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : Controller
    {
        private IPaymentsRepository _repo;
        public PaymentsController(IPaymentsRepository repo)
        {
            _repo = repo;
        }



        [HttpPost]
        public ActionResult CreatePayment(Payment payment)
        {

            var results = _repo.CreatePayment(payment);
            if (!results)
                return StatusCode(500);

            return Created("The Payment was created succesfully", payment);
        }

        [HttpPatch]
        public ActionResult EditPayment(Payment payment) { 
        
         var result = _repo.UpdatePayment(payment, "1 'or 1=1 --you have been hacked'");
            if (!result) return StatusCode(500);
            return Ok("Payment was updated successfully ");
        }
        [HttpDelete("{paymentId:guid}")]
        public ActionResult DeletePayment(Guid paymentId) {
            var result = _repo.DeletePayment(paymentId);
            if (!result) return StatusCode(500);

            return Ok("Payment was deleted succesfuly");
        }

        [HttpGet]
        public  ActionResult GetAllPayments()
        {
            return Ok(_repo.GetAllPayments());
        }

    }
}