using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreVIrgin.Data.EF.Entity;

[Table ("Class")]
public class ClassEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}