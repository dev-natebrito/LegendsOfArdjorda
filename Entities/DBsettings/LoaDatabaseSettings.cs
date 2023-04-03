namespace LegendsOfArdjorda.Models.DBsettings;

public class LoaDatabaseSettings : ILoaDatabaseSettings
{
    public string CharacterCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}