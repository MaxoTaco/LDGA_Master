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
        
        if (ad.Length > 0)
        {
            aud.clip = ad[i];
            aud.Play(); 
        }
    }    
        

    // Update is called once per frame
    void Update()
    {
        //I will add more when we have musics done-Tony
    }
}
