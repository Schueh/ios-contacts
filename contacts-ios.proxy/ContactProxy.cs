using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using contactsios.model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace contactsios.proxy
{
    public class ContactProxy
    {
        public async Task<IList<Contact>> GetContacts()
        {
            string randomUsersJson = await GetUsersJson();

            List<Result> randomUsers = JsonConvert.DeserializeObject<RootObject>(randomUsersJson).results;

            return randomUsers.Select(x => new Contact
                {
                    FirstName = x.user.name.first,
                    LastName = x.user.name.last,
                    Address = new Address
                    {
                        Street = x.user.location.street,
                        Zip = x.user.location.zip,
                        City = x.user.location.city
                    },
                    Email = x.user.email,
                    Phone = x.user.phone,
                    Picture = x.user.picture.medium
                }).ToList();
        }

        private async Task<string> GetUsersJson()
        {
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/?results=30"))
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
   