using System.ComponentModel.DataAnnotations;

namespace BetterVue {
    public class User {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Domain { get; set; } = "portal.sfusd.edu";
    }
}
