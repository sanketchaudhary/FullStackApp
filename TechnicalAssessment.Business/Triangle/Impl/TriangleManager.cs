using System;
using TechnicalAssessment.Utility.Traingle;
using TechnicalAssessment.Utility.Traingle.Impl;
using model = TechnicalAssessment.Models.Triangle;

namespace TechnicalAssessment.Business.Triangle.Impl
{
    public class TriangleManager : ITriangleManager
    {
        #region variables
        private int _sideA;
        private int _sideB;
        private int _sideC;
        #endregion

        #region Properties
        ITraingleUtility _triangleUtility;
        #endregion

        #region Constructors
        public TriangleManager() : this(new TriangleUtility())
        { }

        public TriangleManager(ITraingleUtility triangleUtility)
        {
            _triangleUtility = triangleUtility;
        }
        #endregion

        /// <summary>
        /// Business method to calculate Traingle area
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <returns>Traingle Type</returns>
        public double CalculateTriangleArea(model.Triangle triangle)
        {
            if (triangle != null)
            {
                _sideA = triangle.SideOne;
                _sideB = triangle.SideTwo;
                _sideC = triangle.SideThree;
            }
            double area = 0;

            try
            {
                // Check whether the traingle is valid
                if (isValidTriangle())
                {
                    area = _triangleUtility.CalculateArea(triangle);
                }
                else
                {
                    throw new Exception("InvalidTriangleException");
                }

                return area;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Method to check if all sides of triangle are valid
        /// </summary>
        /// <returns>Valid flag</returns>
        private bool isValidTriangle()
        {
            if (_sideA < 0 || _sideB < 0 || _sideC < 0)
            {
                return false;
            }
            else if (_sideA + _sideB < _sideC)
            {
                return false;
            }
            else if (_sideB + _sideC < _sideA)
            {
                return false;
            }
            else if (_sideA + _sideC < _sideB)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
