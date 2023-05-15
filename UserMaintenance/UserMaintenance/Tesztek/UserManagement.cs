using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record User(string Firstname, string Lastname)
{
    public int Id { get; set; }

    public int Name { get; set; }

    public string Jelszo { get; set; }

    public bool VerifiedName { get; set; }

}

namespace KliensTest.Tesztek
{
    public class UserManagement
    {
        private readonly List<User> _users = new List<User>();

        private int idCounter = 1;

        public IEnumerable<User> AllUsers => _users;
        

        public void Add(User user)
        {
            _users.Add(user with {Id = idCounter++});
        }

        public void VerifyName(int userID)
        {
            var dbUser = _users.First(x => x.Id == userID);

            dbUser.VerifiedName = true;
        }

    }
}
