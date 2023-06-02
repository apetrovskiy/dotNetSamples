public class Operation:BaseEntity
{
    public Guid CategoryId { get; set; }
    public Guid CashId { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public int Value { get; set; }
}

public class BaseEntity{
    public Guid Id{get;set;}
}