namespace JdiSampleSite.Common.Library.Data
{
    using System.Collections.Generic;
    using Models.Abstract;

    public class GroupsCollection
    {
        public static List<IGroup> Groups { get; private set; }

        public static void AddGroup(IGroup group)
        {
            Init();
            Groups.Add(group);
        }

        public static void Clear()
        {
            Init();
            Groups.Clear();
        }
        
        public static void Init()
        {
            if (null != Groups)
                return;
            Groups= new List<IGroup>();
        }
    }
}