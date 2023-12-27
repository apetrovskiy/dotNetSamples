

namespace Otus.Serializer;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
    public class Foo
    {
        public Foo(int a,int b){
        A=a;
        B=b;}
        public int A {get;set;}
        [NonSerialized]
        public int? B;

        public override string ToString() {
return $"{{ A: {A}, B: {B}}}";
        }
    }

    public class Bar:Foo {
        public Bar(int a, int b) : base(a,b){}
    }

public class AttributeDemo {
    
}