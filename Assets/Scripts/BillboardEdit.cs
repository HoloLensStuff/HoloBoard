using UnityEngine;

public class BillboardEdit : MonoBehaviour
{
    public void OnSelect()
    {
        TagAlong tagAlong = FindObjectOfType<TagAlong>();
        if (tagAlong == null)
            return;
    }
}
