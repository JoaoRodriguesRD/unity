using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text healthText;
    public static GameController instance;
    public GameObject transition;


    public int coins;
    public int totalCoins;

    public Text coinText;

    public int nextLevel;

    // Awake eh chamado antes de todos os metodos Start
    void Awake()
    {

     transition.SetActive(false);
     instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        /*GameObject GO = GameObject.FindWithTag("CoinText");
        GO.GetComponent<Text>().text = "nada2";
        coinText = GO.GetComponent<Text>();


        GO = GameObject.FindWithTag("healthText");
        GO.GetComponent<Text>().text = "nada1";
        healthText = GO.GetComponent<Text>();
*/



        //totalCoins = PlayerPrefs.GetInt("coins");
        Debug.Log("coins = " + totalCoins);
        coins = PlayerPrefs.GetInt("coin");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void UpdateCoin(int coin)
    {
        coins += coin;
        coinText.text = coins.ToString();

        //salva em um arquivo a quantidade de moedas
        PlayerPrefs.SetInt("coins",coins + totalCoins);
        PlayerPrefs.SetInt("coin", coins);
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x "+value;
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevel(int level)
    {
        StartCoroutine("LoadTransition");
        nextLevel = level;
        


    }

    IEnumerator LoadTransition()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevel);
        
    }
}
