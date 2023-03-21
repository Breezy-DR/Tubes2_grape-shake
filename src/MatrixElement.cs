using System;

namespace Maze {
    struct MatrixElement {
        public string symbol;
        public int numberOfVisits;
        public MatrixElement(string _symbol, int _numberofVisits) {
            symbol = _symbol;
            numberOfVisits = _numberofVisits;
        }
        public bool canMoveRight(MatrixElement[][] mainMatrix, int x, int y) {
            return (!(mainMatrix[x][y+1].symbol == "X" || y == mainMatrix[0].Length - 1));
        }
        public bool canMoveLeft(MatrixElement[][] mainMatrix, int x, int y) {
            return (!(mainMatrix[x][y-1].symbol == "X" || y == 0));
        }
        public bool canMoveUp(MatrixElement[][] mainMatrix, int x, int y) {
            return (!(mainMatrix[x-1][y].symbol == "X" || x == 0));
        }
        public bool canMoveDown(MatrixElement[][] mainMatrix, int x, int y) {
            return (!(mainMatrix[x+1][y].symbol == "X" || x == mainMatrix.Length - 1));
        }
    }
}