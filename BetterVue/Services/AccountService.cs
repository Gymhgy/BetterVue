using System.Xml.Linq;

namespace BetterVue.Services {
    public interface IAccountService {
        User? User { get; }
        XDocument? Gradebook { get; }
        Task LoginAsync(User user);
        void Logout();
    }
    public class AccountService : IAccountService {
        public User? User { get; private set; }

        public XDocument? Gradebook { get; private set; }

        private readonly HttpClient http;
        public AccountService(HttpClient http) {
            this.http = http;
        }

        public async Task LoginAsync(User user) {
            User = user;
            Gradebook = await Utils.SendRequestAsync(user.Username, user.Password, user.Domain, "Gradebook", "", http);
        }

        public void Logout() {
            User = null;
            Gradebook = null;
        }
    }
}
