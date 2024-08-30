using System.Text.Json;
using System.Text.Json.Serialization;

namespace WpfApp1.Packets;

public class BasePacket
{
    [JsonInclude]
    public int PacketId { get; protected set; } = (int)EPacketIDs.BasePacket;

    public BasePacket() { }

    public BasePacket(int packetId) => this.PacketId = packetId;
    
    public string SerializePacket<TInPacket>() where TInPacket : BasePacket
    {
        return JsonSerializer.Serialize<TInPacket>((TInPacket)this);
    }

    public static BasePacket DeserializePacket(string data)
    {
        // if null is returned, pretend it's a base packet that does nothing
        BasePacket packet = JsonSerializer.Deserialize<BasePacket>(data) ?? new BasePacket();
        
        if (packet.PacketId == (int)EPacketIDs.CreateClientProfilePacket)
            return JsonSerializer.Deserialize<CreateClientProfilePacket>(data) ?? new CreateClientProfilePacket();
        if (packet.PacketId == (int)EPacketIDs.CreateFinanceAccountPacket)
            return JsonSerializer.Deserialize<CreateFinanceProfilePacket>(data) ?? new CreateFinanceProfilePacket();
        
        return packet;
    }
}