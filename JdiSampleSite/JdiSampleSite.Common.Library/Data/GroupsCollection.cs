﻿namespace JdiSampleSite.Common.Library.Data
{
    using System.Collections.Generic;
    using Models.Abstract;

    public class GroupsCollection
    {
        public static List<IGroup> Groups { get; private set; } = new List<IGroup>();

        public static void AddGroup(IGroup group)
        {
            Groups.Add(group);
        }

        public static void Clear()
        {
            Groups.Clear();
        }
    }
}