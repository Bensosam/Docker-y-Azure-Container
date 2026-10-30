using System.ComponentModel.DataAnnotations;

namespace GestionClientes.API.Models;

public class Cliente
{
    [Key]
    public int Id_cliente { get; set; }

    [Required, StringLength(20)]
    public string CUI { get; set; } = string.Empty;

    [Required, StringLength(20)]
    public string NIT { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Required, StringLength(200)]
    public string Direccion { get; set; } = string.Empty;

    [Required, StringLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [Required]
    public DateTime Fecha_Nacimiento { get; set; }
}
