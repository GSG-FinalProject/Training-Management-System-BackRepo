using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.Api.Controllers;
using TMS.Api.Responses;
using TMS.Application.Abstracts;
using TMS.Domain.DTOs.Submission;

namespace TMSApi.Test.ControllersTest;
public class SubmissionControllerTests
{
    private readonly Mock<ISubmissionService> _submissionServiceMock;
    private readonly Mock<IResponseHandler> _responseHandlerMock;
    private readonly SubmissionController _submissionController;

    public SubmissionControllerTests()
    {
        _submissionServiceMock = new Mock<ISubmissionService>();
        _responseHandlerMock = new Mock<IResponseHandler>();
        _submissionController = new SubmissionController(_submissionServiceMock.Object, _responseHandlerMock.Object);
    }

   
    [Fact]
    public async Task UpdateSubmission_ShouldReturnNoContent_WhenSubmissionIsUpdated()
    {
        // Arrange
        var submissionDto = new UpdateSubmissionRequestDto();
        _submissionServiceMock.Setup(s => s.UpdateAsync(submissionDto)).Returns(Task.CompletedTask);
        _responseHandlerMock.Setup(rh => rh.NoContent("Submission updated successfully.")).Returns(new NoContentResult());

        // Act
        var result = await _submissionController.UpdateSubmission(submissionDto);

        // Assert
        var actionResult = Assert.IsType<NoContentResult>(result);
        _submissionServiceMock.Verify(s => s.UpdateAsync(submissionDto), Times.Once);
    }

    [Fact]
    public async Task DeleteSubmission_ShouldReturnNoContent_WhenSubmissionIsDeleted()
    {
        // Arrange
        int submissionId = 1;
        _submissionServiceMock.Setup(s => s.DeleteAsync(submissionId)).Returns(Task.CompletedTask);
        _responseHandlerMock.Setup(rh => rh.NoContent("Submission deleted successfully.")).Returns(new NoContentResult());

        // Act
        var result = await _submissionController.DeleteSubmission(submissionId);

        // Assert
        var actionResult = Assert.IsType<NoContentResult>(result);
        _submissionServiceMock.Verify(s => s.DeleteAsync(submissionId), Times.Once);
    }
}