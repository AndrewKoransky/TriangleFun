using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static TriangleFun.Models.GridBounds;

namespace TriangleFun.Models.Validators
{
  [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Class, AllowMultiple = false)]
  public class TriangleCartesianCoordinatesValidAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value == null) {
        return ValidationResult.Success;
      }

      TriangleCartesianCoordinates tdc = value as TriangleCartesianCoordinates;

      // verify input
      CartesianCoordinate[] points = new CartesianCoordinate[] { tdc.V1, tdc.V2, tdc.V3 };
      foreach (CartesianCoordinate pt in points)
      {
        // point must be in the right location...
        if (((pt.X % TriangleSidePixels) != 0) && ((pt.X % TriangleSidePixels) != TriangleSideAddend))
        {
          return new ValidationResult("point does not represent a triangle vertex:" + pt.ToString());
        }
      }
      if (tdc.V1.Equals(tdc.V2) || tdc.V2.Equals(tdc.V3) || tdc.V3.Equals(tdc.V1))
      {
        return new ValidationResult("triangles points cannot be identical");
      }
      int minX = Math.Min(Math.Min(tdc.V1.X, tdc.V2.X), tdc.V3.X);
      int maxX = Math.Max(Math.Max(tdc.V1.X, tdc.V2.X), tdc.V3.X);
      int minY = Math.Min(Math.Min(tdc.V1.Y, tdc.V2.Y), tdc.V3.Y);
      int maxY = Math.Max(Math.Max(tdc.V1.Y, tdc.V2.Y), tdc.V3.Y);
      if ((minX + TriangleSideAddend != maxX) || (minY + TriangleSideAddend != maxY))
      {
        return new ValidationResult("triangle coordinates exceed the bounds of potential triangle");
      }
      return ValidationResult.Success;
    }
  }
}