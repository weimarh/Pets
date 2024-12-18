using Domain.Pets;
using Domain.Primitives;
using Application.Pets.Create;
using Domain.DomainErrors;

namespace Application.Pets.UnitTests.Create;

[TestClass]
public class createTest
{

    [TestMethod]
    public async Task HandleCreatePetCommand_WhenYearHasBadFormat_ShouldReturnValidationError()
    {
        var mockRepositor = new Mock<IPetRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var _handler = new CreatePetCommandHandler(mockUnitOfWork.Object, mockRepositor.Object);
        //Arrage
        CreatePetCommand command = new CreatePetCommand(
            "Satuca",
            1,
            "Criollo",
            "Negro con naranja",
            0,
            0,
            "20",
            "2024");
        //Act
        var result = await _handler.Handle(command, default);
        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorOr.ErrorType.Validation);
        result.FirstError.Code.Should().Be(PetErrors.Pet.YearWithBadFormat.Code);
        result.FirstError.Description.Should().Be(PetErrors.Pet.YearWithBadFormat.Description);
    }
}
