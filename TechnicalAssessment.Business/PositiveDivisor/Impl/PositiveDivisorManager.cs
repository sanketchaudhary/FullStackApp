using System;
using System.Collections.Generic;
using TechnicalAssessment.Utility.ListToStringUtility;
using TechnicalAssessment.Utility.ListToStringUtility.Impl;

namespace TechnicalAssessment.Business.PositiveDivisor.Impl
{
    public class PositiveDivisorManager : IPositiveDivisorManager
    {
        #region Properties
        IListToStringUtility _listToStringUtility;
        #endregion

        #region Constructors
        public PositiveDivisorManager() : this(new ListToStringUtility())
        { }

        public PositiveDivisorManager(IListToStringUtility listToStringUtility)
        {
            _listToStringUtility = listToStringUtility;
        }
        #endregion

        /// <summary>
        /// Method to calculate positive divisor for given number
        /// </summary>
        /// <param name="number">Number to calculate positive divisor</param>
        /// <returns>Comma separated string of divisors</returns>
        public string CalculatePositiveDivisor(int number)
        {
            try
            {
                var divisorlist = new List<string>();

                // Iterate and add positive divisors to list
                for (int n = 1; n <= number; n++)
                {
                    // If remainder is zero add that number to divisor list
                    if (number % n == 0)
                        divisorlist.Add(n.ToString());
                }

                // Call utility method to convert divisor list to comma separated string, if list count is greater than zero
                return divisorlist.Count > 0 ? _listToStringUtility.ConvertListToString(divisorlist) : string.Empty;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
