namespace Main.Models.Contracts
{
    interface ILogger
    {
        void Log(IError error);
    }
}
