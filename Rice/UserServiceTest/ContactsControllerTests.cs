using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using UserService.Controllers;
using UserService.DTOs.Contact;
using UserService.Repositories.Contact;
using UserService.Requests.Contact;

namespace UserServiceTest
{
    public class ContactsControllerTests
    {
        [Fact]
        public void Post()
        {
            var repository = A.Fake<IContactRepository>();
            var request = new ContactPostRequest();
            var fakeUser = A.Dummy<ContactReadDto>();
            A.CallTo(() => repository.Create(request)).Returns(fakeUser);
            var controller = new ContactsController(repository);
            // Act

            var actionResult = controller.Post(request);
            // Assert
            var result = actionResult.Id;
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete()
        {
            var repository = A.Fake<IContactRepository>();
            var returnDto = A.Dummy<Boolean>();
            Guid id = new Guid("1ea6e753-971d-4413-a611-60cb99278222");
            A.CallTo(() => repository.Delete(id)).Returns(returnDto);
            var controller = new ContactsController(repository);
            // Act

            var actionResult = controller.Delete(id);
            var result = actionResult;
            // Assert
            Assert.NotEmpty(result.ToString());
        }
    }
}
