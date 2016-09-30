using UnityEngine;

[RequireComponent(typeof(SoundEffect))]
public class DismissOnSelect : MonoBehaviour
{
    public void OnSelect()
    {
        Destroy(gameObject);

        var sound = GetComponent<SoundEffect>();
        if (sound != null)
        {
            sound.PlaySoundEffect();
        }
    }
}