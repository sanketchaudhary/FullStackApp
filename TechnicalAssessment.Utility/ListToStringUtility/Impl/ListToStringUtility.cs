using System.Collections.Generic;

namespace TechnicalAssessment.Utility.ListToStringUtility.Impl
{
    public class ListToStringUtility : IListToStringUtility
    {
        /// <summary>
        /// Method to convert string list to comma separated string
        /// </summary>
        /// <param name="strList">List to convert to string</param>
        /// <returns>Comma separated string</returns>
        public string ConvertListToString(List<string> strList)
        {
            var finalStr = string.Empty;

            // Check if list count is greater than zero, if yes convert list to comma separated string
            if (strList.Count > 0)
                finalStr = "{" + string.Join(",", strList) + "}";

            // Return string
            return finalStr;
        }
    }
}
