// Models/Contenu.cs
namespace DotnetProjet.Entities;

public class Contenu
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public string Texte { get; set; } = null!;
    public string Type { get; set; } = "Cours";
    public int ModuleId { get; set; }
    public Module? Module { get; set; }
}