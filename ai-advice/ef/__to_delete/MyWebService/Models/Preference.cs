using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Preference
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }

    public ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();
}
