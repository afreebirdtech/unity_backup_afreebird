using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    [SerializeField] private string loadLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}