namespace JdiSampleSite.Common.Library.Data
{
    using System.Collections.Generic;
    using Models.Abstract;

    public class UsersCollection
    // public static class UsersCollection
    {
        public static List<IUser> Users { get; private set; }

        public static void AddUser(IUser user)
        {
            Init();
            Users.Add(user);
        }

        public static void Clear()
        {
            Init();
            Users.Clear();
        }
        
        public static void Init()
        {
            if (null != Users)
                return;
            Users = new List<IUser>();
        }
    }
}