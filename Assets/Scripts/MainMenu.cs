using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject modeDropdown; // Referencia al Dropdown
    private string selectedMode = "Easy"; // Modo predeterminado

    private void Start()
    {
        // Aseg�rate de que el Dropdown est� oculto al inicio
        if (modeDropdown != null)
        {
            modeDropdown.SetActive(false);
        }
    }

    // Funci�n para comenzar el juego
    public void StartGame()
    {
        // Aqu� podr�as usar el modo seleccionado para influir en la escena del juego
        Debug.Log($"Iniciando el juego en modo: {selectedMode}");
        SceneManager.LoadScene("Juego");
    }

    // Funci�n para mostrar/ocultar el Dropdown al presionar el bot�n Select Mode
    public void ToggleModeDropdown()
    {
        if (modeDropdown != null)
        {
            // Alterna la visibilidad del Dropdown
            modeDropdown.SetActive(!modeDropdown.activeSelf);
        }
    }

    // Funci�n para capturar la selecci�n del modo
    public void OnModeSelected(int optionIndex)
    {
        string[] modes = { "Easy", "Medium", "Hard" };
        if (optionIndex >= 0 && optionIndex < modes.Length)
        {
            selectedMode = modes[optionIndex];
            Debug.Log($"Modo seleccionado: {selectedMode}");
        }
    }

    // Funci�n para abrir configuraci�n
    public void OpenSettings()
    {
        Debug.Log("Abrir configuraci�n");
    }

    // Funci�n para salir del juego
    public void ExitGame()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
