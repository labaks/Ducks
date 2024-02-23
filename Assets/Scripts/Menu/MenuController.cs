using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MainPanel, ProfilePanel, DucksPanel;
    void Start()
    {
        MainPanel.SetActive(true);
        ProfilePanel.SetActive(false);
        DucksPanel.SetActive(false);        
    }

    /*Main menu*/
    public void StartGame() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void onProfileBtnClick() {
        MainPanel.SetActive(false);
        ProfilePanel.SetActive(true);
    }

    /*Profile menu*/
    public void onBackFromProfileBtnClick() {
        MainPanel.SetActive(true);
        ProfilePanel.SetActive(false);
    }
    public void onDucksBtnClick() {
        ProfilePanel.SetActive(false);
        DucksPanel.SetActive(true);
    }
    public void onCollectionBtnClick() {
    }
    public void onAchievementsBtnClick() {
    }

    /*Ducks Menu*/
    public void onBackFromDucksBtnClick() {
        ProfilePanel.SetActive(true);
        DucksPanel.SetActive(false);
    }


}
