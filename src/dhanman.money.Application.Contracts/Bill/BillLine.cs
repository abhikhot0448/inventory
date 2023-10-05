namespace dhanman.money.Application.Contracts.Bill;

public class BillLine
{
    #region Constructors

    public BillLine(string name, string description, decimal price, int quantity, decimal amount)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
    }
    #endregion

    #region Properties
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    #endregion

}

