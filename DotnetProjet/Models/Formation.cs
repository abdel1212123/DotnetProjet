// Models/Formation.cs
namespace DotnetProjet.Entities;

public class Formation
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? FormateurId { get; set; }
    public Formateur? Formateur { get; set; }
    public int? CategorieId { get; set; }
    public Categorie? Categorie { get; set; }
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
    public ICollection<Module> Modules { get; set; } = new List<Module>();
}