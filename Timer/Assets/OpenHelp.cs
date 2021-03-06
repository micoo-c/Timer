using UnityEngine.UI;
using UnityEngine;

public class OpenHelp : MonoBehaviour
{
    public Button HelpButton, CloseButton;
    public GameObject HelpMenu;
    public GameObject MainUI; 

    // Start is called before the first frame update
    void Start()
    {
        HelpButton.onClick.AddListener(Help);
        CloseButton.onClick.AddListener(CloseHelp);
    }

    void Help()
    {
        MainUI.SetActive(false);
        HelpMenu.SetActive(true);
    }

    void CloseHelp()
    { 
        HelpMenu.SetActive(false);
        MainUI.SetActive(true);

    }
}
