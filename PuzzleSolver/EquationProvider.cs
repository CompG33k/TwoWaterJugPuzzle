namespace PuzzleSolver
{
    /// <summary>
    /// Equations 
    /// </summary>
    public class EquationProvider
    {
        #region Methods
        /// <summary>
        ///     Determines whether the coefficients of Bezouts Identity is valid.
        ///     {A}x + {B}y = {C} a is equation valid.
        ///     Ex:
        ///         The two pairs such that |x| <= |b\d| and |y| <= |a\d| 
        ///         (equality may occur only if one of a and b is a multiple of the other).
        ///          
        ///     More info:
        ///     https://en.wikipedia.org/wiki/B%C3%A9zout%27s_identity
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static bool IsBezoutsCoefficientsValid(int a, int b,int c)
        {   
            var d = GreatestCommonDivisor(a, b);
            var number = c/d;
            // The Diophantine equation Ax+By=C is solvable if and only if gcd(A, B) divides C as a integer.
            return IsNumberAnInteger(number);
        }

        /// <summary>
        ///     Greatests the common divisor.
        ///     Return the greatest comon divisor of nonnegative numbers,
        ///     not both 0.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public static double GreatestCommonDivisor(int a, int b)
        {
            return b == 0 ? a : GreatestCommonDivisor(b, a % b);
        }

        private static bool IsNumberAnInteger(double number)
        {
            return number % 1 == 0;
        }
        #endregion
    }
}
