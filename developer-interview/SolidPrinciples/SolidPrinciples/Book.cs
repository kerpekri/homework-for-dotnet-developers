namespace SolidPrinciples;

public class Book {

    private String name;
    private String author;
    private String text;

    public String replaceWordInText(string word, String replacementWord){
        return text.Replace(word, replacementWord);
    }

    public bool isWordInText(string word){
        return text.Contains(word);
    }

    public void PrintTextToConsole()
    {
        Console.Write(text);
    }
}