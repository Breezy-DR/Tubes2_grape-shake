using System;
using System.Collections.Generic;

namespace Maze {
    class Program {
        static void Main(string[] args) {
            // try {
                // string filename;
                // Console.Write("Masukkan nama file: ");
                // filename = Console.ReadLine();
                Utils ut = new Utils();
                string[][] jag = ut.ReadFile("sampel-2.txt");
                ut.printMatrix(jag);
                if (!ut.isLineHaveEqualElement(jag)) {
                    Console.WriteLine("All lines have to have the same number of elements");
                } else if (!ut.isSymbolValid(jag)) {
                    Console.WriteLine("File symbols can only be X, R, K, and T");
                } else if (ut.ElementCount(jag, "K") != 1
                            || ut.ElementCount(jag, "R") == 0
                            || ut.ElementCount(jag, "T") == 0
                            || ut.ElementCount(jag, "X") == 0) {
                    Console.WriteLine("File has to have exactly one symbol of K, and at least one symbol of R, T, and X.");
                } else {
                    Console.WriteLine("File is valid.");
                    Console.WriteLine(ut.ElementCount(jag, "T"));
                    int krustyKrabX = 0;
                    int krustyKrabY = 0;
                    for (int i=0; i < jag.Length; i++) {
                        for (int j=0; j < jag[i].Length; j++) {
                            if (jag[i][j] == "K") {
                                krustyKrabX = i;
                                krustyKrabY = j;
                                break;
                            }
                        }
                    }
                MatrixElement[][] mainMatrix = ut.InitMatrix(jag);
                bool[,] isVisited = ut.InitBoolMatrix(jag);
                BFS bfs = new BFS();
                DFS dfs = new DFS();
                Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> dfsList = dfs.findDFSTSP(mainMatrix, jag, krustyKrabX, krustyKrabY);
                Console.WriteLine("TSP DFS");
                Console.WriteLine("Jalur:");
                foreach (var tuple in dfsList.Item2)
                {
                    Console.WriteLine("({0}, {1})", tuple.Item1.ToString(), tuple.Item2.ToString());
                }
                Console.WriteLine("Proses:");
                foreach (var tuple in dfsList.Item1)
                {
                    Console.WriteLine("({0}, {1})", tuple.Item1.ToString(), tuple.Item2.ToString());
                }

                // contoh pake TSP BFS
                Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList = bfs.findBFSTSP(mainMatrix, jag, krustyKrabX, krustyKrabY);
                
                // Contoh TSP BFS
                Console.WriteLine("TSP BFS");
                Console.WriteLine("Jalur:");
                foreach (var tuple in bfsList.Item2)
                {
                    Console.WriteLine("({0}, {1})", tuple.Item1, tuple.Item2);
                }
                Console.WriteLine("Proses:");
                foreach (var tuple in bfsList.Item1)
                {
                    // Prosesnya cukup pake Item1 dan Item2
                    Console.WriteLine("({0}, {1})", tuple.Item1.ToString(), tuple.Item2.ToString());
                }

                // Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList = a.findBFS(mainMatrix, jag, krustyKrabX, krustyKrabY);
                // Console.WriteLine("BFS");
                // Console.WriteLine("Jalur:");
                // foreach (var tuple in bfsList.Item2)
                // {
                //     Console.WriteLine("({0}, {1})", tuple.Item1, tuple.Item2);
                // }
                // Console.WriteLine("Proses:");
                // foreach (var tuple in bfsList.Item1)
                // {
                //     // Prosesnya cukup pake Item1 dan Item2
                //     Console.WriteLine("({0}, {1})", tuple.Item1.ToString(), tuple.Item2.ToString());
                // }
            }
            // } catch (Exception e) {
            //     Console.WriteLine(e.Message);
            // }
        }
    }
}

