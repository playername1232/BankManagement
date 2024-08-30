using System.Text.Json;
using System.Text.Json.Serialization;
using BankClientApp.Model;

namespace WpfApp1.Packets;

public class CreateClientProfilePacket : BasePacket
{
    [JsonInclude]
    public long   AccountId { get; private set; }
    [JsonInclude]
    public string Username  { get; private set; }
    [JsonInclude]
    public string Password  { get; private set; }

    public CreateClientProfilePacket() : base((int)EPacketIDs.CreateClientProfilePacket)
    {
        this.AccountId = long.MinValue;
        this.Username  = "ERORR";
        this.Password  = "ERROR";
    }
    public CreateClientProfilePacket(string username, string password) : base((int)EPacketIDs.CreateClientProfilePacket)
    {
        this.Username = username;
        this.Password = password;
    }

    public CreateClientProfilePacket(ClientProfile profile)
    {
        this.AccountId = profile.ClientId;
        this.Username  = profile.Username;
        this.Password  = profile.Password;
    }
}