// Services/IServices.cs
using DotnetProjet.Entities;

namespace DotnetProjet.Services;

public interface IServices
{
    void Inscrire(int userId, int sessionId);
    List<Session> GetSessionsByUser(int userId);

    List<Formateur> GetAllFormateurs();
    Formateur? GetFormateurById(int id);
    void AddFormateur(Formateur formateur);
    void UpdateFormateur(int id, Formateur formateur);
    void DeleteFormateur(int id);

    List<Formation> GetAllFormations();
    Formation? GetFormationById(int id);
    void AddFormation(Formation formation);
    void UpdateFormation(int id, Formation formation);
    void DeleteFormation(int id);

    List<Session> GetAllSessions();
    Session? GetSessionById(int id);
    void AddSession(Session session);
    void UpdateSession(int id, Session session);
    void DeleteSession(int id);

    List<User> GetAllUsers();
    User? GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(int id, User user);
    void DeleteUser(int id);
    User? Authentifier(string login, string password);

    List<Module> GetAllModules();
    Module? GetModuleById(int id);
    void AddModule(Module module);
    void UpdateModule(int id, Module module);
    void DeleteModule(int id);

    List<Contenu> GetAllContenus();
    Contenu? GetContenuById(int id);
    void AddContenu(Contenu contenu);
    void UpdateContenu(int id, Contenu contenu);
    void DeleteContenu(int id);
}