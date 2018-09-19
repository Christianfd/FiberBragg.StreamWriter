using StreamWriter.tools;

namespace StreamWriter.Interfaces
{
    public interface ISession
    {
        int frequency { get; set; }
        void Start(IPackHandler Packet, MessageHandler m, IErrorSimulator e, UserInput UI);
        void UpdateFrequency(UserInput UInput);
        void Stop();
    }
}