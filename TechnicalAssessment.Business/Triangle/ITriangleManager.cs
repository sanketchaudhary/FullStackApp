using model = TechnicalAssessment.Models.Triangle;
namespace TechnicalAssessment.Business.Triangle
{
    public interface ITriangleManager
    {
        /// <summary>
        /// Business method to calculate Traingle area
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <returns>Traingle Type</returns>
        double CalculateTriangleArea(model.Triangle triangle);
    }
}
