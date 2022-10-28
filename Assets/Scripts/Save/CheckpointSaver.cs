using UnityEngine;

namespace Save
{
   public class CheckpointSaver : TriggerSave
   {
      [SerializeField] private Transform checkpoint;
   
      private void OnTriggerEnter2D(Collider2D other)
      {
         for (var i = 0; i < tagToTriggerWith.Length; i++)
         {
            if (!other.CompareTag("Player")) continue;

            var positionSaver = other.GetComponent<PositionSaver>();

            if (positionSaver == null)
            {
               Debug.LogError("No position saver on the component. Should not happen!");
               continue;
            }
            
            SaveManager.Save($"{positionSaver.name}_{positionSaver.SpecificName}", JsonUtility.ToJson(checkpoint.position));
            return;
         }
      }
   }
}
