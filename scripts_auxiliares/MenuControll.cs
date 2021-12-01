using UnityEngine;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    public int local = 0;
    int maxlocal;
    public RectTransform rectTransform;
    public RectTransform[] AllNavigationsButtons;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        maxlocal = AllNavigationsButtons.Length - 1;

        foreach (var item in AllNavigationsButtons)
        {
            item.gameObject.GetComponent<Button>().onClick.AddListener(delegate { ExampleFunction(item.name); });
        }

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            local--;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            local++;
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            
            AllNavigationsButtons[local].gameObject.GetComponent<Button>().onClick.Invoke();
        }

        if (local > maxlocal)
        {
            local = 0;
        }
        if (local < 0)
        {
            local = maxlocal;
        }

        VerifyLocal();
        
    }

    void VerifyLocal()
    {
        try
        {
             rectTransform.position = AllNavigationsButtons[local].position + (Vector3.left * 90);
             
        }
        catch (System.IndexOutOfRangeException)
        {
            throw;
        }
    }

    public void ExampleFunction(string button){
        Debug.Log("click event on: " + button);
    }
}
