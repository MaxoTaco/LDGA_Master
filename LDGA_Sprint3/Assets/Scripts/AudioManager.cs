using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] ad;
    public int i = 0;

    private AudioSource aud;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && i < ad.Length)
        {
            aud.clip = ad[i];
            aud.Play();
            i++;
        }
    }
}
