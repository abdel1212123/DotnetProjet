// Models/Module.cs
namespace DotnetProjet.Entities;

public class Module
{
    public int Id { get; set; }
    public string Titre { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Ordre { get; set; }
    public int FormationId { get; set; }
    public Formation? Formation { get; set; }
    public ICollection<Contenu> Contenus { get; set; } = new List<Contenu>();
}