using LegendsOfArdjorda.Models;

namespace LegendsOfArdjorda.Services.Interfaces;

public interface ICharacterService
{
    List<Character> Get();
    Character Get(string id);
    Character Create(Character character);
    void Update(string id, Character character);
    void Remove(string id);
}