namespace Maze {
    class DFS {
        Utils ut = new Utils();
        public Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> findDFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Menghasilkan list process DFS secara keseluruhan dan list path dari titik start sampai ke treasure terakhir */
            List<Tuple<int, int, int, int>> dfsProcess = new List<Tuple<int, int, int, int>>();
            Tuple<int, int, List<Tuple<int, int, int, int>>> sub_solution;
            Utils ut = new Utils();
            int startX = x;
            int startY = y;
            int treasureFound = 0;
            int treasureAmount = ut.ElementCount(jag, "T");

            /* Menggunakan DFS untuk mencari semua treasure dari start. 
               Pencarian DFS dilakukan dari start ke treasure 1, treasure 1 ke treasure 2, dst sampai ke treasure terakhir */
            while (treasureFound < treasureAmount) {
                sub_solution = findSubDFS(treasureMap, jag, x, y);
                dfsProcess.AddRange(sub_solution.Item3);
                x = sub_solution.Item1;
                y = sub_solution.Item2;
                treasureFound++;
            }

            /* Mendapatkan list path dari list process DFS */
            List<Tuple<int, int>> solutionPath = ut.findPath(dfsProcess, startX, startY, x, y);

            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> dfsList = new Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>>(dfsProcess, solutionPath);
            ut.resetMainMatrix(treasureMap);
            return dfsList;
        }

        private Tuple<int, int, List<Tuple<int, int, int, int>>> findSubDFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Fungsi DFS dari satu treasure (x, y) ke treasure berikutnya. 
               Menghasilkan koordinat treasure berikutnya dan list process untuk koordinat yang diperiksa menggunakan DFS */
            bool found = false;
            Utils ut = new Utils();
            bool[,] isVisited = ut.InitBoolMatrix(jag);
            List <Tuple<int, int, int, int>> dfsProcess = new List<Tuple<int, int, int, int>>();
            Stack<Tuple<int, int, int, int>> dfsStack = new Stack<Tuple<int, int, int, int>>();
            dfsStack.Push(new Tuple<int, int, int, int>(x, y, x, y));
            int currentX = x;
            int currentY = y;
            int prevX;
            int prevY;

