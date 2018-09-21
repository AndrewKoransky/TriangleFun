using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TriangleFun.Models
{
  public class CartesianCoordinate
  {
    public CartesianCoordinate(int x, int y)
    {
      X = x;
      Y = y;
    }

    [Required]
    [Range(0, GridBounds.MaxCartesianCoordinateX)]
    public int X { get; }

    [Required]
    [Range(0, GridBounds.MaxCartesianCoordinateY)]
    public int Y { get; }

    public override bool Equals(object obj)
    {
      return base.Equals(obj as CartesianCoordinate);
    }
    public bool Equals(CartesianCoordinate obj)
    {
      return (obj != null) && (obj.X == this.X) && (obj.Y == this.Y);
    }
    public override int GetHashCode()
    {
      unchecked
      {
        int hash = 17;
        hash = hash * 23 + X.GetHashCode();
        hash = hash * 23 + Y.GetHashCode();
        return hash;
      }
    }
    public override string ToString()
    {
      return "{" + X.ToString() + "," + Y.ToString() + "}";
    }
  }
}