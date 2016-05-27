namespace testOverriding
{
    public class BaseClass
    {
        public virtual string StringData { get; set; }
        public virtual int IntData { get; set; }

        public virtual int GetIntData()
        {
            return IntData;
        }

        public virtual string GetStringData()
        {
            return StringData;
        }

        public virtual void SetIntData(int value)
        {
            IntData = value;
        }

        public virtual void SetStringData(string value)
        {
            StringData = value;
        }
    }
}