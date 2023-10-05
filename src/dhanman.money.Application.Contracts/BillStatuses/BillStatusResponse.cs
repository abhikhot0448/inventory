namespace dhanman.money.Application.Contracts.BillStatuses;

public class BillStatusResponse
{

    #region Constructor
    public BillStatusResponse(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    #endregion

    #region Properties

    public Guid Id { get; }
    public string Name { get; set; }

    #endregion

}
