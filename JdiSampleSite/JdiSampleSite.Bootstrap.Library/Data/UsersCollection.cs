namespace JdiSampleSite.Bootstrap.Library.Data
{
    using System.Collections.Generic;
    using Models.Abstract;

    public class UsersCollection
    {
        public static List<IUser> Users { get; private set; } = new List<IUser>();

        public static void AddUser(IUser user)
        {
            Users.Add(user);
        }
    }
}