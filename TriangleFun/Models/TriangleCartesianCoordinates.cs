using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TriangleFun.Models.Validators;

namespace TriangleFun.Models
{
  [TriangleCartesianCoordinatesValid]
  public class TriangleCartesianCoordinates
  {
    public TriangleCartesianCoordinates(CartesianCoordinate v1, CartesianCoordinate v2, CartesianCoordinate v3)
    {
      V1 = v1;
      V2 = v2;
      V3 = v3;
    }

    [Required]
    public CartesianCoordinate V1 { get; }

    [Required]
    public CartesianCoordinate V2 { get; }

    [Required]
    public CartesianCoordinate V3 { get; }
  }
}