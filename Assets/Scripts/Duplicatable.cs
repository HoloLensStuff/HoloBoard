using UnityEngine;

public class Duplicatable : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    public void Duplicate()
    {
        var clone = Instantiate(
            gameObject,
            gameObject.transform.position,
            gameObject.transform.rotation) as GameObject;
        clone.transform.SetParent(gameObject.transform.parent);
    }
}
