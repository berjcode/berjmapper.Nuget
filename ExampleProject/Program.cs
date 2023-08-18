using berjmapper.BerjMapper;
using ExampleProject;


var Product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "Proudly Presents"
};

var productDto = new ProductDto
{
    Id = 2,
    Name = "berjCodeV2",
    Description = "Proudly Presents"
};


Console.WriteLine("----------- Converting Product to ProductDto ------------");

var convertProductToProductDto = BerjMapper.Convert<Product, ProductDto>(Product);


Console.WriteLine(convertProductToProductDto.Id);
Console.WriteLine(convertProductToProductDto.Name);


Console.WriteLine("----------- Converting Reverse ||  ConvertproductDtoToProduct ------------");

var convertproductDtoToProduct = BerjMapper.Convert<ProductDto, Product>(productDto);


Console.WriteLine(convertproductDtoToProduct.Id);
Console.WriteLine(convertproductDtoToProduct.Name);




Console.WriteLine("----------- Converting ProductDto to Product ------------");

var testProductDto = new ProductDto
{
    Id = 1,
    Name = "berjCode",
};


var productTest = BerjMapper.Convert<ProductDto, Product>(testProductDto);

Console.WriteLine(productTest.Id);
Console.WriteLine(productTest.Name);

Console.WriteLine("----------- Converting Product To ProductListDto ------------");
var products = new List<Product>()
{
    new Product { Id = 1, Name = "Product-1 V1" },
    new Product { Id = 2, Name = "Product-2 V1" },
    new Product { Id = 3, Name = "Product-3 V1" },
};

var productListTest = BerjMapper.ConvertList<Product, ProductListDto>(products);

foreach (var productListDto in productListTest)
{
    Console.WriteLine(productListDto.Id);
    Console.WriteLine(productListDto.Name);
}

Console.WriteLine("----------- Converting ProductListDto  To Product------------");
var productListDtoObject = new List<ProductListDto>()
{
    new ProductListDto { Id = 1, Name = "Product-1 V2" },
    new ProductListDto { Id = 2, Name = "Product-2 V2" },
    new ProductListDto { Id = 3, Name = "Product-3 V2" },
};

var converProductListDtoToProduct = BerjMapper.ConvertList<ProductListDto, Product>(productListDtoObject);

foreach (var product in converProductListDtoToProduct)
{
    Console.WriteLine(product.Id);
    Console.WriteLine(product.Name);
}

Console.WriteLine("----------- Create Product  ------------");

Console.Write("product ID Giriniz: ");
int id = int.Parse(Console.ReadLine());

Console.Write(" product name Giriniz: ");
string name = Console.ReadLine();

ProductCreateDto productCreateDto = new ProductCreateDto
{
    Id = id,
    Name = name
};

var createProductTest = BerjMapper.Convert<ProductCreateDto, Product>(productCreateDto);

Console.WriteLine("Product ID: " + createProductTest.Id);
Console.WriteLine("Product Name: " + createProductTest.Name);