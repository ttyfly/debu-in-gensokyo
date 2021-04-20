using System;

namespace DebuInGensokyo.Utility
{
    class AttributeHelper
    {
        public static T Get<T>(Type targetObjectType)
        {
            return (T)targetObjectType.GetCustomAttributes(typeof(T), true).GetValue(0);
        }
    }
}