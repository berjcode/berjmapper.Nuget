# Feature


The BerjMapper class provides a user-friendly interface to manage conversions between two different data types and helps to avoid duplicate work in the code.

Errors are corrected as a result of feedback.

# berjmapper 

# Version
.net 7.0
# Install
```

  dotnet add package 
```

# Information
```
var product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "offers pride"
};

var productDto = BerjMapper<Product, ProductDto>.Convert(product);
first parameter should be source, second should be destination. In Convert, it must be the converted type.
here product is converted to productdto.
  
```


```
# Use  Converting Product to ProductDto
var Product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "offers pride"
};


Console.WriteLine("----------- Converting Product to ProductDto ------------");

var productDto = BerjMapper<Product, ProductDto>.Convert(Product);


Console.WriteLine(productDto.Id);
Console.WriteLine(productDto.Name);


```
```
# Use  Converting ProductDto to Product

var testProductDto = new ProductDto
{
    Id = 1,
    Name = "berjCode",
};


var productTest = BerjMapper.Convert<ProductDto, Product>(testProductDto);

Console.WriteLine(productTest.Id);
Console.WriteLine(productTest.Name);

```
    
```
## Converting Product  To ProductListDto
   
Console.WriteLine("----------- ProductListDto ------------");
var products = new List<Product>()
{
    new Product { Id = 1, Name = "Product 1" },
    new Product { Id = 2, Name = "Product 2" },
    new Product { Id = 3, Name = "Product 3" },
};

var productListTest = BerjMapper<Product, ProductListDto>.ConvertList(products);

foreach (var productListDto in productListTest)
{
    Console.WriteLine(productListDto.Id);
    Console.WriteLine(productListDto.Name);
}
Console.WriteLine(productListDto.Name);

```

```
## Converting ProductListDto  To Product
   
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

```

....
```
##  Converting CreateProductDto To Product
   
Console.WriteLine("----------- CreateProductDto To Product  ------------");

var createProductDtoTest = BerjMapper<ProductCreateDto, Product>.Convert(productCreateDto);

Console.WriteLine("Product ID: " + createProductTest.Id);
Console.WriteLine("Product Name: " + createProductTest.Name);
```
```


## Warning
   *  No package is needed. Not recommended for large projects. Recommended for education and small projects.
   *   It can give errors in complex objects.
  

   
                                                                                                                     
   ###    By Abdullah Balikci - berjcode

      
