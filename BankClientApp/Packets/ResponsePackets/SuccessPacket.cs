using WpfApp1.Packets;

namespace BankClientApp.Packets.ResponsePackets;

public class SuccessPacket() : BasePacket((int)EPacketIDs.OkPacket);