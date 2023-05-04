using berjmapper;
using ExampleProject;


Console.WriteLine("Hello, World!");

var Product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "offers pride"
};



var ProductDtoToProduct = new ProductDto { Id = 2, Name = "Abdullah" };


Console.WriteLine("----------- Converting Product to ProductListDto ------------");

var berjMapper = new BerjMapper<Product, ProductDto>();
var convertedproductDto = berjMapper.Map(Product);
Console.WriteLine(convertedproductDto.Id);
Console.WriteLine(convertedproductDto.Name);




Console.WriteLine("----------- Converting ProductDto to Product ------------");


var convertedProduct = berjMapper.Map(ProductDtoToProduct);


Console.WriteLine(convertedProduct.Id);
Console.WriteLine(convertedProduct.Name);


Console.WriteLine("----------- Test ------------");

//var stopwatch = new Stopwatch();
//stopwatch.Start();
//for (int i = 0; i < 100000; i++)
//{
//    var source = new ProductDto();
//    var destination = new berjMapper(Product,ProductDto>);
//}
////stopwatch.Stop();
//Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");

Console.WriteLine("----------- ProductListDto ------------");

var products = new List<Product>()
{
    new Product { Id = 1, Name = "Product 1" },
    new Product { Id = 2, Name = "Product 2"},
    new Product { Id = 3, Name = "Product 3" },
};

var berjMapper2 = new BerjMapper<Product, ProductListDto>();
//products => converting to ProductListDto.
var convertedProductListDto = berjMapper2.Map(products);

foreach(var productListDto in convertedProductListDto)
{
    Console.WriteLine(productListDto.Id);
    Console.WriteLine(productListDto.Name);
}
 