using System.Text;

namespace ptt_api.Tests
{
    public class StringBuilderTests //nazwa to nazwa typu obiektu, który testujemy
    {
        [Fact]
        public void Append_ForTwoStrings_ReturnsConcatenatedString() //tutaj  NazwaMetody_Scenariuszktóryrealizujemy_OczekiwanyRezultat
        {
            //arrange
            StringBuilder sb = new StringBuilder();
            //act
            sb.Append("test")
                .Append("test1");
            var result = sb.ToString();
            //assert
            Assert.Equal("testtest1", result);//Pierwszy parametr to ten, który oczekujemy
            
        }
    }
}