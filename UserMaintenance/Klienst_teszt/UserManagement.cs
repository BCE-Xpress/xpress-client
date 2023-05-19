using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace KliensTest.Tesztek
{
    public class UserManagement
    {
        public record User()
        {
            public string Jelszo { get; set; }
        }

        private readonly List<User> _users = new List<User>();

        public IEnumerable<User> AllUsers => _users;

        public User Register(string email, string jelszo)
        {
            if (!ValidatePassword(jelszo))
                throw new ValidationException(
                    "A megadottt jelszó nem megfelelő!\n" +
                    "A jelszó legalább 8 karakter hosszú kell legyen, csak az angol ABC betűiből és számokból állhat, " +
                    "és tartalmaznia kell legalább egy kisbetűt, egy nagybetűt és egy számot.");

            var account = new User()
            {
                Jelszo = jelszo
            };

            var newAccount = account;

            return newAccount;
        }
        public bool ValidatePassword(string password)
        {

            // Vizsgáljuk, hogy csak megfelelő karakterek vannak
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
            {
                return false;
            }

            // Minden feltétel teljesül, tehát visszatérünk true értékkel
            return true;
        }

    }
}
