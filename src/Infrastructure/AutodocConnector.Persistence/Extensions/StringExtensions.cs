using System.Text;

namespace AutodocConnector.Persistence.Extensions;

/// <summary>
/// String extansions inside Persistence layer
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Convert PascalCase input string to snake_case string
    /// </summary>
    /// <param name="text">PascalCase input string</param>
    /// <returns>snake_case string</returns>
    public static string ToSnakeCase(this string text)
    {
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (var i = 1; i < text.Length; ++i)
        {
            var c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Convert PascalCase input string to kebab-case string
    /// </summary>
    /// <param name="text">PascalCase input string</param>
    /// <returns>kebab-case string</returns>
    public static string ToKebabCase(this string text)
    {
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));
        for (var i = 1; i < text.Length; ++i)
        {
            var c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
