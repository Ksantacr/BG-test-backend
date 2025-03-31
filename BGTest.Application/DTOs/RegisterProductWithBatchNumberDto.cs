using System.ComponentModel.DataAnnotations;

namespace BGTest.Application.DTOs;

public class RegisterProductWithBatchNumberDto
{
    public int ProductId { get; set; }
    public int BatchNumber { get; set; }
    [Required]
    public double Price { get; set; }
}