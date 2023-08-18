using berjmapper.ObjectMapping;
using berjmapper.test.Classes;
using System.Xml.Linq;
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

        [Fact]
        public void ConvertReverse_Should_ConvertDestinationToSource()
        {
            //Arrange
            var destiantion = new DestinationClass { Id = 1, Name = "berjcode" };

            //Act

            var source = BerjMapper.BerjMapper.ConvertReverse<DestinationClass, SourceClass>(destiantion);

            //Assert
            Assert.NotNull(source);
            Assert.Equal(destiantion.Id, source.Id);
            Assert.Equal(destiantion.Name, source.Name);

        }

        [Fact]
        public void ConvertListReverse_Should_DestinationListToSourceList()
        {
            //Arrange
            var destinationList = new List<DestinationClass> {
           new  DestinationClass{ Id = 1, Name = "berjcode" },
            new DestinationClass { Id = 2, Name = "berjcodev2" },
        };

            //Act
            var sourceList = BerjMapper.BerjMapper.ConvertListReverse<DestinationClass, SourceClass>(destinationList);

            //Assert
            Assert.NotNull(sourceList);
            Assert.Equal(destinationList.Count, sourceList.Count);
            for (int i = 0; i < destinationList.Count; i++)
            {
                Assert.Equal(destinationList[i].Id, sourceList[i].Id);
                Assert.Equal(destinationList[i].Name, sourceList[i].Name);
            }
        }
    }
}