# TriangleFun
## Notes:
1. I ran out of time and did not implement client side validation.
2. Known issue - crashes if fields are empty. See #1.
3. Note to reviewer: POST: api/TriangleCalculator/GridCoordinatesFromPoints - 
   This probably should be a GET request in order to comply with REST 
   principles. The data coming in, with 3 X/Y pairs felt "structured" 
   so I made a judgment call and used a POST request in order to 
   better structure the incoming data.
