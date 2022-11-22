using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using UserService.Controllers;
using UserService.DTOs.User;
using UserService.Repositories.User;
using UserService.Requests.User;
using UserService.Responses.BaseResponse;

namespace UserServiceTest
{
    public class UserControllerTests
    {
        [Fact]
        public void GetAll()
        {
            var repository = A.Fake<IUserRepository>();
            var request = new UserGetAllRequest();
            request.PageSize = 20;
            var fakeUsers = A.CollectionOfDummy<UserReadDto>(1);
            A.CallTo(() => repository.GetAllUsers(request)).Returns(fakeUsers);
            var controller = new UsersController(repository);
            // Act

            var actionResult = controller.GetAll(request);
            // Assert

            var result = actionResult.TotalRecords;
            Assert.NotNull(result);
        }

        [Fact]
        public void GetById()
        {
            var repository = A.Fake<IUserRepository>();
            var request = new UserGetByIdRequest();
            var fakeUser = A.Dummy<UserReadDto>();
            Guid id = new Guid("1ea6e753-971d-4413-a611-60cb99278222");
            A.CallTo(() => repository.GetById(id,request)).Returns(fakeUser);
            var controller = new UsersController(repository);
            // Act

            var actionResult = controller.Get(id,request);
            // Assert
            var result = actionResult.Id;
            Assert.NotNull(result);
        }

        [Fact]
        public void Post()
        {
            var repository = A.Fake<IUserRepository>();
            var request = new UserPostRequest();
            var fakeUser = A.Dummy<UserReadDto>();
            A.CallTo(() => repository.Create(request)).Returns(fakeUser);
            var controller = new UsersController(repository);
            // Act

            var actionResult = controller.Post(request);
            // Assert
            var result = actionResult.Id;
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete()
        {
            var repository = A.Fake<IUserRepository>();
            var returnDto = A.Dummy<Boolean>();
            Guid id = new Guid("1ea6e753-971d-4413-a611-60cb99278222");
            A.CallTo(() => repository.Delete(id)).Returns(returnDto);
            var controller = new UsersController(repository);
            // Act

            var actionResult = controller.Delete(id);
            var result = actionResult;
            // Assert
            Assert.NotEmpty(result.ToString());
        }
    }
}