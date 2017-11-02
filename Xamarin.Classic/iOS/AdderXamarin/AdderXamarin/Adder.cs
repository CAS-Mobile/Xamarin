namespace AdderXamarin
{
    /// <summary>
    /// add two numbers
    /// </summary>
    public class Adder
    {

        /// <summary>
        /// adds the given numbers
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <returns>the sum ot the two numbers</returns>
        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// adds the given numbers (slightly less verbose version
        /// using C# lambdas)
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <returns>the sum ot the two numbers</returns>
        public int AddTwoNumbers_LambdaVersion(int number1, int number2) => number1 + number2;
    }
}
