using System;

namespace Maze {
    class Utils
    {
        public string[][] ReadFile(string filename) {
            string [][] list =
            File.ReadAllLines("../test/" + filename)
            .Select(l => l.Split(' ').ToArray()).ToArray();
            return list;
        }
    }
}