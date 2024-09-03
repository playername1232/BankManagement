using System.Text.Json.Serialization;
using BankClientApp.Model;

namespace WpfApp1.Packets;

public class CreateFinanceProfilePacket : BasePacket
{
    // Property used for database serialization and deserialization only, otherwise Bank account holds no reference to its owner
    [JsonInclude]
    public ulong    AccountOwnerId { get; private set; }
    [JsonInclude]
    public ulong    AccountId      { get; private set; }
    [JsonInclude]
    public decimal  AccountBalance { get; private set; }
    [JsonInclude]
    public string   CurrencyName   { get; private set; }

    public CreateFinanceProfilePacket() : base((int)EPacketIDs.CreateFinanceAccountPacket)
    {
        this.AccountOwnerId = ulong.MinValue;
        this.AccountBalance = decimal.MinValue;
        this.CurrencyName   = "ERROR";
    }

    public CreateFinanceProfilePacket(ulong accountOwnerId, ulong accountId, decimal accountBalance, string currencyName) : base((int)EPacketIDs.CreateFinanceAccountPacket)
    {
        AccountOwnerId = accountOwnerId;
        AccountId      = accountId;
        AccountBalance = accountBalance;
        CurrencyName   = currencyName ?? throw new ArgumentNullException(nameof(currencyName));
    }

    public static FinanceProfile ConvertToFinanceProfile(CreateFinanceProfilePacket packet) =>
        new FinanceProfile(packet.AccountId, packet.AccountBalance, packet.CurrencyName);
}