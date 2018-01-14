namespace TechnicalAssessment.Business.PositiveDivisor
{
    public interface IPositiveDivisorManager
    {
        /// <summary>
        /// Method to calculate positive divisor for given number
        /// </summary>
        /// <param name="number">Number to calculate positive divisor</param>
        /// <returns>Comma separated string of divisors</returns>
        string CalculatePositiveDivisor(int number);
    }
}
