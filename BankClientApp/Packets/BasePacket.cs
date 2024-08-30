using System.Text.Json;

namespace WpfApp1.Packets;

public class BasePacket
{
    protected virtual int PacketId => 0;

    public BasePacket() { }

    public virtual string SerializePacket(BasePacket packet)
    {
        return "IMPL_NOT_DONE";
    }

    public static BasePacket DeserializePacket(string data)
    {
        // if null is returned, pretend its a base packet that does nothing
        BasePacket packet = JsonSerializer.Deserialize<BasePacket>(data) ?? new BasePacket();
        
        if (packet.PacketId == 1)
            return (CreateNewAccountPacket)packet;
        
        return packet;
    }
}