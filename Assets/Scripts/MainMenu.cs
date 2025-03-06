using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject modeDropdown; // Referencia al Dropdown
    private string selectedMode = "Easy"; // Modo predeterminado

    private void Start()
    {
        // Asegúrate de que el Dropdown esté oculto al inicio
        if (modeDropdown != null)
        {
            modeDropdown.SetActive(false);
        }
    }

    // Función para comenzar el juego
    public void StartGame()
    {
        // Aquí podrías usar el modo seleccionado para influir en la escena del juego
        Debug.Log($"Iniciando el juego en modo: {selectedMode}");
        SceneManager.LoadScene("Juego");
    }

    // Función para mostrar/ocultar el Dropdown al presionar el botón Select Mode
    public void ToggleModeDropdown()
    {
        if (modeDropdown != null)
        {
            // Alterna la visibilidad del Dropdown
            modeDropdown.SetActive(!modeDropdown.activeSelf);
        }
    }

    // Función para capturar la selección del modo
    public void OnModeSelected(int optionIndex)
    {
        string[] modes = { "Easy", "Medium", "Hard" };
        if (optionIndex >= 0 && optionIndex < modes.Length)
        {
            selectedMode = modes[optionIndex];
            Debug.Log($"Modo seleccionado: {selectedMode}");
        }
    }

    // Función para abrir configuración
    public void OpenSettings()
    {
        Debug.Log("Abrir configuración");
    }

    // Función para salir del juego
    public void ExitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
