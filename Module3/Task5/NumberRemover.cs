namespace Task5
{
    public static class NumberRemover
    {
        public static int RemoveNumber(this int number, int numberToDelete)
        {
            var strNumber = number.ToString();

            strNumber = strNumber.Replace(numberToDelete.ToString(), "");

            if(strNumber == "")
            {
                return 0;
            }

            return int.Parse(strNumber);
        }
    }
}
