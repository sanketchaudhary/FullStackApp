using model = TechnicalAssessment.Models.Triangle;
namespace TechnicalAssessment.Utility.Traingle
{
    public interface ITraingleUtility
    {
        /// <summary>
        /// Method to calculate area of triangle
        /// </summary>
        /// <param name="triangle">triangle object with all three sides</param>
        /// <returns>Area of triangle</returns>
        double CalculateArea(model.Triangle triangle);
    }
}
