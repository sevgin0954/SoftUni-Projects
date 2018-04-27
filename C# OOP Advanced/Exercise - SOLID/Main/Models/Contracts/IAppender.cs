namespace Main.Models.Enums
{
    using Main.Models.Contracts;

    interface IAppender
    {
        ILayout Layout { get; }

        void Append(IError error);
    }
}
