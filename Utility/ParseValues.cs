
namespace Utility
{
    public static class ParseValues
    {
        public static bool ParseFromStringToInt(string valueAsString, out int valueAsInt)
        {
            bool isParseSuccessful = int.TryParse(valueAsString, out valueAsInt);

            return isParseSuccessful;
        }

        public static bool ParseFromStringToDouble(string valueAsString, out double valueAsDouble)
        {
            return double.TryParse(valueAsString, out valueAsDouble);
        }
    }
}