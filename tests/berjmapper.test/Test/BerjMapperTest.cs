using berjmapper.ObjectMapping;
using berjmapper.test.Classes;
using Xunit;

namespace berjmapper.test.Test
{
    public class BerjMapperTest
    {
        [Fact]
        public void Map_SingleObject_ConvertIsSuccessfuly()
        {
            var source = new SourceClass { Id = 1, Name = "Source Object" };

            var destination = BerjMapper.BerjMapper.Convert<SourceClass, DestinationClass>(source);

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

            var destinationList = BerjMapper.BerjMapper.ConvertList<SourceClass, DestinationClass>(sourceList);

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
            var destination = BerjMapper.BerjMapper.Convert<SourceClass, DestinationClass>(source);

            Assert.Null(destination);
        }

        [Fact]
        public void ConvertList_NullSource_ReturnsNull()
        {
            List<SourceClass> sourceList = null;

            var destinationList = BerjMapper.BerjMapper.ConvertList<SourceClass, DestinationClass>(sourceList);

            Assert.Null(destinationList);
        }

        [Fact]
        public void Map_SingleObject_ConvertIsSuccessfuly2()
        {
            // Arrange
            var source = new SourceClass { Id = 1, Name = "Source Object", Surname = "Test Surname" };

            // Act
            var destination = BerjMapper.BerjMapper.Convert<SourceClass, DestinationClass>(source);

            // Assert
            Assert.Equal(source.Id, destination.Id);
            Assert.Equal(source.Name, destination.Name);
        }
    }
}