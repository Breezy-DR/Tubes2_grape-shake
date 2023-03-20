using System;

namespace Maze {
    struct MatrixElement {
        public string symbol;
        public int numberOfVisits;
        public MatrixElement(string _symbol, int _numberofVisits) {
            symbol = _symbol;
            numberOfVisits = _numberofVisits;
        }
    }
}