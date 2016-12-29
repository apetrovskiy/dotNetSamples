namespace Maths
{
    public static class Calculator
    {
        public static long Add(this long operandOne, long operandTwo)
        {
            return operandOne + operandTwo;
        }

        public static long Substract(this long operandOne, long operandTwo)
        {
            return operandOne - operandTwo;
        }

        public static float DivideBy(this long operandOne, long operandTwo)
        {
            return operandOne / operandTwo;
        }
    }
}
