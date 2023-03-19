using System;

namespace Maze {
    class Utils
    {
        public void ReadFile(string filename) {
            StreamReader sr = new StreamReader("../test/" + filename);
            string data = sr.ReadToEnd();
            Console.WriteLine(data);
        }
    }
}