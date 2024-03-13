using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using IPSA.API.Controllers;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.Tests.API.Controller
{
    public class AbonPageCommentsControllerTests
    {
        private AbonPageCommentsController _abonPageCommentsController;
        private IAbonPageCommentsRepository _abonPageCommentsRepository;
        private IMapper? _mapper;

        public AbonPageCommentsControllerTests()
        {
            // Dependencies
            _abonPageCommentsRepository = A.Fake<IAbonPageCommentsRepository>();

            // SUT - System Under Test
            _abonPageCommentsController = new AbonPageCommentsController(
                _abonPageCommentsRepository,
                _mapper!);
        }

        [Fact]
        public void AbonPageCommentsController_GetAbonentPageComments_ReturnOK()
        {
            // Arrange
            int abonentId = 1;

            // Act
            var result = _abonPageCommentsController.GetAbonentPageComments(abonentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult<List<AbonPageCommentDto>>>));
        }

        [Fact]
        public void AbonPageCommentsController_AddNewAbonPageComment_ReturnOK()
        {
            // Arrange
            AbonPageCommentDto abonPageCommentDto = A.Fake<AbonPageCommentDto>();

            // Act
            var result = _abonPageCommentsController.AddNewAbonPageComment(abonPageCommentDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void AbonPageCommentsController_UpdateAbonPageComment_ReturnOK()
        {
            // Arrange
            AbonPageCommentDto abonPageCommentDto = A.Fake<AbonPageCommentDto>();

            // Act
            var result = _abonPageCommentsController.UpdateAbonPageComment(abonPageCommentDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }

        [Fact]
        public void AbonPageCommentsController_DeleteAbonPageComment_ReturnOK()
        {
            // Arrange
            int commentId = 1;

            // Act
            var result = _abonPageCommentsController.DeleteAbonPageComment(commentId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(Task<ActionResult>));
        }
    }
}
