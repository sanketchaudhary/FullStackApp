using System;
using model = TechnicalAssessment.Models.Triangle;

namespace TechnicalAssessment.Utility.Traingle.Impl
{
    public class TriangleUtility: ITraingleUtility
    {
        /// <summary>
        /// Method to calculate area of triangle
        /// </summary>
        /// <param name="triangle">triangle object with all three sides</param>
        /// <returns>Area of triangle</returns>
        public double CalculateArea(model.Triangle triangle)
        {
            double area = 0;

            // Calculate Perimeter
            var perimeter = (triangle.SideOne + triangle.SideTwo + triangle.SideThree) / 2;
            
            // Calculate area
            area = Math.Sqrt(perimeter * (perimeter - triangle.SideOne) * (perimeter - triangle.SideTwo) * (perimeter - triangle.SideThree));

            // Return area
            return area;
        }
    }
}
