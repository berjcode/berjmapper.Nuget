# Feature


I'm writing a library to convert different types of objects to each other.

Errors are corrected as a result of feedback.

# berjmapper 

# Version
.net 7.0
# Install
```

  dotnet add package 
```
```
# Use  ListDto
var Product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "offers pride"
};


var berjMapper = new BerjMapper<Product, ProductDto>();
var convertedproductDto = berjMapper.Map(Product); //+
Console.WriteLine(convertedproductDto.Id);
Console.WriteLine(convertedproductDto.Name);
```
```
##  The Exact Opposite

var convertedProduct = berjMapper.Map(ProductDtoToProduct); // +


Console.WriteLine(convertedProduct.Id);
Console.WriteLine(convertedProduct.Name);

```
    
....

```
## ListDto
   
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
```

....
```
## CreateDto
   
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

var berjMapper3 = new BerjMapper<ProductCreateDto, Product>();
Product product = berjMapper3.Map(productCreateDto);

Console.WriteLine("Product ID: " + product.Id);
Console.WriteLine("Product Name: " + product.Name);
```
```


## Warning
   *  No package is needed. Not recommended for large projects. Recommended for education and small projects.
   *   It can give errors in complex objects.
  

   
                                                                                                                     
   ###    By Abdullah Balikci - berjcode

      
