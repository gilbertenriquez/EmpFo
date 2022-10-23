using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using static EmpFo.App;
using Firebase.Database.Query;
using System.Collections.ObjectModel;


namespace EmpFo.Models
{

    public class Employee
    {


        public string Image { get; set; }
        public string eFName { get; set; }
        public string eMid { get; set; }
        public string eLName { get; set; }
        public string eMail { get; set; }
        public string ePhone { get; set; }
        public string eAddress { get; set; }
        public string ePosition { get; set; }


        public async Task<bool> Addemployees(string Fname, string Mid, string Lname,string email,string phone,string Address, string Position)
        {
            try
            {
                var employeeAddress = (await client.Child("Employee")
                    .OnceAsync<Employee>())
                    .FirstOrDefault(a => a.Object.eMail == email);

                if (employeeAddress == null)
                {
                    var employee = new Employee()
                    {
                        eMail = email, 
                        eFName = Fname,
                        eMid = Mid,
                        eLName = Lname, 
                        ePhone= phone,
                        eAddress = Address,
                        ePosition = Position

                    };
                    await client
                        .Child("Employee")
                        .PostAsync(employee);
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

        public async Task<string> GetEmployKey(string mail)
        {
            try
            {
                var getemploykey = (await client.Child("Employee").OnceAsync<Employee>()).
                    FirstOrDefault(a => a.Object.eMail == mail);
                if (getemploykey == null) return null;

                firstname = getemploykey.Object.eFName;
                 middlename = getemploykey.Object.eMid;
                 lastname = getemploykey.Object.eLName;
                phone = getemploykey.Object.ePhone;
                homeaddress = getemploykey.Object.eAddress;
                jobposition = getemploykey.Object.ePosition;
                 

                return getemploykey?.Key;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<bool> EditEmployData(string fname, string Midname,string lname,string Phones,string homeaddress,string jobPos)
        {
            try
            {
                var employeeAddress = (await client
                    .Child("Employee")
                    .OnceAsync<Employee>())
                    .FirstOrDefault
                    (a => a.Object.eMail == email);
                if (employeeAddress != null)
                {
                    Employee user = new Employee
                    {
                        eMail = email,
                        eFName = fname,
                        eMid = Midname,
                        eLName = lname,
                        ePhone = Phones,
                        eAddress = homeaddress,                       
                        ePosition = jobPos
                    };
                    await client.Child("Employee").Child(key).PatchAsync(user);
                    client.Dispose();
                }
                client.Dispose();
                return false;
            }
            catch (Exception ex)
            {
                client.Dispose();
                return false;
            }
        }
        public async Task<string> DeleteEmploydata()
        {
            try
            {
                await client
                    .Child($"Employee/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }

        //Getting All data
        public async Task<List<Employee>> GetAllUsers()
        {

            return (await client
                .Child("Employee")
                .OnceAsync<Employee>()).Select(item => new Employee
                {
                    eFName = item.Object.eFName,
                    eMid = item.Object.eMid,
                    eLName = item.Object.eLName,
                    eMail = item.Object.eMail,
                    ePhone = item.Object.ePhone,
                    eAddress = item.Object.eAddress,
                    ePosition = item.Object.ePosition

                }).ToList();
        }
        //Actual query of the data
        public async Task<List<Employee>> FindEmployee(string fname)
        {
            try
            {
                var queryUsers = await GetAllUsers();
                await client
                    .Child("Employee")
                    .OnceAsync<Employee>();
                    return queryUsers.Where(a => string.Equals(a.eFName, fname, StringComparison.CurrentCultureIgnoreCase)).ToList();

            }
            catch(Exception ex)
            {
                return null;
            }
         }

        public ObservableCollection<Employee> GetEmployeesList()
        {
            var employeelist = client
                 .Child("Employee")
                .AsObservable<Employee>()
                .AsObservableCollection();
            return employeelist;

        }

    }
}
