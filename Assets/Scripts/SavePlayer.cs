using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SavePlayer : MonoBehaviour
{
    public GameObject inputPanel;
    public Button newGame;
    public TMP_InputField textName;
    public TextMeshProUGUI allText;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Name")) inputPanel.SetActive(true);
        else
        {
            newGame.interactable = true;
            textName.text = PlayerPrefs.GetString("Name");
        }

        if (PlayerPrefs.HasKey("AllText"))
            { allText.text = PlayerPrefs.GetString("AllText"); }
    }
    public void CheckName(string name)
    { 
        if (!string.IsNullOrEmpty(name) && name.Length >= 3)
        { PlayerPrefs.SetString("Name", name); }
    }
    public void Schet(int itog)
    {
        PlayerPrefs.SetInt("Schet", itog);
        allText.text += $"\n {PlayerPrefs.GetString("Name")}, {PlayerPrefs.GetInt("Schet") }";
        PlayerPrefs.SetString("AllText", allText.text);
    }
}