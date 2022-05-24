
namespace CRMApplication.Commons
{
    public class Helper
    {
        /// <summary>
        /// Check validate string is Number
        /// </summary>
        /// <param name="input">Chuoi string</param>
        /// <returns></returns>
        public static bool IsNumber(string input)
        {
            if (input == "") return true;
            int myDec;
            return int.TryParse(input, out myDec);
        }
    }
}
