using NUnit.Framework;
using System.Threading.Tasks;
using contactsios.model;
using System.Collections.Generic;

namespace contactsios.proxy.tests
{
    [TestFixture()]
    public class ContactProxyTests
    {
        [Test()]
        public async Task GetContacts_ShouldReturnContacts()
        {
            var sut = new ContactProxy();

            IList<Contact> actual = await sut.GetContacts();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Count, Is.EqualTo(30));
        }
    }
}

