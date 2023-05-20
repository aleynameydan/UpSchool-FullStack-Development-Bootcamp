using Application.Common.Helpers;

namespace Application.UnitTests.Common.Helpers;

public class MathHelperTests
{
    [Fact]
    public void IsEven_Returns_True()
    {
        //Arrange --> yapacağımız işlemi ayarladığımız kısım

        var mathHelper = new MathHelper();

        int evenNumber = 6;

        //Act --> işlemi yaptığımız kısım

        var result = mathHelper.IsEven(evenNumber);

        //Assert --> işlemi test ettiğimiz kısım
        
        Assert.True(result); // verdiğim değer true mu diye kontrol et
    }
}