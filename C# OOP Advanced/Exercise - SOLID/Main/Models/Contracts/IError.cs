namespace Main.Models.Contracts
{
    using System;
    using Main.Models.Enums;

    interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel ErrorLevel { get; }
    }
}