using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberText : MonoBehaviour
{
    public AudioSource joao1;
    public AudioSource joao2;
    public AudioSource joao3;
    public AudioSource joao4;
    public AudioSource joao5;
    public AudioSource joao6;
    public AudioSource joao7;
    public AudioSource joao8;
    public AudioSource joao9;
    public AudioSource joao10;
    public AudioSource joao11;
    public AudioSource joao12;
    private Text t;
    public int count;
    public int win;
    public bool muted;
    // Start is called before the first frame update
    void Start()
    {

        t = GetComponent<Text>();
        count = 1000000;
        count = PlayerPrefs.GetInt("game",count);
        win = 0;
        win = PlayerPrefs.GetInt("win",win);

        muted = false;

        if(count <= 0){
            win++;
            PlayerPrefs.SetInt("win",win);
            count = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "" + count;
        if(count <= 0){
            t.text = "fim! " + win;
        }
    }

    public void remove(){
        count--;
        PlayerPrefs.SetInt("game",count);

        if(!muted){
            play_sound();
        }
          
    }

    public void play_sound(){
        int r = Random.Range(1,12);
        switch (r){
        case 1:
        joao1.Play();
            break;            
        case 2:
        joao2.Play();
            break;
        case 3:
        joao3.Play();
            break;
        case 4:
        joao4.Play();
            break;
        case 5:
        joao5.Play();
            break;
        case 6:
        joao6.Play();
            break;            
        case 7:
        joao7.Play();
            break;            
        case 8:
        joao8.Play();
            break;
        case 9:
        joao9.Play();
            break;
        case 10:
        joao10.Play();
            break;
        case 11:
        joao11.Play();
            break;
        case 12:
        joao12.Play();
            break;
        default:
        joao1.Play();
            break;
        }
    }

    public void toMute(){
        if(muted){
            muted = false;
        }else{
            muted = true;
        }
    }
}
