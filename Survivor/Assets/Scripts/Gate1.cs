using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("caca");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("pipi");
            SceneManager.LoadScene("normal_plain");
        }
    }
}
