namespace LegendsOfArdjorda.Models.DBsettings;

public interface ILoaDatabaseSettings
{
    string CharacterCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}