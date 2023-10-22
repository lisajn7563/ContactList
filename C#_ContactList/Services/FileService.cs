

namespace C__ContactList.Services;


public class FileService  
{
    private static readonly string filePath = @"C:\skola\ContactList_uppgift\SaveToFile_ContactList#c\list.txt"; // en privat läsbar fil
   

    public static void SaveToFile(string contactPerson) 
    {
        using var writer = new StreamWriter(filePath);
        writer.WriteLine(contactPerson);
    } // sparar ner till fil

    public static string ReadFromFile() // hämtar från fil
    {
        if (File.Exists(filePath)) // om filen exist hämtar den filen
        {
            using var reader = new StreamReader(filePath);
            return reader.ReadToEnd();
        }
        return null!; // annars returns ingen fil pga den existerar inte
    }

}
 