using UnityEngine;

public class Destroy : MonoBehaviour
{
    private TriggerEnd triggerEnd;
    private AudioSource audioSource;
    private void Start()
    {
        triggerEnd = FindObjectOfType<TriggerEnd>();
        audioSource = GetComponent<AudioSource>(); }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        { Destroy(this.gameObject); }
    }
    private void OnCollisionEnter(Collision collis)
    {
        if (collis.gameObject.tag == "Player")
        {
            audioSource.Play();
            if (this.gameObject.name == "EnemyDead(Clone)")
            { triggerEnd.Dead(); }
        }
    }
}