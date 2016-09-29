using UnityEngine;

[RequireComponent(typeof(SoundEffect))]
public class BillboardDelete : MonoBehaviour
{
    public void Delete()
    {
        TagAlong tagAlong = FindObjectOfType<TagAlong>();
        if (tagAlong == null)
            return;

        Destroy(tagAlong.StickyNote);
        Destroy(tagAlong.gameObject);

        var sound = GetComponent<SoundEffect>();
        if (sound != null)
        {
            sound.PlaySoundEffect();
        }
    }
}
