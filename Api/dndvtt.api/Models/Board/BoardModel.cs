﻿namespace dndvtt.api.Models.Board
{
    public class BoardModel
    {
        public List<List<CellModel>> _cells { get; set; }
        public int _width { get; set; }
        public int _height { get; set; }

        public BoardModel(int width, int height) { 
            _width = width;
            _height = height;
            _cells = Enumerable.Repeat(Enumerable.Repeat(new CellModel(), width).ToList(), height).ToList();
        }
        public BoardModel(int width, int height, List<List<CellModel>> cells)
        {
            _width = width;
            _height = height;
            _cells = cells;
        }
        public BoardModel(BoardModel boardModel)
        {
            _width = boardModel._width;
            _height = boardModel._height;
            _cells = boardModel._cells;
        }
    }
}
