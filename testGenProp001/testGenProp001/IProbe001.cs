namespace testGenProp001
{
    using System.Collections.Generic;
    using System.Linq;

    public interface IProbe001
    {
        //// T MyProperty01<T> { get; set; }
        //// void SetMethod<T>();
        //// List<T> MyProperty02 { get; set; }
        //void set_MyProperty03<T>(List<T> list);
        //List<T> get_MyProperty03<T>();
        Holder Holder { get; set; }
    }

    public class Holder
    {
        static List<object> _list;

        //private Holder() { }

        //public static Holder GetInstance()
        //{
        //    _list = new List<object>();
        //    return new Holder();
        //}

        public Holder()
        {
            _list = new List<object>();
        }

        public static void Set<T>(List<T> list)
        {
            _list.AddRange(list.Cast<object>());
        }

        public static List<T> Get<T>()
        {
            return _list.Cast<T>().ToList();
        }
    }
}