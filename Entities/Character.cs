using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LegendsOfArdjorda.Models;

public class Character
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")] public string Name { get; set; }
    
    [BsonElement("race")] public string Race { get; set; }
    
    [BsonElement("background")] public string Background { get; set; }

    [BsonElement("level")] public int Level { get; set; }
    
    [BsonElement("hitpoints")] public Hitpoints Hitpoints { get; set; }

    [BsonElement("armorClass")] public int ArmorClass { get; set; }

    [BsonElement("strength")] public int Strength { get; set; }
    
    [BsonElement("dexterity")] public int Dexterity { get; set; }
    
    [BsonElement("constitution")] public int Constitution { get; set; }
    
    [BsonElement("intelligence")] public int Intelligence { get; set; }
    
    [BsonElement("wisdom")] public int Wisdom { get; set; }
    
    [BsonElement("charisma")] public int Charisma { get; set; }
    
}

public class Hitpoints
{
    [BsonElement("maxHp")] public int MaxHp { get; set; }
    [BsonElement("currentHp")] public int CurrentHp{ get; set; }
    [BsonElement("temporaryHitpoints")] public int? TemporaryHitpoints { get; set; }
}