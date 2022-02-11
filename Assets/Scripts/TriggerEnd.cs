using TMPro;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public GameObject buttonGameOver, buttonShet;
    public TextMeshProUGUI schet, itogSchet, namePlayer;
    public int steps, itog;
    private SavePlayer savePlayer;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        savePlayer = FindObjectOfType<SavePlayer>();
    }
    public void Steps()
    { steps = 0; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { Dead(); }

        if (other.gameObject.tag == "Ladders")
        { schet.text = $"Ступенек пройдено {steps++}"; }
    }
    public void Dead()
    {
        buttonGameOver.SetActive(true);
        buttonShet.SetActive(false);
        itog = steps;
        itogSchet.text = $"{namePlayer.text} вами \n Ступенек пройдено {itog}";
        savePlayer.Schet(itog);
        audioSource.Play();
    }
}