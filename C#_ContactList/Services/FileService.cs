using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C__ContactList.Services;

public class FileService
{
    
    private static readonly string filePath = @"C:\skola\SaveToFile_ContactList#c\list.txt";
    public static void SaveToFile(string contactPerson)
    {
        using var writer = new StreamWriter(filePath);
        writer.WriteLine(contactPerson);
    }

    public static string ReadFromFile()
    {
        if (File.Exists(filePath))
        {
            using var reader = new StreamReader(filePath);
            return reader.ReadToEnd();
        }
        return null!;
    }
}
 