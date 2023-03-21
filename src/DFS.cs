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
        public bool canMoveRight(MatrixElement[][] mainMatrix, int x, int y) {
            // return (!(mainMatrix[x][y+1].symbol == "X" || y == mainMatrix[0].Length - 1));
            if (y == mainMatrix[0].Length - 1) {
                return false;
            } else if (mainMatrix[x][y+1].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }
        public bool canMoveLeft(MatrixElement[][] mainMatrix, int x, int y) {
            // return (!(mainMatrix[x][y-1].symbol == "X" || y == 0));
            if (y == 0) {
                return false;
            } else if (mainMatrix[x][y-1].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }
        public bool canMoveUp(MatrixElement[][] mainMatrix, int x, int y) {
            // return (!(mainMatrix[x-1][y].symbol == "X" || x == 0));
            if (x == 0) {
                return false;
            } else if (mainMatrix[x-1][y].symbol == "X") {
                return false;
            } else {
                return true;
            }
        }
        public bool canMoveDown(MatrixElement[][] mainMatrix, int x, int y) {
            // return (!(mainMatrix[x+1][y].symbol == "X" || x == mainMatrix.Length - 1));
            if (x == mainMatrix.Length - 1) {
                return false;
            } else if (mainMatrix[x+1][y].symbol == "X") {
                return false;
            } else {
                return true;
            }
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
                isVisited[x, y] = true;
                if (jag[x][y] == "T") {
                    countTreasure += 1;
                }
                dfslist.Add(temp);
                for (int i=0; i < 4; i++) {
                    if (i == 0 && !(canMoveLeft(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 1 && !(canMoveRight(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 2 && !(canMoveUp(mainMatrix, x, y))) {
                        continue;
                    }
                    if (i == 3 && !(canMoveDown(mainMatrix, x, y))) {
                        continue;
                    }
                    s.Push(new Tuple<int, int>(x + horizontal[i], y + vertical[i]));
                }
                if (countTreasure == ut.ElementCount(jag, "T")) {
                    break;
                }
            }
            return dfslist;
        }
    }
}