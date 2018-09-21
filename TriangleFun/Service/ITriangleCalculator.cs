using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriangleFun.Models;

namespace TriangleFun.Service
{
  public interface ITriangleCalculator
  {
    TriangleCartesianCoordinates CartesianCoordinatesFromGrid(char row, int column);
    GridCoordinate GridCoordinatesFromCartesian(TriangleCartesianCoordinates tdc);
  }
}
