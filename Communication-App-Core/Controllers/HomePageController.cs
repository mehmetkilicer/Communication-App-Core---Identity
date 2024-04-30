using BusinessLayer.Concrete;
using Communication_App_Core.Models;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Communication_App_Core.Controllers
{
    [Authorize]
    public class HomePageController : Controller
    {
        MessageManager MessageManager = new MessageManager(new EfMessageDal());
        AppUserManager userManager1 =new AppUserManager(new EfAppUserDal());
        ProjeContext context = new ProjeContext();
        private readonly UserManager<AppUser> _userManager;
     

        public HomePageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var values=userManager1.TGetAll();
            
            return View(values);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            List<SelectListItem> values = (from x in context.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.Values = values;
            return View();
     
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message p)
        {
            List<SelectListItem> values1 = (from x in context.Users.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.Values = values1;
       
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p.DateTime = DateTime.Now;
            p.SenderId = values.Id;
            p.ImportantMessage = true;
            p.MessageTrash = false;
            p.ImageUrl = values.ImageUrl;
            p.Name = values.Name;
            p.Surname = values.Surname;

            var receiverName = context.Users.Where(u => u.Id == p.ReceiverId)
                .Select(u => u.Name)
                .FirstOrDefault();


            var receiverSurName = context.Users.Where(u => u.Id == p.ReceiverId)
            .Select(u => u.Surname)
            .FirstOrDefault();

            var receiverImage= context.Users.Where(u => u.Id == p.ReceiverId)
        .Select(u => u.ImageUrl)
        .FirstOrDefault();

            p.ReceiverSurname = receiverSurName;
            p.ReceiverName = receiverName;
            p.ReceiverImageUrl = receiverImage;

            MessageManager.TInsert(p);
            return RedirectToAction("SendMessage");

        }
        public async Task<IActionResult> Inbox(int p)
        {
        
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Id; 
            var messageList = MessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }
        public async Task<IActionResult> SendBox(int p)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Id;
            var messageList = MessageManager.GetListSenderMessage(p);
            return View(messageList);
        }
        public IActionResult DeleteSentMessages(int id) 
        {
            var values=context.Messages.Where(x=>x.MessageId == id).FirstOrDefault();
            values.MessageTrash = true;
            context.SaveChanges();
            return RedirectToAction("SendBox");
        }
        public IActionResult DeleteReceivedMessages(int id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            values.MessageTrash = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public IActionResult MessageDetails(int id)
        {
            var value=MessageManager.TGetById(id);
            return View(value);
        }
        public async Task<IActionResult> UserSetting(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEditModel = new UserEditViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl


            };
            return View(userEditModel);
        }
        [HttpPost]
        public async Task<IActionResult> UserSetting(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.UserName = p.UserName;
            user.Email = p.Email;
            user.ImageUrl = p.ImageUrl;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("index", "Login");
            }
            return View();
        }
        public IActionResult InboxMessageDetail(int id)
        {
            Message message = MessageManager.TGetById(id);

            return View(message);
        }
        public IActionResult SendboxMessageDetail(int id)
        {
            Message message = MessageManager.TGetById(id);

            return View(message);
        }

    }
}
