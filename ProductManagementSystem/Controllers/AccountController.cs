using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProductManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _db;
        public AccountController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(Regsitration regsitration)
        {
            var result = new Regsitration { FirstName = regsitration.FirstName, LastName = regsitration.LastName,EmailId = regsitration.EmailId,Password = regsitration.Password, IsActive = true,ProfileImage=regsitration.ProfileImage, IsVerified = false, };
           _db.RegistrationTable.Add(result);
           _db.SaveChanges();
            var ResgisId = _db.RegistrationTable.Max(x => x.Id);
            ViewBag.Message = "Registration Successfully";
           return View();
        }
        //SendEmail(regsitration.EmailId, ResgisId);
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            var result = _db.RegistrationTable.Where(x => x.EmailId == login.EmailId && x.Password == login.Password).ToList().Count();
            if (result > 0)
            {
                return RedirectToAction("CrudOperation", "Crud");
            }
            else
            {
                ViewBag.Message = "UserName and Pssword Not Match Or not registerd this user name";
            }
            return View();
        }
        public static bool SendEmail(string emailId,int OTP)
        {
            try
            {
                bool result = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("biswajitk637@gmail.com", "7979721476");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "Registration Successfully. Your One Time Password"+ OTP;
                mailMessage.From = new MailAddress("biswajitk637@gmail.com");
                mailMessage.To.Add(emailId);
                mailMessage.Subject = "Registration Save Successfully";
              //  mailMessage.AlternateViews.Add(htmlBody);
                mailMessage.Body = htmlBody;
                smtp.Send(mailMessage);
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
