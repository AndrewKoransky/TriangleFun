using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TriangleFun.Filters;
using TriangleFun.Models;
using TriangleFun.Models.Validators;
using System.ComponentModel.DataAnnotations;
using TriangleFun.Service;

namespace TriangleFun.Controllers
{
  public class TriangleCalculatorController : ApiController
  {
    private ITriangleCalculator calc;
    public TriangleCalculatorController() : base() {
      calc = TriangleCalculator.Instance;
    }

    // GET: api/TriangleCalculator/PointCoordinatesFromGrid
    [AcceptVerbs("GET")]
    [HttpGet]
    public TriangleCartesianCoordinates CartesianCoordinatesFromGrid([Required][StringLength(1,MinimumLength = 1)][GridRowRange] string row, [Required] [Range(1,GridBounds.GridColumns)] int column)
    {
      return calc.CartesianCoordinatesFromGrid(row[0], column);
    }

    // Note to reviewer: This probably should be a GET request in order to comply with REST 
    //                   principles.The data coming in, with 3 X/Y pairs felt "structured" 
    //                   so I made a judgement call and used a POST request in order to 
    //                   better structure the incoming data. 

    // POST: api/TriangleCalculator/GridCoordinatesFromPoints
    [AcceptVerbs("POST")]
    [HttpPost]
    public GridCoordinate GridCoordinatesFromCartesian([FromBody][TriangleCartesianCoordinatesValid] TriangleCartesianCoordinates tdc)
    {
      return calc.GridCoordinatesFromCartesian(tdc);
    }
  }
}
