using System.ComponentModel.DataAnnotations.Schema;

namespace BGTest.Core.Entities;

[Table("product_batches")]
public class ProductBatches
{
    [Column("id")]
    public int Id { get; set; }
    [Column("product_id")]
    public int ProductId { get; set; }
    [Column("batch_number")]
    public int BatchNumber { get; set; }
    [Column("price")]
    public double Price { get; set; }
    [Column("registration_date")]
    public DateTime RegistrationDate { get; set; }
}