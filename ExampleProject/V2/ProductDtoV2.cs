namespace ExampleProject.V2;

internal class ProductDtoV2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto CategoryDto { get; set; }
}
