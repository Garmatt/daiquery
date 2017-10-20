namespace DaiQuery
{
    public abstract class Constant<T> : Expression, IConstant<T>
    {
        private T value;
        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public Constant(T value)
            : base()
        {
            this.value = value;
        }

        protected override string GetHeader()
        {
            return null;
        }

        internal override abstract Expression GetClone();

        internal override abstract IRenderer GetRenderer();
    }
}
