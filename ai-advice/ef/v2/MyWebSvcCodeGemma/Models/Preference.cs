using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Preference
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
}
