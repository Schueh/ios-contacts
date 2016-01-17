using NUnit.Framework;
using System.Threading.Tasks;
using contactsios.model;

namespace contactsios.proxy.tests
{
    [TestFixture()]
    public class ContactProxyTests
    {
        [Test()]
        public async Task GetContact_ShouldReturnContact()
        {
            var sut = new ContactProxy();

            Contact actual = await sut.GetContact();

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.FirstName, Is.Not.Empty);
        }
    }
}

