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

            /* Menggunakan BFS untuk mencari semua treasure dari start. 
               Pencarian BFS dilakukan dari start ke treasure 1, treasure 1 ke treasure 2, dst sampai ke treasure terakhir */
            while (treasureFound < treasureAmount) {
                sub_solution = findSubBFS(treasureMap, jag, x, y);
                bfsProcess.AddRange(sub_solution.Item3);
                x = sub_solution.Item1;
                y = sub_solution.Item2;
                treasureFound++;
            }

            /* Mendapatkan list path dari list process BFS */
            List<Tuple<int, int>> solutionPath = ut.findPath(bfsProcess, startX, startY, x, y);

            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList = new Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>>(bfsProcess, solutionPath);
            ut.resetMainMatrix(treasureMap);
            return bfsList;
        }

        private Tuple<int, int, List<Tuple<int, int, int, int>>> findSubBFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Fungsi BFS dari satu treasure (x, y) ke treasure berikutnya. 
               Menghasilkan koordinat treasure berikutnya dan list process untuk koordinat yang diperiksa menggunakan BFS */
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

            /* Melakukan dequeue elemen bfsQueue dan visit ke elemen tersebut. 
               Untuk setiap jalan yang dapat ditempuh dari elemen tersebut, maka akan dienqueue ke bfsQueue.
               Prioritas enqueue adalah down > up > right > left */
            while (!found) {
                currentX = bfsQueue.Peek().Item1;
                currentY = bfsQueue.Peek().Item2;
                prevX = bfsQueue.Peek().Item3;
                prevY = bfsQueue.Peek().Item4;
                bfsQueue.Dequeue();

                /* Jika elemen yang didequeue belum dikunjungi, maka dimasukkan ke dalam list bfsProcess */
                if (!isVisited[currentX, currentY]) {
                    isVisited[currentX, currentY] = true;
                    bfsProcess.Add(new Tuple<int, int, int, int>(currentX, currentY, prevX, prevY));
                }

                /* Jika treasure ditemukan, maka proses BFS berhenti */
                if (treasureMap[currentX][currentY].symbol == "T" && treasureMap[currentX][currentY].numberOfVisits < 1) {
                    found = true;
                }
                else {
                    /* Mencari jalan selanjutnya yang akan dienqueue */
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

        

        public Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> findBFSTSP(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Menghasilkan list process BFS secara keseluruhan dan list path dari titik start sampai ke titik start kembali dengan semua treasure telah didapatkan */
            List<Tuple<int, int, int, int>> bfsProcess = new List<Tuple<int, int, int, int>>();
            List<Tuple<int, int, int, int>> tspPart;
            Tuple<int, int, List<Tuple<int, int, int, int>>> sub_solution;
            Utils ut = new Utils();
            int startX = x;
            int startY = y;
            int treasureFound = 0;
            int treasureAmount = ut.ElementCount(jag, "T");
            while (treasureFound < treasureAmount) {
                /* Menggunakan BFS untuk mencari semua treasure dari start. 
                   Pencarian BFS dilakukan dari start ke treasure 1, treasure 1 ke treasure 2, dst sampai ke treasure terakhir */
                sub_solution = findSubBFS(treasureMap, jag, x, y);
                bfsProcess.AddRange(sub_solution.Item3);
                x = sub_solution.Item1;
                y = sub_solution.Item2;
                treasureFound++;
            }
            /* Menggunakan BFS untuk mencapai titik start dari titik treasure terakhir (x, y) */
            tspPart = findTreasureToStartBFS(treasureMap, jag, x, y);
            bfsProcess.AddRange(tspPart);

            List<Tuple<int, int>> solutionPath = ut.findPath(bfsProcess, startX, startY, startX, startY);
            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> bfsList = new Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>>(bfsProcess, solutionPath);
            ut.resetMainMatrix(treasureMap);
            return bfsList;
        }

        

        

        private List<Tuple<int, int, int, int>> findTreasureToStartBFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Fungsi BFS dari treasure terakhir ke titik start. 
               Menghasilkan koordinat dan list process untuk koordinat yang dicek menggunakan BFS */
            bool found = false;
            Utils ut = new Utils();
            bool[,] isVisited = ut.InitBoolMatrix(jag);
            List<Tuple<int, int, int, int>> bfsProcess = new List<Tuple<int, int, int, int>>();
            Queue<Tuple<int, int, int, int>> BFSQueue = new Queue<Tuple<int, int, int, int>>();
            BFSQueue.Enqueue(new Tuple<int, int, int, int>(x, y, x, y));
            int currentX = x;
            int currentY = y;
            int prevX;
            int prevY;

            while (!found) {
                currentX = BFSQueue.Peek().Item1;
                currentY = BFSQueue.Peek().Item2;
                prevX = BFSQueue.Peek().Item3;
                prevY = BFSQueue.Peek().Item4;
                BFSQueue.Dequeue();

                if (!isVisited[currentX, currentY]) {
                    isVisited[currentX, currentY] = true;
                    bfsProcess.Add(new Tuple<int, int, int, int>(currentX, currentY, prevX, prevY));
                }

                if (treasureMap[currentX][currentY].symbol == "K") {
                    found = true;
                }
                else {
                    if (ut.canMoveDown(treasureMap, currentX, currentY) && !isVisited[currentX + 1, currentY]) {
                        BFSQueue.Enqueue(new Tuple<int, int, int, int>(currentX + 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveUp(treasureMap, currentX, currentY) && !isVisited[currentX - 1, currentY]) {
                        BFSQueue.Enqueue(new Tuple<int, int, int, int>(currentX - 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveRight(treasureMap, currentX, currentY) && !isVisited[currentX, currentY + 1]) {
                        BFSQueue.Enqueue(new Tuple<int, int, int, int>(currentX, currentY + 1, currentX, currentY));
                    }
                    if (ut.canMoveLeft(treasureMap, currentX, currentY) && !isVisited[currentX, currentY - 1]) {
                        BFSQueue.Enqueue(new Tuple<int, int, int, int>(currentX, currentY - 1, currentX, currentY));
                    }
                }
                treasureMap[currentX][currentY].numberOfVisits++;
            }
            return (new List<Tuple<int, int, int, int>>(bfsProcess));
        }
    }
}