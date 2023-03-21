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
        public bool stuck(MatrixElement[][] mainMatrix, bool[,] isVisited, int x, int y) {
            return ((!canMoveDown(mainMatrix, x, y) && !canMoveUp(mainMatrix, x, y) && !canMoveRight(mainMatrix, x, y) && canMoveLeft(mainMatrix, x, y) && isVisited[x, y-1])
            || (!canMoveDown(mainMatrix, x, y) && !canMoveUp(mainMatrix, x, y) && canMoveRight(mainMatrix, x, y) && !canMoveLeft(mainMatrix, x, y) && isVisited[x, y+1]) ||
            (!canMoveDown(mainMatrix, x, y) && canMoveUp(mainMatrix, x, y) && !canMoveRight(mainMatrix, x, y) && !canMoveLeft(mainMatrix, x, y) && isVisited[x-1, y]) ||
            (canMoveDown(mainMatrix, x, y) && !canMoveUp(mainMatrix, x, y) && !canMoveRight(mainMatrix, x, y) && !canMoveLeft(mainMatrix, x, y) && isVisited[x+1, y]));
        }

        public bool isAdjacentToUnvisited(MatrixElement[][] mainMatrix, bool[,] isVisited, int x, int y) {
            return ((canMoveDown(mainMatrix, x, y) && !isVisited[x+1, y]) ||
            (canMoveUp(mainMatrix, x, y) && !isVisited[x-1, y]) ||
            (canMoveRight(mainMatrix, x, y) && !isVisited[x, y+1]) ||
            (canMoveLeft(mainMatrix, x, y) && !isVisited[x, y-1]));
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
                else {
                    if (stuck(mainMatrix, isVisited, x, y)) {
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
                            i++;
                        } while (!isAdjacentToUnvisited(mainMatrix, isVisited, reverse[i].Item1, reverse[i].Item2));
                    }
                }
            }
            return dfslist;
        }
    }
}