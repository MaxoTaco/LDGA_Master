using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class textTrigger : MonoBehaviour
{
    public string text;
    public float timeBet = 0.5f;
    public float duration;
    private Image img;
    private TextMeshProUGUI m_TextMeshPro;
    int index;


    private void Start()
    {
        img = GameObject.FindGameObjectWithTag("Panel").GetComponent<Image>();
        m_TextMeshPro = img.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Collision Detected");
            StartCoroutine(Load());
        }
    }

    IEnumerator Load()
    {
        Debug.Log("IEnumerator started");
        for(int i = 0; i < text.Length; i++)
        {
            m_TextMeshPro.text += text[i];
            yield return new WaitForSeconds(timeBet);
        }
        

        yield return new WaitForSeconds(duration);
        StartCoroutine(Unload());
    }

    IEnumerator Unload()
    {
        Debug.Log("Unload started");
        while (m_TextMeshPro.text.Length > 0)
        {
            m_TextMeshPro.text = m_TextMeshPro.text.Substring(0, m_TextMeshPro.text.Length - 1);
            yield return new WaitForSeconds(timeBet);
        }
    }

}
