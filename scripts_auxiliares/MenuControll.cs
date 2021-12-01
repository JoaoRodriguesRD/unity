using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public int local = 0;
    int maxlocal;
    public RectTransform rectTransform;
    public RectTransform[] AllNavigationsButtons;
    Canvas canvas;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        maxlocal = AllNavigationsButtons.Length - 1;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            local--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            local++;
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
}
