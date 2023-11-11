using System.Text;

namespace ptt_api.Tests
{
    public class StringBuilderTests //nazwa to nazwa typu obiektu, kt�ry testujemy
    {
        [Fact]
        public void Append_ForTwoStrings_ReturnsConcatenatedString() //tutaj  NazwaMetody_Scenariuszkt�ryrealizujemy_OczekiwanyRezultat
        {
            //arrange
            StringBuilder sb = new StringBuilder();
            //act
            sb.Append("test")
                .Append("test1");
            var result = sb.ToString();
            //assert
            Assert.Equal("testtest1", result);//Pierwszy parametr to ten, kt�ry oczekujemy
            
        }
    }
}