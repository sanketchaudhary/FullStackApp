using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalAssessment.Utility.ListToStringUtility;
using TechnicalAssessment.Utility.ListToStringUtility.Impl;

namespace TechnicalAssessment.Business.CommonNumber.Impl
{
    public class CommonNumberManager : ICommonNumberManager
    {
        #region Properties
        IListToStringUtility _listToStringUtility;
        #endregion

        #region Constructors
        public CommonNumberManager() : this(new ListToStringUtility())
        { }

        public CommonNumberManager(IListToStringUtility listToStringUtility)
        {
            _listToStringUtility = listToStringUtility;
        }
        #endregion

        /// <summary>
        /// Method to get most common number from the lsit
        /// </summary>
        /// <param name="numberList">List of numbers</param>
        /// <returns>Most common number in the list</returns>
        public string GetCommonNumber(IEnumerable<string> numberList)
        {
            try {

                if (numberList != null)
                {
                    // Do lookup and get the unique numbers from the list 
                    var lookUp = numberList.ToLookup(n => n);

                    // If count is 0, return empty string
                    if (lookUp.Count == 0)
                        return string.Empty;

                    // Get maximum occurrence count of a number 
                    var maxOccurrence = lookUp.Max(n => n.Count());

                    // Select number from the list which has maximum occurrence
                    var result = lookUp.Where(n => n.Count() == maxOccurrence).Select(n => n.Key).ToList();

                    // Call utility method to convert list to comma separated string, if list count is greater than zero
                    return result.Count > 0 ? _listToStringUtility.ConvertListToString(result) : string.Empty;
                }
                else {
                    throw new Exception("Number list is null");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
