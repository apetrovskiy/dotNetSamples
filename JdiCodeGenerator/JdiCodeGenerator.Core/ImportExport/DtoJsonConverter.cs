//namespace JdiCodeGenerator.Core.ImportExport
//{
//    using System;
//    using Newtonsoft.Json;
//    using ObjectModel;
//    using ObjectModel.Abstract;

//    public class DtoJsonConverter : JsonConverter
//    {
//        private static readonly string ISCALAR_FULLNAME = typeof(ILocatorDefinition).FullName;


//        public override bool CanConvert(Type objectType)
//        {
//            if (objectType.FullName == ISCALAR_FULLNAME)
//            {
//                return true;
//            }
//            return false;
//        }

//        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
//            JsonSerializer serializer)
//        {
//            if (objectType.FullName == ISCALAR_FULLNAME)
//                return serializer.Deserialize(reader, typeof(LocatorDefinition));

//            throw new NotSupportedException(string.Format("Type {0} unexpected.", objectType));
//        }

//        public override void WriteJson(JsonWriter writer, object value,
//            JsonSerializer serializer)
//        {
//            serializer.Serialize(writer, value);
//        }
//    }
//}
