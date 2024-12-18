namespace Application.Pets.UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        //Arrange
        string pet;
        //Act
        pet = "Fido";
        //Assert
        Assert.AreEqual("Fido", pet);
    }
}