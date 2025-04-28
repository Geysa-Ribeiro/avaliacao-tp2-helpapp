using HelpApp.Domain.Validation;

namespace HelpApp.Domain.Entities;

public class Product
{
    private int v1;
    private string v2;
    private string v3;
    private decimal v4;
    private int v5;
    private string url;
    private string v6;

    public Product(int v) { }
    #region Atributos

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }


    #endregion

    #region Construtores

    public Product(string name, string description, decimal price, int stock, string image, int categoryId)
    {

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int id, string name, string description, decimal price, int stock, int value, string image, int categoryId)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id Value");
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
        ValidateDomain(name, description, price, stock, image);
    }

    public Product(int v1, string v2, string v3, decimal v4, int v5, string url, string v6)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.v5 = v5;
        this.url = url;
        this.v6 = v6;
    }

    #endregion

    #region Validação

    private void ValidateDomain(string name, string description, decimal price, int stock, string image)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");

        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters.");

        DomainExceptionValidation.When(stock < 0, "Invalid stock negative value");

        DomainExceptionValidation.When(price <= 0, "Invalid price value");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image address, image is required.");

        DomainExceptionValidation.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters.");

    }

    #endregion
}