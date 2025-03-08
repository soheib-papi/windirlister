using System;
using System.Collections.Generic;
using System.IO;

Console.Write("Enter folder path: ");
string rootPath = Console.ReadLine();

if (!Directory.Exists(rootPath))
{
    Console.WriteLine("Error: Folder does not exist.");
    return;
}

List<string> allPaths = new List<string>();

try
{
    // دریافت همه پوشه‌ها و فایل‌ها به‌صورت بازگشتی
    foreach (string dir in Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories))
    {
        allPaths.Add(dir);
    }

    foreach (string file in Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories))
    {
        allPaths.Add(file);
    }

    // نمایش لیست مسیرها
    Console.WriteLine("\nAll Files & Directories:");
    foreach (string path in allPaths)
    {
        Console.WriteLine(path);
    }

    // ذخیره در فایل خروجی
    string outputFile = Path.Combine(rootPath, "FileList.txt");
    File.WriteAllLines(outputFile, allPaths);
    Console.WriteLine($"\nList saved to: {outputFile}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}