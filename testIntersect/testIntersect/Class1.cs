namespace testIntersect
{
    using System.Collections.Generic;

    class MyClass
    {
        public string MyString1;
        public string MyString2;
        public string MyString3;
    }

    class MyEqualityComparer : IEqualityComparer<MyClass>
    {
        public bool Equals(MyClass item1, MyClass item2)
        {
            if (item1 == null && item2 == null)
                return true;
            else if ((item1 != null && item2 == null) ||
                    (item1 == null && item2 != null))
                return false;

            return item1.MyString1.Equals(item2.MyString1) &&
                   item1.MyString2.Equals(item2.MyString2);
        }

        public int GetHashCode(MyClass item)
        {
            return new { item.MyString1, item.MyString2 }.GetHashCode();
        }
    }
}