using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TriangleFun.Models
{
  public class GridBounds
  {
    public const int TriangleSidePixels = 10;
    public const int TriangleSideAddend = TriangleSidePixels - 1;
    public const int GridRows = 6; // max supported is 26
    public const int GridColumns = 12; // NOTE: must be an even number
    public const int MaxCartesianCoordinateX = GridColumns / 2 * TriangleSidePixels - 1;
    public const int MaxCartesianCoordinateY = GridRows * TriangleSidePixels - 1;
  }
}