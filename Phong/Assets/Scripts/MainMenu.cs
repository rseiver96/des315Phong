using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }

    public void Quit()
    {
    }
    

}
