using UnityEngine;
using System.Collections;

public class Duplicatable : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    public void Duplicate()
    {
        var clone = Instantiate(this.gameObject, gameObject.transform.parent.position, new Quaternion(0, 0, 0, 1)) as GameObject;
        clone.transform.SetParent(gameObject.transform.parent);
    }
}
