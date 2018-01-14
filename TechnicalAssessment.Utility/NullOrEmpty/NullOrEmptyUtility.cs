namespace TechnicalAssessment.Utility.NullOrEmpty
{
    public static class NullOrEmptyUtility
    {
        /// <summary>
        /// Extension method to check is string is null or empty
        /// </summary>
        /// <param name="strVal">Input string</param>
        /// <returns>True if string is null or empty else false</returns>
        public static bool IsNullOrEmpty(this string strVal)
        {
            // Return true if string is null or empty else false
            if (strVal == null || strVal == "")
                return true;
            else
                return false;
        }
    }
}
