using UnityEngine;

namespace Save
{
    public class PositionSaver : ISaver
    {
        public override void Save()
        {
            SaveManager.Save($"{name}_{specificName}", JsonUtility.ToJson(transform.position));
        }

        public override void Load()
        {
            SaveManager.Load($"{name}_{specificName}");
        }
    }
}
