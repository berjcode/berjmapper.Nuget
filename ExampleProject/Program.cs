using berjmapper;
using ExampleProject;

Console.WriteLine("Hello, World!");

var Product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "offers pride"
};

var ProductListDtoToProduct = new ProductListDto { Id = 2, Name = "Abdullah" };


Console.WriteLine("----------- Converting Product to ProductListDto ------------");

var berjMapper = new BerjMapper<Product, ProductListDto>();
var convertedproductListDto = berjMapper.Map(Product);
Console.WriteLine(convertedproductListDto.Id);
Console.WriteLine(convertedproductListDto.Name);




Console.WriteLine("----------- Converting ProductListDto to Product ------------");


var convertedProduct = berjMapper.Map(ProductListDtoToProduct);


Console.WriteLine(convertedProduct.Id);
Console.WriteLine(convertedProduct.Name);

