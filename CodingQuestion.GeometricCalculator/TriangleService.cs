using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingQuestion.Entity;
using CodingQuestion.GeometricInterface;

namespace CodingQuestion.GeometricCalculator
{
    public class TriangleService : ITriangleService
    {
        #region 
        private readonly IDictionary<char, int> _rowMapping = new Dictionary<char, int>
        {
            {'A',0 },
            {'B',10 },
            {'C',20 },
            {'D',30 },
            {'E',40 },
            {'F',50 },
        };
        #endregion
        public IList<Coordinate> GetCoordinate(char row, int column)
        {
            ValidateRowAndColumn(row, column);

            var coordinates = new List<Coordinate>();

            var rowValue = _rowMapping[Char.ToUpper(row)];
            coordinates.Add(
                new Coordinate
                {
                    X = ((((column - 1) * 5) / 10) * 10),
                    Y = rowValue
                });

            coordinates.Add(
              new Coordinate
              {
                  X = column % 2 == 1 ? (column - 1) * 5 : ((column - 1) * 5) + 5,
                  Y = column % 2 == 1 ? rowValue+10 : rowValue
              });

            coordinates.Add(
              new Coordinate
              {
                  X = column % 2 == 1 ? ((column - 1) * 5) +10 : ((column - 1) * 5) + 5,
                  Y = rowValue + 10
              });

            return coordinates;
        }
               
        public Cell GetTriangleLocation(IList<Coordinate> coordinates)
        {
            ValidateCoordinate(coordinates);

            var minY = coordinates.Min(r => r.Y);
            var row = _rowMapping.Where(r => r.Value == minY)
                .Select(r => r.Key)
                .FirstOrDefault();
            
            var maxX = coordinates.Max(r => r.X);
            var column = coordinates.Where(r => r.X == maxX)?.Count() > 1 ? maxX / 5 : maxX / 5 - 1;

            return new Cell
            {
                Row = row,
                Column = column
            };
        }

        private void ValidateCoordinate(IList<Coordinate> coordinate)
        {
            //TODO: validate the coordinates
            //the list should contain three coordinates
            //and the x and y value of the coordinate should be less than 60
        }

        private void ValidateRowAndColumn(char row, int column)
        {
            //TODO: validate the row and column
            //the row should be b/n A and F 
            //the column should be b/n 1 and 12
        }
    }
}
