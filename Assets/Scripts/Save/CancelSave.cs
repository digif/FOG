using UnityEngine;

public class CancelSave : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
