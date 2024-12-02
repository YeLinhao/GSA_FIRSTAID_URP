using UnityEngine;
using System.Collections;
using
UnityEngine.SceneManagement;
public class Levelselector : MonoBehaviour
{
    
    public void Openscene()
    {
        SceneManager.LoadScene(1);
    }
}
