using System.Collections;
using UnityEngine;

public class RoaryController : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject roarySkate;
    [SerializeField] private GameObject roaryTPose;
    [SerializeField] private ParticleSystem fireworks;

    [Header("Settings")]
    [SerializeField] private float skateAtoBDuration = 3f;
    [SerializeField] private float skateBtoCDuration = 3f;

    private Animator animator;
    private bool canInteract = false;

    void Start()
    {
        animator = roarySkate.GetComponent<Animator>();

        roaryTPose.SetActive(false);
        roarySkate.SetActive(true);

        StartCoroutine(SkateAtoB());
    }

    IEnumerator SkateAtoB()
    {
        Debug.Log("SkateAtoB");
        animator.Play("Roary"); // play A → B animation
        yield return new WaitForSeconds(skateAtoBDuration);

        roarySkate.SetActive(false);
        roaryTPose.SetActive(true);
        canInteract = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!canInteract) return;
        if (!other.CompareTag("Player")) return;

        canInteract = false;
        StartCoroutine(InteractAndSkateBtoC());
    }

    IEnumerator InteractAndSkateBtoC()
    {
        Debug.Log("InteractAndSkateBtoC");
        roaryTPose.SetActive(false);
        fireworks.Play();

        yield return new WaitForSeconds(1f); // fireworks moment

        roarySkate.SetActive(true);
        animator.Play("Roary");
        yield return new WaitForSeconds(skateBtoCDuration);

        roarySkate.SetActive(false);
    }
}