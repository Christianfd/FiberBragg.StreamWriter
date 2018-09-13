using StreamWriter.tools;

namespace StreamWriter.Interfaces
{
    public interface ISession
    {
        int frequency { get; set; }
        void Start(IPackHandler Packet, MessageHandler m, IErrorSimulator e);
        void UpdateFrequency(UserInput UInput);
        void Stop();
    }
}