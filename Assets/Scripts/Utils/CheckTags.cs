using UnityEngine;

namespace Utils
{
    public static class CheckTags
    {
        public static bool CompareTagList(GameObject objectToTest, string[] tags)
        {
            for (var i = 0; i < tags.Length; i++)
            {
                var tag = tags[i];
                
                if (objectToTest.CompareTag(tag)) return true;
            }

            return false;
        }
    }
}