            /* Melakukan pop elemen dfsStack dan visit ke elemen tersebut. 
               Untuk setiap jalan yang dapat ditempuh dari elemen tersebut, maka akan dipush ke dfsStack.
               Prioritas push adalah down > up > right > left */
            while (!found) {
                currentX = dfsStack.Peek().Item1;
                currentY = dfsStack.Peek().Item2;
                prevX = dfsStack.Peek().Item3;
                prevY = dfsStack.Peek().Item4;
                dfsStack.Pop();

                /* Jika elemen yang dipop belum dikunjungi, maka dimasukkan ke dalam list dfsProcess */
                if (!isVisited[currentX, currentY]) {
                    isVisited[currentX, currentY] = true;
                    dfsProcess.Add(new Tuple<int, int, int, int>(currentX, currentY, prevX, prevY));
                }

                /* Jika treasure ditemukan, maka proses DFS berhenti */
                if (treasureMap[currentX][currentY].symbol == "T" && treasureMap[currentX][currentY].numberOfVisits < 1) {
                    found = true;
                }
                else {
                    /* Mencari jalan selanjutnya yang akan dipush */
                    if (ut.canMoveDown(treasureMap, currentX, currentY) && !isVisited[currentX + 1, currentY]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX + 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveUp(treasureMap, currentX, currentY) && !isVisited[currentX - 1, currentY]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX - 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveRight(treasureMap, currentX, currentY) && !isVisited[currentX, currentY + 1]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX, currentY + 1, currentX, currentY));
                    }
                    if (ut.canMoveLeft(treasureMap, currentX, currentY) && !isVisited[currentX, currentY - 1]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX, currentY - 1, currentX, currentY));
                    }
                }
                treasureMap[currentX][currentY].numberOfVisits++;
            }
            Tuple<int, int, List<Tuple<int, int, int, int>>> retVal = new Tuple<int, int, List<Tuple<int, int, int, int>>>(currentX, currentY, dfsProcess);
            return retVal;
        }
        public Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> findDFSTSP(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Menghasilkan list process DFS secara keseluruhan dan list path dari titik start sampai ke titik start kembali dengan semua treasure telah didapatkan */
            List<Tuple<int, int, int, int>> dfsProcess = new List<Tuple<int, int, int, int>>();
            List<Tuple<int, int, int, int>> tspPart;
            Tuple<int, int, List<Tuple<int, int, int, int>>> sub_solution;
            Utils ut = new Utils();
            int startX = x;
            int startY = y;
            int treasureFound = 0;
            int treasureAmount = ut.ElementCount(jag, "T");
            while (treasureFound < treasureAmount) {
                /* Menggunakan DFS untuk mencari semua treasure dari start. 
                   Pencarian DFS dilakukan dari start ke treasure 1, treasure 1 ke treasure 2, dst sampai ke treasure terakhir */
                sub_solution = findSubDFS(treasureMap, jag, x, y);
                dfsProcess.AddRange(sub_solution.Item3);
                x = sub_solution.Item1;
                y = sub_solution.Item2;
                treasureFound++;
            }
            /* Menggunakan DFS untuk mencapai titik start dari titik treasure terakhir (x, y) */
            tspPart = findTreasureToStartDFS(treasureMap, jag, x, y);
            dfsProcess.AddRange(tspPart);

            List<Tuple<int, int>> solutionPath = ut.findPath(dfsProcess, startX, startY, startX, startY);
            Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>> dfsList = new Tuple<List<Tuple<int, int, int, int>>, List<Tuple<int, int>>>(dfsProcess, solutionPath);
            ut.resetMainMatrix(treasureMap);
            return dfsList;
        }
        private List<Tuple<int, int, int, int>> findTreasureToStartDFS(MatrixElement[][] treasureMap, string[][] jag, int x, int y) {
            /* Fungsi DFS dari treasure terakhir ke titik start. 
               Menghasilkan koordinat dan list process untuk koordinat yang dicek menggunakan DFS */
            bool found = false;
            Utils ut = new Utils();
            bool[,] isVisited = ut.InitBoolMatrix(jag);
            List<Tuple<int, int, int, int>> DfsProcess = new List<Tuple<int, int, int, int>>();
            Stack<Tuple<int, int, int, int>> dfsStack = new Stack<Tuple<int, int, int, int>>();
            dfsStack.Push(new Tuple<int, int, int, int>(x, y, x, y));
            int currentX = x;
            int currentY = y;
            int prevX;
            int prevY;

            while (!found) {
                currentX = dfsStack.Peek().Item1;
                currentY = dfsStack.Peek().Item2;
                prevX = dfsStack.Peek().Item3;
                prevY = dfsStack.Peek().Item4;
                dfsStack.Pop();

                if (!isVisited[currentX, currentY]) {
                    isVisited[currentX, currentY] = true;
                    DfsProcess.Add(new Tuple<int, int, int, int>(currentX, currentY, prevX, prevY));
                }

                if (treasureMap[currentX][currentY].symbol == "K") {
                    found = true;
                }
                else {
                    if (ut.canMoveDown(treasureMap, currentX, currentY) && !isVisited[currentX + 1, currentY]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX + 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveUp(treasureMap, currentX, currentY) && !isVisited[currentX - 1, currentY]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX - 1, currentY, currentX, currentY));
                    }
                    if (ut.canMoveRight(treasureMap, currentX, currentY) && !isVisited[currentX, currentY + 1]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX, currentY + 1, currentX, currentY));
                    }
                    if (ut.canMoveLeft(treasureMap, currentX, currentY) && !isVisited[currentX, currentY - 1]) {
                        dfsStack.Push(new Tuple<int, int, int, int>(currentX, currentY - 1, currentX, currentY));
                    }
                }
                treasureMap[currentX][currentY].numberOfVisits++;
            }
            return (new List<Tuple<int, int, int, int>>(DfsProcess));
        }
    }
}