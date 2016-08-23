﻿using UnityEngine;

public class DismissOnSelect : MonoBehaviour
{
    [Tooltip("Audio clip to play when interacting with this hologram.")]
    public AudioClip TargetFeedbackSound;

    private AudioSource _audioSource;
    private GameObject _audioGameObject;

    public void OnSelect()
    {
        EnableAudioHapticFeedback();

        Destroy(gameObject);
        if (_audioGameObject != null)
        {
            Destroy(_audioGameObject, _audioSource.clip.length);
        }
    }

    private void EnableAudioHapticFeedback()
    {
        // If this hologram has an audio clip, add an AudioSource with this clip.
        if (TargetFeedbackSound != null)
        {
            _audioGameObject = new GameObject();
            _audioGameObject.transform.position = gameObject.transform.position;

            _audioSource = _audioGameObject.GetComponent<AudioSource>();
            if (_audioSource == null)
            {
                _audioSource = _audioGameObject.AddComponent<AudioSource>();
            }

            _audioSource.clip = TargetFeedbackSound;
            _audioSource.playOnAwake = false;
            _audioSource.spatialBlend = 1;
            _audioSource.dopplerLevel = 0;

            _audioSource.Play();
        }
    }
}