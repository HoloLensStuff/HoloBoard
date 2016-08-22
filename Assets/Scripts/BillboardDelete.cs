using UnityEngine;

public class BillboardDelete : MonoBehaviour
{
    public void Delete()
    {
        TagAlong tagAlong = FindObjectOfType<TagAlong>();
        if (tagAlong == null)
            return;

        Destroy(tagAlong.StickyNote);
        Destroy(tagAlong.gameObject);
    }
}
