using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using static EmpFo.App;
using Firebase.Database.Query;


namespace EmpFo.Models
{
    public class Admin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }




        public async Task<bool> Addadmin(string fname, string lname, string mail, string pword)
        {
            try
            {
                var evaluateEmail = (await client.Child("Admin")
                    .OnceAsync<Admin>())
                    .FirstOrDefault(a => a.Object.Email == mail);

                if (evaluateEmail == null)
                {
                    var admin = new Admin()
                    {
                        FirstName = fname,
                        LastName = lname,
                        Email = mail,
                        Password = pword
                    };
                    await client
                        .Child("Admin")
                        .PostAsync(admin);
                    client.Dispose();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> AdminLogin(string email, string Pass)
        {
            try
            {
                var evaluateEmail = (await client.Child("Admin")
                                  .OnceAsync<Admin>())
                                  .FirstOrDefault
                                  (a => a.Object.Email == email &&
                                   a.Object.Password == Pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }

        }
    }
}
