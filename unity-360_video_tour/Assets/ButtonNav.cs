using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNav : MonoBehaviour
{
    public string targetSceneName;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    StartCoroutine(ChangeSceneWithFade(targetSceneName));
                }
            }
        }
    }

    private IEnumerator ChangeSceneWithFade(string sceneName)
    {
        FadeController fadeController = FindObjectOfType<FadeController>();
        if (fadeController != null)
        {
            yield return StartCoroutine(fadeController.FadeOut());
        }

        SceneManager.LoadScene(sceneName);

        if (fadeController != null)
        {
            yield return StartCoroutine(fadeController.FadeIn());
        }
    }
}