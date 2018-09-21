using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleFun.Controllers;
using TriangleFun.Models;
using TriangleFun.Models.Validators;

namespace TriangleFun.Tests
{
  [TestClass]
  public class TriangleCalculatorControllerTests
  {
    [TestMethod]
    public void CartesianCoordinatesFromGridColumnOutOfBounds()
    {
      // Act
      GridRowRangeAttribute gridRowRangeValidator = new GridRowRangeAttribute();
      Assert.IsFalse(gridRowRangeValidator.IsValid("Z"));

      Assert.IsTrue(gridRowRangeValidator.IsValid("A"));
    }

    [TestMethod]
    public void CartesianCoordinatesFromGridA1()
    {
      // Arrange
      TriangleCalculatorController controller = new TriangleCalculatorController();

      // Act
      TriangleCartesianCoordinates result = controller.CartesianCoordinatesFromGrid("A", 1);

      // Assert
      Assert.IsNotNull(result);

      // these tests depend on implementation (expects order of vertices to be in a particular order)
      // UpperLeft
      Assert.AreEqual<int>(result.V1.X, 0);
      Assert.AreEqual<int>(result.V1.Y, 0);

      // LowerLeft
      Assert.AreEqual<int>(result.V2.X, 0);
      Assert.AreEqual<int>(result.V2.Y, GridBounds.TriangleSideAddend);

      // LowerRight
      Assert.AreEqual<int>(result.V3.X, GridBounds.TriangleSideAddend);
      Assert.AreEqual<int>(result.V3.Y, GridBounds.TriangleSideAddend);
    }

    [TestMethod]
    public void CartesianCoordinatesFromGridA2()
    {
      // Arrange
      TriangleCalculatorController controller = new TriangleCalculatorController();

      // Act
      TriangleCartesianCoordinates result = controller.CartesianCoordinatesFromGrid("A", 2);

      // Assert
      Assert.IsNotNull(result);

      // these tests depend on implementation (expects order of vertices to be in a particular order)
      // UpperLeft
      Assert.AreEqual<int>(result.V1.X, 0);
      Assert.AreEqual<int>(result.V1.Y, 0);

      // UpperRight
      Assert.AreEqual<int>(result.V2.X, GridBounds.TriangleSideAddend);
      Assert.AreEqual<int>(result.V2.Y, 0);

      // LowerRight
      Assert.AreEqual<int>(result.V3.X, GridBounds.TriangleSideAddend);
      Assert.AreEqual<int>(result.V3.Y, GridBounds.TriangleSideAddend);
    }

    [TestMethod]
    public void CartesianCoordinatesFromGridC9()
    {
      // Arrange
      TriangleCalculatorController controller = new TriangleCalculatorController();

      // Act
      TriangleCartesianCoordinates result = controller.CartesianCoordinatesFromGrid("C", 9);

      // Assert
      Assert.IsNotNull(result);

      // these tests depend on implementation (expects order of vertices to be in a particular order)
      // UpperLeft
      Assert.AreEqual<int>(result.V1.X, 4 * GridBounds.TriangleSidePixels);
      Assert.AreEqual<int>(result.V1.Y, 2 * GridBounds.TriangleSidePixels);

      // LowerLeft
      Assert.AreEqual<int>(result.V2.X, 4 * GridBounds.TriangleSidePixels);
      Assert.AreEqual<int>(result.V2.Y, 2 * GridBounds.TriangleSidePixels + GridBounds.TriangleSideAddend);

      // LowerRight
      Assert.AreEqual<int>(result.V3.X, 4 * GridBounds.TriangleSidePixels + GridBounds.TriangleSideAddend);
      Assert.AreEqual<int>(result.V3.Y, 2 * GridBounds.TriangleSidePixels + GridBounds.TriangleSideAddend);
    }

    [TestMethod]
    public void GridCoordinatesInputEqual()
    {
      //Arrange
      TriangleCartesianCoordinates tcc = new TriangleCartesianCoordinates(new CartesianCoordinate(0, 0), new CartesianCoordinate(0, 0), new CartesianCoordinate(0, 0));
      
      //Act
      TriangleCartesianCoordinatesValidAttribute tccValidator = new TriangleCartesianCoordinatesValidAttribute();
      Assert.IsFalse(tccValidator.IsValid(tcc));
    }

    [TestMethod]
    public void GridCoordinatesInputBadPoints()
    {
      // Arrange
      TriangleCartesianCoordinates tcc = new TriangleCartesianCoordinates(new CartesianCoordinate(0, 10), new CartesianCoordinate(10, 0), new CartesianCoordinate(10, 10));

      // Act
      TriangleCartesianCoordinatesValidAttribute tccValidator = new TriangleCartesianCoordinatesValidAttribute();
      Assert.IsFalse(tccValidator.IsValid(tcc));
    }

    [TestMethod]
    public void GridCoordinatesInputPointsOutOfRange()
    {
      // Arrange
      TriangleCartesianCoordinates tcc = new TriangleCartesianCoordinates(new CartesianCoordinate(0, 9), new CartesianCoordinate(9, 0), new CartesianCoordinate(10, 19));

      // Act
      TriangleCartesianCoordinatesValidAttribute tccValidator = new TriangleCartesianCoordinatesValidAttribute();
      Assert.IsFalse(tccValidator.IsValid(tcc));
    }

    [TestMethod]
    public void GridCoordinatesFromCartesianA2()
    {
      // Arrange
      TriangleCalculatorController controller = new TriangleCalculatorController();

      // Act
      GridCoordinate result = controller.GridCoordinatesFromCartesian(new TriangleCartesianCoordinates(new CartesianCoordinate(0, 0), new CartesianCoordinate(9, 9), new CartesianCoordinate(9, 0)));

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual<string>("A", result.Row);
      Assert.AreEqual<int>(2, result.Col);
    }

    [TestMethod]
    public void GridCoordinatesFromCartesianC9()
    {
      // Arrange
      TriangleCalculatorController controller = new TriangleCalculatorController();

      // Act
      GridCoordinate result = controller.GridCoordinatesFromCartesian(new TriangleCartesianCoordinates(new CartesianCoordinate(40, 20), new CartesianCoordinate(40, 29), new CartesianCoordinate(49, 29)));

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual<string>("C", result.Row);
      Assert.AreEqual<int>(9, result.Col);
    }

    [TestMethod]
    public void EqualityTest()
    {
      // Arrange
      TriangleCalculatorController controller = new TriangleCalculatorController();

      for (char row='A'; row < 'A' + GridBounds.GridRows; row++)
      {
        for (int col=1; col <= GridBounds.GridColumns; col++)
        {
          TriangleCartesianCoordinates tdc = controller.CartesianCoordinatesFromGrid(row.ToString(), col);
          Assert.IsNotNull(tdc);
          GridCoordinate tgc = controller.GridCoordinatesFromCartesian(tdc);

          Assert.AreEqual<string>(row.ToString(), tgc.Row);
          Assert.AreEqual<int>(col, tgc.Col);
          System.Diagnostics.Debug.WriteLine(row.ToString() + col.ToString() + ": " + tdc.V1.ToString() + ", " + tdc.V2.ToString() + ", " + tdc.V3);
        }
      }
    }
  }
}
