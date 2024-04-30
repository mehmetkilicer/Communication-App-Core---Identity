namespace Communication_App_Core.Models
{
    public class CreateRegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
    }
}
