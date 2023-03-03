using UnityEngine;

namespace ILRuntimeTest.Model
{
    public class HelloWorld : MonoBehaviour
    {
        private void Start()
        {
            InvokeRepeating(nameof(SpeakHelloWorld), 0, 1);
        }

        private void SpeakHelloWorld()
        {
            Debug.Log("HelloWorld");
        }
    }
}
