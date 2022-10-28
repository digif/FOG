using UnityEngine;

namespace Save
{
    public class PositionSaver : ISaver
    {
        public string SpecificName => specificName;
        
        public override void Save()
        {
            SaveManager.Save($"{name}_{specificName}", JsonUtility.ToJson(transform.position));
        }

        public override void Load()
        {
            var positionString = SaveManager.Load($"{name}_{specificName}");
            print(positionString);
            transform.position = JsonUtility.FromJson<Vector3>(positionString);
        }
    }
}
