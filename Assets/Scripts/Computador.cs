using UnityEngine;

public class Computador : MonoBehaviour
{

    [SerializeField] private float consoleHealth = 100f;

    public static bool hitConsole = true;
    public static string console = "Console";

    public void TakeDamage(int damage)
    {
        consoleHealth -= damage;

        if (consoleHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Game over.");
        }
    }
}
