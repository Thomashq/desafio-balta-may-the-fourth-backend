using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MayTheFourth.Models;

public abstract class BaseModel
{
    [Key]
    public long Id { get; set; }
}
