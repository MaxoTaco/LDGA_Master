using UnityEngine;

public class KeyBehavior : Interactable
{
    public AudioClip keyPickup;

    public override void Use()
    {
        AudioSource.PlayClipAtPoint(keyPickup, transform.position);

        LevelManager.Instance.collectedKey = true;

        Destroy(this.gameObject);

        Debug.Log("Collected Key.");
    }
}
