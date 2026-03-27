using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Mail);

            string passworddResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var passwordReseTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passworddResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();


            MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal Rezervasyon", "traversaldeneme");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("Sayın Misafir", model.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = "ŞİFRE DEĞİŞİKLİK TALEBİ";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordReseTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);


            smtpClient.Authenticate("traversaldeneme", "qdiqwwionyanlllg");

            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            if (userid == null || token == null)
            {
                //hatamesajı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
        }
    }
}
