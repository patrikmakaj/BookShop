using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.Models;


public class Category
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 30)]
    public int DisplayOrder { get; set; }
}
