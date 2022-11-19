using Jahr.Architecture.Core.Tests.Models;
using Newtonsoft.Json;

namespace Jahr.Architecture.Core.Tests;

public class ObjectValidatorTest
{
    [Fact]
    public void Test_Validator_Success()
    {
        var exampleModel = new ExampleModel
        {
            SomeNumberField = 1,
            EmailField = "user@domain.com",
            SomeTextField = "This is a field with data"
        };

        Assert.True(exampleModel.IsValid);
    }

    [Fact]
    public void Test_Validator_Fail()
    {
        var exampleModel = new ExampleModel
        {
            SomeNumberField = 0,
            EmailField = "user",
            SomeTextField = ""
        };

        Assert.False(exampleModel.IsValid);
        Assert.NotEmpty(exampleModel.ValidationResultAsString());

        var validationResult = exampleModel.ValidationResultAsString();

        Assert.Contains("SomeNumberField", validationResult);
        Assert.Contains("EmailField", validationResult);
        Assert.Contains("SomeTextField", validationResult);
        Assert.Contains("El valor cumple con el rago permitido", validationResult);
        Assert.Contains("El campo es requerido", validationResult);
        Assert.Contains("El valor ingresado no tiene formato de email", validationResult);
    }

    [Fact]
    public void Test_Validator_Json()
    {
        var exampleModel = new ExampleModel
        {
            SomeNumberField = 1,
            EmailField = "user@domain.com",
            SomeTextField = "This is a field with data"
        };

        var jsonResult = JsonConvert.SerializeObject(exampleModel);

        Assert.DoesNotContain("IsValid", jsonResult);
    }
}