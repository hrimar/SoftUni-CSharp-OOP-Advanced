namespace P06.TwitterProject
{
    public interface IClient
    {
        void SendToServer(string msg);
        void WriteToConsole(string msg);
    }
}