namespace WpfApp1.Packets;

public enum EPacketIDs : int
{
    BasePacket                 = 0x0,
    
    // Response packets
    OkPacket                   = 0x100001,
    BadPacket                  = 0x100002,
    
    // Create packets
    CreateClientProfilePacket  = 0x200001,
    CreateFinanceAccountPacket = 0x200002
};