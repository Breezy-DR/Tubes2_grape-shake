using System;
using System.Collections;

namespace Maze {
    class DFS {
        // Left, right, up, down
        static int[] horizontal = {0, 0, -1, 1}; 
        static int[] vertical = {-1, 1, 0, 0};
        Utils ut = new Utils();
        public bool isPathValid(MatrixElement[][] mainMatrix, bool[,] isVisited, int x, int y) {
            if (x < 0 || y < 0 || x >= mainMatrix.Length || y >= mainMatrix[0].Length) {
                return false;
            }
            if (isVisited[x, y]) {
                return false;
            }
            return true;
        }
        
        public List<Tuple<int, int>> findDFS(MatrixElement[][] mainMatrix, bool[,] isVisited, string[][] jag, int x, int y) {
            List<Tuple<int, int>> dfslist = new List<Tuple<int, int>>();
            Stack<Tuple<int, int>> s = new Stack<Tuple<int, int>>();
            int countTreasure = 0;
            Tuple<int, int> init = new Tuple<int, int>(x, y);
            s.Push(init);
            while (true) {
                Tuple<int, int> temp = s.Peek();
                s.Pop();
                x = temp.Item1;
                y = temp.Item2;
                if (!isPathValid(mainMatrix, isVisited, x, y)) {
                    if (s.Count == 0) {
                        break;
                    } else {
                        continue;
                    }
                }
                if (jag[x][y] == "T" && !isVisited[x, y]) {
                    countTreasure += 1;
                }
                isVisited[x, y] = true;
                mainMatrix[x][y].numberOfVisits += 1;
                dfslist.Add(temp);
                for (int i=0; i < 4; i++) {
                    if (i == 0 && !(ut.canMoveLeft(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 1 && !(ut.canMoveRight(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 2 && !(ut.canMoveUp(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 3 && !(ut.canMoveDown(mainMatrix, x, y))) {
                        continue;
                    }
                    s.Push(new Tuple<int, int>(x + horizontal[i], y + vertical[i]));
                }
                if (countTreasure == ut.ElementCount(jag, "T")) {
                    break;
                }
                else {
                    if (ut.stuck(mainMatrix, isVisited, x, y) || ut.surroundedByVisited(mainMatrix, isVisited, x, y)) {
                        // foreach (var a in dfslist) {
                        //     Console.WriteLine(a);
                        // }
                        List<Tuple<int, int>> reverse = Enumerable.Reverse(dfslist).ToList();
                        // foreach (var b in reverse) {
                        //     Console.WriteLine(b);
                        // }
                        int i = 0;
                        do {
                            dfslist.Add(reverse[i+1]);
                            mainMatrix[x][y].numberOfVisits += 1;
                            i++;
                        } while (!ut.isAdjacentToUnvisited(mainMatrix, isVisited, reverse[i].Item1, reverse[i].Item2));
                    }
                }
            }
            ut.ResetMatrix(mainMatrix, isVisited);
            return dfslist;
        }
    }
}