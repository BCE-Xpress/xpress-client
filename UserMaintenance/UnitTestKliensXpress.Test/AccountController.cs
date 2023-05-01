using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestKliensXpress
{
    public class AccountController
    {
        
        public bool ValidateQuantity(int mennyiseg)
        {


            //A mennyiseg nem lehet nagyobb, mint 200
            if (mennyiseg > 200)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public bool ValidatePassword(string password)
        {

            // Vizsgáljuk, hogy helyes-e a jelszo ami jelen esetben 0
            if (password == "0")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
