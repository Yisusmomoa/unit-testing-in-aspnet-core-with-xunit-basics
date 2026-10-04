namespace LibraryApi.Helpers;

public class StringHelper
{
    public bool IsEmpty(string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public int CountWords(string text)
    {
        //pueden suceder multiples escenarios:
            //un parafo, una palabra, un valor vacio, null, sólo un espacio
        if (string.IsNullOrWhiteSpace(text))
            return 0;

        var words = text.Split([' ', '\t', '\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        return words.Length;
    }
    //generar las PU de las siguinetes funciones

    public string Capitalize(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        return char.ToUpper(text[0]) + text.Substring(1).ToLower();
    }

    public bool Contains(string text, string? substring)
    {
        return substring != null && text.Contains(substring, StringComparison.OrdinalIgnoreCase);
    }
}