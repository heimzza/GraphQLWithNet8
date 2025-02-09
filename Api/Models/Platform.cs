using System.ComponentModel.DataAnnotations;

namespace GraphQLWithNet8.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [GraphQLDescription("Purchased license key of the respective software.")]
    public string LicenseKey { get; set; }
    public ICollection<Command> Commands { get; set; } = [];
}
