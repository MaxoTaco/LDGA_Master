using UnityEngine;
using UnityEngine.UI;

public class Interacting : MonoBehaviour
{
    public float interactRange = 3f;
    public Color highlightColor = Color.grey;
    public Image reticle;
    public float reticleAnimationSpeed = 20f;
    public float reticleScaleFactor = 1.5f;
    private GameObject currentTarget;
    private Color originalColor;
    private Renderer targetRenderer;

    public AudioClip clip;
    private AudioSource audioSource;

    Color initialReticleColor;
    Vector3 initialReticleScale;
    Vector3 targetReticleScale;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        initialReticleColor = reticle.color;
        initialReticleScale = reticle.transform.localScale;

        targetReticleScale = initialReticleScale * reticleScaleFactor;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactRange))
        {
            GameObject hitObject = hit.collider.gameObject;
            //Debug.Log(hitObject.name);
            if (hitObject.CompareTag("Interactable")) //including deletable just in case it's being used. Should be depreciated though.
            {
                ModifyReticle();

                if (currentTarget != hitObject)
                {
                    ClearHighlight();
                    currentTarget = hitObject;
                    /*targetRenderer = currentTarget.GetComponent<Renderer>();
                    if (targetRenderer)
                    {
                        originalColor = targetRenderer.material.GetColor("_EMISSION_COLOR");
                        targetRenderer.material.SetColor("_EMISSION_COLOR", highlightColor);

                    }*/
                }
                if (Input.GetMouseButtonDown(0))
                {
                    currentTarget.GetComponent<Interactable>().Use();
                    currentTarget = null;

                    /*Debug.Log(currentTarget.name + " deleted!");
                    if (clip != null && audioSource != null)
                        audioSource.PlayOneShot(clip, 0.5f);

                    TextTrigger textTrigger = currentTarget.GetComponent<TextTrigger>();
                    if (textTrigger == null)
                    {
                        Destroy(currentTarget);
                        currentTarget = null;
                    }
                    
                    textTrigger.TryLoad();*/ 
                }
            }
            else
            {
                ClearHighlight();
                RevertReticle();
            }
        }
        else
        {
            ClearHighlight();
            RevertReticle();
        }
    }

    void ClearHighlight()
    {
        if (currentTarget && targetRenderer)
        {
            targetRenderer.material.SetColor("_EMISSION_COLOR", originalColor);
        }

        currentTarget = null;
        targetRenderer = null;
    }

    void ModifyReticle()
    {
        reticle.color = Color.Lerp(reticle.color, Color.white, reticleAnimationSpeed * Time.deltaTime);
        reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, targetReticleScale, reticleAnimationSpeed * Time.deltaTime);
    }

    void RevertReticle()
    {
        reticle.color = Color.Lerp(reticle.color, initialReticleColor, reticleAnimationSpeed * Time.deltaTime);
        reticle.transform.localScale = Vector3.Lerp(reticle.transform.localScale, initialReticleScale, reticleAnimationSpeed * Time.deltaTime);
    }
}
