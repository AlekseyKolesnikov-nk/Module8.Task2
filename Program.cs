using System;
using System.IO;
using System.Runtime.InteropServices;

class Programm
{
    public static void Main(string[] args)
    {
        DirectoryInfo dirInfo = new DirectoryInfo(@"/Users/Kolesnikov_aa/desktop/8Module");
        long size = LengthFiles(dirInfo);
        
        if (dirInfo.Exists)                                                 // Проверка пути
            LengthFiles(dirInfo);

        Console.WriteLine("\n\tОбщий объем директория " + dirInfo + " : " + size + "байт");
    }

    public static long LengthFiles(DirectoryInfo dirInfo)
    {
        long size = 0;

            FileInfo[] fff = dirInfo.GetFiles();
            foreach (FileInfo ff in fff)                                    // Перебираем файлы в директории
            {
                size += ff.Length;                                          // Считаем объем, суммируем
            }

            DirectoryInfo[] ddd = dirInfo.GetDirectories();
            foreach (DirectoryInfo dd in ddd)                               // Перебираем директории
            {
                try
                {
                size += LengthFiles(dd);                                    // Считаем объем, суммируем
                dirInfo = dd;

                }
                catch (Exception e)                                         // Проверка исключений
                {
                    Console.WriteLine(e.Message);
                }
            }
            return size;
    }
}