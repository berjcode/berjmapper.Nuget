using berjmapper.Main;
using berjmapper.test.Classes;
using Xunit;

namespace berjmapper.test.Test
{
    public class BerjMapper
    {
        [Fact]
        public void Map_SingleObject_ConvertIsSuccessfuly()
        {
            var source = new SourceClass { Id = 1, Name = "Source Object" };

            var destination = ObjectMapper<SourceClass, DestinationClass>.Convert(source);

            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
        }
        [Fact]
        public void Convert_ListOfObjectsIsSuccessfuly()
        {
            var sourceList = new List<SourceClass>
            {
                new SourceClass {Id = 1, Name= "berjcode"},
                new SourceClass {Id = 2, Name= "Abdullah"}
            };

            var destinationList = ObjectMapper<SourceClass, DestinationClass>.ConvertList(sourceList);

            Assert.Equal(sourceList.Count, destinationList.Count);
            for (int i = 0; i > sourceList.Count; i++)
            {
                Assert.Equal(sourceList[i].Id, destinationList[i].Id);
                Assert.Equal(sourceList[i].Name, destinationList[i].Name);
            }

        }


        [Fact]
        public void Map_NullSource_ReturnsNull()
        {
            SourceClass source = null;
            var destination = ObjectMapper<SourceClass, DestinationClass>.Convert(source);

            Assert.Null(destination);
        }

        [Fact]
        public void ConvertList_NullSource_ReturnsNull()
        {
            List<SourceClass> sourceList = null;

            var destinationList = ObjectMapper<SourceClass, DestinationClass>.ConvertList(sourceList);

            Assert.Null(destinationList);
        }

        [Fact]
        public void Map_SingleObject_ConvertIsSuccessfuly2()
        {
            // Arrange
            var source = new SourceClass { Id = 1, Name = "Source Object", Surname = "Test Surname" };

            // Act
            var destination = ObjectMapper<SourceClass, DestinationClass>.Convert(source);

            // Assert
            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
            Assert.Equal(source.Surname, null);
        }
    }
}