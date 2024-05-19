using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; }

        //public User(string F,string L,string P,string E,string Ps,int R)
        //{
        //    this.FirstName = F;
        //    this.LastName = L;
        //    Phone = P;
        //    Email = E;
        //    Password = P;
        //    Role = R;
        //}
    }
}
