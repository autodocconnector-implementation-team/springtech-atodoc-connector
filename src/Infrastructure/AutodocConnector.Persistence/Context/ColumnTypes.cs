namespace AutodocConnector.Persistence.Context;

public static class ColumnTypes
{
    public const string UniqueIdentifier = "uuid";
    public const string Text = "text";
    public const string Boolean = "boolean";
    
    public const string Date = "date";
    public const string UTCTimestamp = "timestamp";
    public const string UTCTime = "time";

    public const string Integer = "integer";
    public const string BigInt = "bigint";

    public const string Real = "real";
    public const string Double = "double precision";
    public const string Decimal = "numeric";
    
    public const string Money = "money";

    public const string Serial = "serial";
    public const string BigSerial = "bigserial";

    public const string Json = "json";
    public const string JsonB = "jsonb";
}