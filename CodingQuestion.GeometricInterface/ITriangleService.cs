using CodingQuestion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestion.GeometricInterface
{
    public interface ITriangleService
    {
        IList<Coordinate> GetCoordinate(char row, int column);
        Cell GetTriangleLocation(IList<Coordinate> coordinate);
    }
}
