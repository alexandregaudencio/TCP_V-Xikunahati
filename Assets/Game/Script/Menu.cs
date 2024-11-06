using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    public void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadSceneAsync(1);

        }


    }



}
