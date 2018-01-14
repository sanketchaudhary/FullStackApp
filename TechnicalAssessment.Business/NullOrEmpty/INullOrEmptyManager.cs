namespace TechnicalAssessment.Business.NullOrEmpty
{
    public interface INullOrEmptyManager
    {
        /// <summary>
        /// Method to check if string is null or empty
        /// </summary>
        /// <param name="strVal">string value to check</param>
        /// <returns>true if string is null or empty else false</returns>
        bool CheckString(string strVal);
    }
}
