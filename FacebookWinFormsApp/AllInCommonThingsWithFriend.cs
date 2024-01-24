using CefSharp.DevTools.Fetch;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace BasicFacebookFeatures
{
    public class AllInCommonThingsWithFriend
    {
        public List<Group> CommonGroups {get; set;}
        public List<Event> CommoEvents { get; set; }
        public List<Page> CommonPages { get; set; }
        public List<User> CommonFriends { get; set; }

        public AllInCommonThingsWithFriend(User i_LoggedInUser, User i_OtherUser)
        {
            fetchDetailsInCommon<Group>(i_LoggedInUser.Groups, i_OtherUser.Groups, CommonGroups);
            fetchDetailsInCommon<Event>(i_LoggedInUser.Events, i_OtherUser.Events, CommoEvents);
            fetchDetailsInCommon<Page>(i_LoggedInUser.LikedPages, i_OtherUser.LikedPages, CommonPages);
            fetchDetailsInCommon<User>(i_LoggedInUser.Friends, i_OtherUser.Friends, CommonFriends);
        }

        private void fetchDetailsInCommon<T>(
            FacebookObjectCollection<T> i_LoggedInUserCollection, 
            FacebookObjectCollection<T> i_OtherUserCollection, 
            List<T> i_CommonList)
        {
            PropertyInfo nameProperty = typeof(T).GetProperty("Name");
            string name = null;
            i_CommonList = new List<T>();

            foreach (T item in i_LoggedInUserCollection)
            {
                if (i_OtherUserCollection.Contains(item))
                {
                    name = nameProperty.GetValue(item) is string ?
                        nameProperty.GetValue(item) as string :
                        NoNameForItem<T>();
                    i_CommonList.Add(item);
                }
            }
        }

        public string NoNameForItem<T>()
        {
            return $"No {typeof(T).Name}s to show";
        }
    }
}