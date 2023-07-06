using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;

    Slider bossHp;
    private void Awake()
    {
        bossHp = FindObjectOfType<Slider>();
        bossHp.gameObject.SetActive(false);
        pauseCanvas.SetActive(false);
    }
    public void BosssHPOn()
    {
        if (bossHp != null)
        {
            bossHp.gameObject.SetActive(true);
        }
    }
    public void BosssHPOff()
    {
        if (bossHp != null)
        {
            bossHp.gameObject.SetActive(false);
        }
    }
    public void SetBossHPValue(float percentage)
    {
        bossHp.value = percentage;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Continue()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu");
    }
}
