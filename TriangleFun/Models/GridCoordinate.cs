using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TriangleFun.Models.Validators;

namespace TriangleFun.Models
{
  public class GridCoordinate
  {
    public GridCoordinate(string row, int col)
    {
      Row = row;
      Col = col;
    }

    [Required]
    [StringLength(1,MinimumLength = 1)]
    [GridRowRange]
    public string Row { get; }

    [Required]
    [Range(1,GridBounds.GridColumns)]
    public int Col { get; }
  }
}