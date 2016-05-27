namespace testOverriding
{
    public class ChildClass : BaseClass
    {
        public override string GetStringData()
        {
            return StringData + " modified on reading";
        }

        public override void SetIntData(int value)
        {
            IntData = value;
            IntData += 5;
        }
    }
}