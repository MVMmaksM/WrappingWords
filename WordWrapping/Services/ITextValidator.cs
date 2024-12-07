namespace WordWrapping.Services
{
    public interface ITextValidator
    {
        bool isFillText(string text);
        bool isAllowedSymbols(string text);

    }
}
