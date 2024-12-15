using Domain.Pets;
using Domain.Primitives;
using Application.Pets.Create;


namespace Application.Pets.UnitTests.Create;

[TestClass]
public class CreatePetCommandHandlerTests
{
    private readonly Mock<IPetRepository> _mockPetRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CreatePetCommandHandler _handler;

    public CreatePetCommandHandlerTests(IPetRepository petRepository)
    {
        _mockPetRepository = new Mock<IPetRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreatePetCommandHandler(_mockUnitOfWork.Object, _mockPetRepository.Object);
    }

    [TestMethod]
    public async Task HandleCreatePetCommand_WhenYearHasBadFormat_ShouldReturnValidationError()
    {
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
        result.FirstError.Code.Should().Be("Pet.Birthdate");
    }
}
