using System.ComponentModel.DataAnnotations;

public class Role
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }
}
