using TechnicalAssessment.Utility.NullOrEmpty;

namespace TechnicalAssessment.Business.NullOrEmpty.Impl
{
    public class NullOrEmptyManager : INullOrEmptyManager
    {
        /// <summary>
        /// Method to check if string is null or empty
        /// </summary>
        /// <param name="strVal">string value to check</param>
        /// <returns>True if string is null or empty else false</returns>
        public bool CheckString(string strVal)
        {
            // Call Extension method to check if string is null or empty
            return NullOrEmptyUtility.IsNullOrEmpty(strVal);
        }
    }
}
