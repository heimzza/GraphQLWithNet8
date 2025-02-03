using System.ComponentModel.DataAnnotations;

namespace GraphQLWithNet8.Models;

public class Platform
{
    [Key]
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string LicenseKey { get; set; }
}
