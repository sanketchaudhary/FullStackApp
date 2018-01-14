using System.Collections.Generic;

namespace TechnicalAssessment.Utility.ListToStringUtility
{
    public interface IListToStringUtility
    {
        /// <summary>
        /// Method to convert string list to comma separated string
        /// </summary>
        /// <param name="strList">List to convert to string</param>
        /// <returns>Comma separated string</returns>
        string ConvertListToString(List<string> strList);
    }
}
