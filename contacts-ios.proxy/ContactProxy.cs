using System.Net.Http;
using System.Threading.Tasks;
using contactsios.model;
using Newtonsoft.Json;

namespace contactsios.proxy
{
    public class ContactProxy
    {
        public async Task<Contact> GetContact()
        {
            string userJson = await GetUserJson();

            dynamic userObject = JsonConvert.DeserializeObject<dynamic>(userJson).results[0].user;

            return new Contact
            {
                FirstName = userObject.name.first,
                LastName = userObject.name.last,
                Address = new Address
                    {
                        Street = userObject.location.street,
                        Zip = userObject.location.zip,
                        City = userObject.location.city
                    },
                Email = userObject.email,
                Phone = userObject.phone,
                Picture = userObject.picture.medium
            };
        }

        private async Task<string> GetUserJson()
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/"))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();                       
                    }
                }
            }
        }

    }
}
   