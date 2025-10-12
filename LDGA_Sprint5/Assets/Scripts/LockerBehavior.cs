using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LockerBehavior : Interactable
{
    AudioSource audioSource;
    bool isOpened = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Use()
    {
        if (LevelManager.Instance.collectedKey && !isOpened)
        {
            isOpened = true;
            audioSource.Play();
            Debug.Log("Opened safety deposit locker.");
        }
        else Debug.Log("Locked.");

    }
}
