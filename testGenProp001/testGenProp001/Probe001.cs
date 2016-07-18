namespace testGenProp001
{
    using System.Collections.Generic;

    public class Probe001 : IProbe001
    {
        //List<T> _list;

        ////public void SetMethod<T>()
        ////{
            
        ////}

        //public void set_MyProperty03<T>(List<T> list)
        //{
        //    // throw new System.NotImplementedException();
        //    _list = list;
        //}

        //public List<T> get_MyProperty03<T>()
        //{
        //    // throw new System.NotImplementedException();
        //    return _list;
        //}
        public Holder Holder { get; set; }

        public Probe001()
        {
            Holder = new Holder();
        }
    }
}