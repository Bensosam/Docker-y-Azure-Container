using System.ComponentModel.DataAnnotations;

namespace GestionClientes.Blazor.Models;

public class Cliente
{
    public int Id_cliente { get; set; }

    [Required(ErrorMessage = "El CUI es obligatorio")]
    [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
    public string CUI { get; set; } = string.Empty;

    [Required(ErrorMessage = "El NIT es obligatorio")]
    [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
    public string NIT { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los nombres son obligatorios")]
    [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
    public string Apellidos { get; set; } = string.Empty;

    [Required(ErrorMessage = "La direccion es obligatoria")]
    [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
    public string Direccion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El telefono es obligatorio")]
    [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
    public string Telefono { get; set; } = string.Empty;

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public DateTime Fecha_Nacimiento { get; set; } = DateTime.Today;
}
