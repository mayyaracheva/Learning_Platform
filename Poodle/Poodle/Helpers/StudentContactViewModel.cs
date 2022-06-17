namespace Poodle.Web.Helpers
{
    public class StudentContactViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        [Email]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
