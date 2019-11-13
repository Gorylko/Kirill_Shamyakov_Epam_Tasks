namespace Module.Helper
{
    public struct ArrayInfo<T> where T : struct
    {
        public T MaxElement { get; set; }

        public T MinElement { get; set; }

        public T SumOfAllElements { get; set; }

        public override string ToString()
        {
            return $"Max element : {this.MaxElement}" + "\n" +
                $"Min element : {this.MinElement}" + "\n" +
                $"Sum of all elements : {this.SumOfAllElements}" + "\n";
        }
    }
}
