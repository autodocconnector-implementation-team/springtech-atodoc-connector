﻿namespace AutodocConnector.Application;

public class ApplicationException : Exception
{
    public ApplicationException(string? message):  base(message) { }

    public ApplicationException(string? message, Exception? innerException) : base(message, innerException) { }

}
