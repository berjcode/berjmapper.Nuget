﻿using berjmapper.Helpers;
using berjmapper.Main;
using ExampleProject;


var Product = new Product
{
    Id = 1,
    Name = "berjCode",
    Description = "offers pride"
};


Console.WriteLine("----------- Converting Product to ProductDto ------------");

var productDto = BerjMapper.Convert<Product, ProductDto>(Product);


Console.WriteLine(productDto.Id);
Console.WriteLine(productDto.Name);



Console.WriteLine("----------- Converting ProductDto to Product ------------");

var testProductDto = new ProductDto
{
    Id = 1,
    Name = "berjCode",
};


var productTest = BerjMapper.Convert<ProductDto, Product>(testProductDto);

Console.WriteLine(productTest.Id);
Console.WriteLine(productTest.Name);

Console.WriteLine("----------- ProductListDto ------------");
var products = new List<Product>()
{
    new Product { Id = 1, Name = "Product 1" },
    new Product { Id = 2, Name = "Product 2" },
    new Product { Id = 3, Name = "Product 3" },
};

var productListTest = BerjMapper.ConvertList<Product, ProductListDto>(products);

foreach (var productListDto in productListTest)
{
    Console.WriteLine(productListDto.Id);
    Console.WriteLine(productListDto.Name);
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