using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Part6
{
    // アイテム（ブロック）の座標を出力する
    public class OutFiles
    {
        public void OutOreCoordinate(List<string> Ores)
        {
            string path = $@".\Output\coordinate.txt";
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("utf-8"));
                foreach(string ore in Ores)
                {
                    sw.WriteLine(ore);
                }
                sw.Close();
                Console.WriteLine($"\nCoordinate File : {path}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
