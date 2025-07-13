using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerButtonHandler : MonoBehaviour
{
    public string sceneToload;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level_1");

    }
}
   
