using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public TMP_Dropdown dificultad;
    // Función para cargar la escena del menú
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void setDificultad()
    {
        GameManager.Instance.setDificultad(dificultad.value);
    }

}
