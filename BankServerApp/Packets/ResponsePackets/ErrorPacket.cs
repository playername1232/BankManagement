using System.Runtime.InteropServices.JavaScript;
using WpfApp1.Packets;

namespace BankClientApp.Packets.ResponsePackets;

public enum PacketErrorCodes : int
{
    DefaultError = 0x0
};

public class ErrorPacket : BasePacket
{
    public string Message              { get; private set; }
    public PacketErrorCodes ErrorCode  { get; private set; }

    public ErrorPacket() : base((int)EPacketIDs.BadPacket)
    {
        this.ErrorCode = PacketErrorCodes.DefaultError;
        this.Message   = "UNKNOWN_ERROR";
    }

    public ErrorPacket(string message, PacketErrorCodes errorCode) : base((int)EPacketIDs.BadPacket)
    {
        this.Message   = message;
        this.ErrorCode = errorCode;
    }
}