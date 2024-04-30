using EntityLayer.Concrete;

namespace Communication_App_Core.Models
{
    public class InboxViewModel
    {
        public List<Message> ReceiverMessages { get; set; }
        public List<Message> AllMessages { get; set; }
    }
}
