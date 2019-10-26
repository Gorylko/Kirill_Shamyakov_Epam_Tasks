namespace Module.Helper
{
    public struct ArrayInfo<T> where T : struct
    {
        public T MaxElement { get; set; }

        public T MinElement { get; set; }

        public T SumOfAllElements { get; set; }
    }
}
