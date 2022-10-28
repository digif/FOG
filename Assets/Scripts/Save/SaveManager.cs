using UnityEngine;

namespace Save
{
    public static class SaveManager
    {
        /// <summary>
        /// Will be append to the start of the save name of all items
        /// </summary>
        public static string currentSaveName = string.Empty;

        public static void Save(string saveName, string saveValue)
        {
            PlayerPrefs.SetString($"{currentSaveName}_{saveName}", saveValue);
        }
        
        public static void Save(string saveName, int saveValue)
        {
            
            PlayerPrefs.SetInt($"{currentSaveName}_{saveName}", saveValue);
        }
        
        public static void Save(string saveName, float saveValue)
        {
            
            PlayerPrefs.SetFloat($"{currentSaveName}_{saveName}", saveValue);
        }

        public static string Load(string saveName)
        {
            return PlayerPrefs.GetString($"{currentSaveName}_{saveName}");
        }
        
        public static int LoadInt(string saveName)
        {
            return PlayerPrefs.GetInt($"{currentSaveName}_{saveName}");
        }
        
        public static float LoadFloat(string saveName)
        {
            return PlayerPrefs.GetFloat($"{currentSaveName}_{saveName}");
        }
    }
}
