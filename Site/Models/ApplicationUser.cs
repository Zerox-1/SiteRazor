namespace Site.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
