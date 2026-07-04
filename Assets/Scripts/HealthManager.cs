
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public int lives = 3;

    private void Awake()
    {
        Instance = this;
    }

    public void LoseLife()
    {
        lives--;

        Debug.Log("Lives Left: " + lives);

        if (lives <= 0)
        {
            FindFirstObjectByType<GameOverManager>().ShowGameOver();
        }
    }
}