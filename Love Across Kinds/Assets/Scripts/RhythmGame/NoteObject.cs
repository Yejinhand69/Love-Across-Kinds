using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public void DeactivateNote()
    {
        // Deactivate the Note object
        gameObject.SetActive(false);
    }
}
