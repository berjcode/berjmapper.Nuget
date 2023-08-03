using berjmapper.test.Classes;

namespace berjmapper.test
{
    public class UnitTest1
    {
        [Fact]
        public void Map_SingleObject_ConvertIsSuccessfuly()
        {
            var source = new SourceClass { Id = 1, Name = "Source Object" };

            // Act
            var destination = BerjMapper<SourceClass, DestinationClass>.Convert(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name,destination.Name);
        }
      
    }
}