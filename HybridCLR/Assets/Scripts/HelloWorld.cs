using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    void Update()
    {
        if (Time.frameCount % 120 == 0)
        {
            Debug.Log("Hotfix Success");
        }
    }
}
