using System.ComponentModel.DataAnnotations.Schema;

namespace BGTest.Core.Views;

public class ProductBatchView
{
    [Column("product_id")]
    public int ProductId { get; set; }
    [Column("product_name")]
    public required string ProductName { get; set; }
    [Column("product_description")]
    public string? ProductDescription { get; set; }
    [Column("batch_number")]
    public required string BatchNumber { get; set; }
    [Column("price")]
    public double Price { get; set; }
    [Column("registered")]
    public DateTime Registered { get; set; }
}