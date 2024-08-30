using System.Text.Json.Serialization;

namespace WpfApp1.Packets;

public class CreateFinanceProfilePacket : BasePacket
{
    [JsonInclude]
    public long     AccountOwnerID { get; private set; }
    [JsonInclude]
    public decimal  AccountBalance { get; private set; }
    [JsonInclude]
    public string   CurrencyName   { get; private set; }

    public CreateFinanceProfilePacket() : base((int)EPacketIDs.CreateFinanceAccountPacket)
    {
        this.AccountOwnerID = long.MinValue;
        this.AccountBalance = decimal.MinValue;
        this.CurrencyName   = "ERROR";
    }

    public CreateFinanceProfilePacket(long accountOwnerId, decimal accountBalance, string currencyName) : base((int)EPacketIDs.CreateFinanceAccountPacket)
    {
        AccountOwnerID = accountOwnerId;
        AccountBalance = accountBalance;
        CurrencyName = currencyName ?? throw new ArgumentNullException(nameof(currencyName));
    }
}