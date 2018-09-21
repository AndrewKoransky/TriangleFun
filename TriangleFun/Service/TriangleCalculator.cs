using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TriangleFun.Models;
using static TriangleFun.Models.GridBounds;

namespace TriangleFun.Service
{
  public class TriangleCalculator : ITriangleCalculator
  {
    // singleton...
    public static ITriangleCalculator Instance { get; } = new TriangleCalculator();
    private TriangleCalculator() { }

    public TriangleCartesianCoordinates CartesianCoordinatesFromGrid(char row, int column)
    {
      // calculate
      int rowInt = char.ToUpper(row) - 'A';
      TriangleCartesianCoordinates tcc;
      if ((column % 2) == 0)
      { // even number column
        int halfColumn = (column / 2) - 1;
        tcc = new TriangleCartesianCoordinates(new CartesianCoordinate(halfColumn * TriangleSidePixels, rowInt * TriangleSidePixels) /*UpperLeft*/,
                                          new CartesianCoordinate(halfColumn * TriangleSidePixels + TriangleSideAddend, rowInt * TriangleSidePixels)/*UpperRight*/,
                                          new CartesianCoordinate(halfColumn * TriangleSidePixels + TriangleSideAddend, rowInt * TriangleSidePixels + TriangleSideAddend)/*LowerRight*/);
      }
      else // odd number column
      {
        int halfColumn = column / 2;
        tcc = new TriangleCartesianCoordinates(new CartesianCoordinate(halfColumn * TriangleSidePixels, rowInt * TriangleSidePixels) /*UpperLeft*/,
                                          new CartesianCoordinate(halfColumn * TriangleSidePixels, rowInt * TriangleSidePixels + TriangleSideAddend)/*LowerLeft*/,
                                          new CartesianCoordinate(halfColumn * TriangleSidePixels + TriangleSideAddend, rowInt * TriangleSidePixels + TriangleSideAddend)/*LowerRight*/);
      }
      return tcc;
    }

    public GridCoordinate GridCoordinatesFromCartesian(TriangleCartesianCoordinates tdc)
    {
      // calculate...
      int minX = Math.Min(Math.Min(tdc.V1.X, tdc.V2.X), tdc.V3.X);
      int minY = Math.Min(Math.Min(tdc.V1.Y, tdc.V2.Y), tdc.V3.Y);
      int avgXOffset = ((tdc.V1.X + tdc.V2.X + tdc.V3.X) / 3) - minX;
      int avgYOffset = ((tdc.V1.Y + tdc.V2.Y + tdc.V3.Y) / 3) - minY;
      if (avgXOffset > avgYOffset)
      {
        return new GridCoordinate(((char)('A' + minY / TriangleSidePixels)).ToString(), (minX / TriangleSidePixels + 1) * 2);
      }
      else
      {
        return new GridCoordinate(((char)('A' + minY / TriangleSidePixels)).ToString(), (minX / TriangleSidePixels) * 2 + 1);
      }
    }
  }
}