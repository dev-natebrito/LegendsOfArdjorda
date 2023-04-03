using LegendsOfArdjorda.Models;
using LegendsOfArdjorda.Models.DBsettings;
using LegendsOfArdjorda.Services.Interfaces;
using MongoDB.Driver;

namespace LegendsOfArdjorda.Services;

public class CharacterService : ICharacterService
{
    private readonly IMongoCollection<Character> _characterCollection;

    public CharacterService(ILoaDatabaseSettings settings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _characterCollection = database.GetCollection<Character>(settings.CharacterCollectionName);
    }
    
    public List<Character> Get()
    {
        return _characterCollection.Find(character => true).ToList();
    }

    public Character Get(string id)
    {
        return _characterCollection.Find(character => character.Id == id).FirstOrDefault();
    }

    public Character Create(Character character)
    {
        _characterCollection.InsertOne(character);
        return character;
    }

    public void Update(string id, Character character)
    {
        _characterCollection.ReplaceOne(character => character.Id == id, character);
    }

    public void Remove(string id)
    {
        _characterCollection.DeleteOne(character => character.Id == id);
    }
}