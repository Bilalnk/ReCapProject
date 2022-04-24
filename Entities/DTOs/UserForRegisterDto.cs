#region info

// Bilal Karataş20220424

#endregion

namespace Entities.DTOs
{
    public class UserForRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}