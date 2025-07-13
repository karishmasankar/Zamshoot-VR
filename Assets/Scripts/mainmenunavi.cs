using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenunavi : MonoBehaviour
{
    public string sceneToload;
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Test_Map");

    }
}

