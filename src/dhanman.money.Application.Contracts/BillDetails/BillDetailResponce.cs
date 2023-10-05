namespace dhanman.money.Application.Contracts.BillDetails;

public class BillDetailResponce
{
    public BillDetailResponce
       (Guid id,
       string name,
       Guid billHeaderId,
       string description,
       decimal price,
       int quantity,
       decimal amount)
    {
        Id = id;
        BillHeaderId = billHeaderId;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
    }
    public Guid Id { get; }
    public Guid BillHeaderId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; private set; }
}
