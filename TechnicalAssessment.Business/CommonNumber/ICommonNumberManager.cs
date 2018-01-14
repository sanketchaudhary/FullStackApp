using System.Collections.Generic;

namespace TechnicalAssessment.Business.CommonNumber
{
    public interface ICommonNumberManager
    {
        /// <summary>
        /// Method to get most common number from the lsit
        /// </summary>
        /// <param name="numberList">List of numbers</param>
        /// <returns>Most common number in the list</returns>
        string GetCommonNumber(IEnumerable<string> numberList);
    }
}
