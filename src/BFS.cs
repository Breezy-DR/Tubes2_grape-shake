using System;
using System.Collections.Generic;

namespace Maze {
    class BFS {
        public Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> findBFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Menghasilkan list process BFS secara keseluruhan dan list path dari titik start sampai ke treasure terakhir */
            List<Tuple<int, int, int, int>> bfsProcess = new List<Tuple<int, int, int, int>>();
            Tuple<int, int, List<Tuple<int, int, int, int>>> sub_solution;
            Utils ut = new Utils();
            int startX = x;
            int startY = y;
            int treasureFound = 0;
            int treasureAmount = ut.ElementCount(jag, "T");
            while (treasureFound < treasureAmount) {
                sub_solution = findSubBFS(treasureMap, jag, x, y);
                bfsProcess.AddRange(sub_solution.Item3);
                x = sub_solution.Item1;
                y = sub_solution.Item2;
                treasureFound++;
            }
            List<Tuple<int, int>> solutionPath = findPath(bfsProcess, x, y, startX, startY);
            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList = new Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>>(bfsProcess, solutionPath);
            ut.resetMainMatrix(treasureMap);
            return bfsList;
        }

        private Tuple<int, int, List<Tuple<int, int, int, int>>> findSubBFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Fungsi BFS untuk satu tujuan (dari (x,y) ke treasure berikutnya). 
               Menghasilkan koordinat treasure dan list process untuk koordinat yang dicek menggunakan BFS */
            bool found = false;
            Utils ut = new Utils();
            bool[,] isVisited = ut.InitBoolMatrix(jag);
            List <Tuple<int, int, int, int>> bfsProcess = new List<Tuple<int, int, int, int>>();
            Queue<Tuple<int, int, int, int>> bfsQueue = new Queue<Tuple<int, int, int, int>>();
            bfsQueue.Enqueue(new Tuple<int, int, int, int>(x, y, x, y));
            int currentX = x;
            int currentY = y;
            int prevX;
            int prevY;

            while (!found) {
                currentX = bfsQueue.Peek().Item1;
                currentY = bfsQueue.Peek().Item2;
                prevX = bfsQueue.Peek().Item3;
                prevY = bfsQueue.Peek().Item4;
                bfsQueue.Dequeue();

                if (!isVisited[currentX, currentY]) {
                    isVisited[currentX, currentY] = true;
                    bfsProcess.Add(new Tuple<int, int, int, int>(currentX, currentY, prevX, prevY));
                }

                if (treasureMap[currentX][currentY].symbol == "T" && treasureMap[currentX][currentY].numberOfVisits < 1) {
                    found = true;
                }
                else {
                    if (ut.canMoveDown(treasureMap, currentX, currentY) && !isVisited[currentX + 1, currentY]) {
                        bfsQueue.Enqueue(new Tuple<int, int, int, int>(currentX + 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveUp(treasureMap, currentX, currentY) && !isVisited[currentX - 1, currentY]) {
                        bfsQueue.Enqueue(new Tuple<int, int, int, int>(currentX - 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveRight(treasureMap, currentX, currentY) && !isVisited[currentX, currentY + 1]) {
                        bfsQueue.Enqueue(new Tuple<int, int, int, int>(currentX, currentY + 1, currentX, currentY));
                    }
                    if (ut.canMoveLeft(treasureMap, currentX, currentY) && !isVisited[currentX, currentY - 1]) {
                        bfsQueue.Enqueue(new Tuple<int, int, int, int>(currentX, currentY - 1, currentX, currentY));
                    }
                }
                treasureMap[currentX][currentY].numberOfVisits++;
            }
            Tuple<int, int, List<Tuple<int, int, int, int>>> retVal = new Tuple<int, int, List<Tuple<int, int, int, int>>>(currentX, currentY, bfsProcess);
            return retVal;
        }

        public List<Tuple<int, int>> findPath(List<Tuple<int, int, int, int>> bfsProcess, int x, int y, int startX, int startY) {
            /* Fungsi untuk mencari path dari list process. 
               Menghasilkan list path dari titik start sampai ke treasure terakhir */
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            int i = bfsProcess.Count - 1;

            while (!(bfsProcess[i].Item1 == startX && bfsProcess[i].Item2 == startY && bfsProcess[i].Item3 == startX && bfsProcess[i].Item4 == startY)) {
                if ((bfsProcess[i].Item1 == x && bfsProcess[i].Item2 == y) && !(bfsProcess[i].Item1 == bfsProcess[i].Item3 && bfsProcess[i].Item2 == bfsProcess[i].Item4)) {
                    path.Add(new Tuple<int, int>(bfsProcess[i].Item1, bfsProcess[i].Item2));
                    x = bfsProcess[i].Item3;
                    y = bfsProcess[i].Item4;
                }
                i--;
            }
            path.Add(new Tuple<int, int>(startX, startY));
            path.Reverse();
            return path;
        }
    }
}