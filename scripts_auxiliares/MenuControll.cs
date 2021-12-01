using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public int local = 0;
    int maxlocal;
    public RectTransform rt;
    public RectTransform[] AllNavigationsButtons;
    private Vector2 uiOffset;
    Canvas canvas;

    public static Vector2 pixelAjustpoint;

    void Start()
    {
        rt = gameObject.GetComponent<RectTransform>();
        canvas = gameObject.GetComponent<Canvas>();
        maxlocal = AllNavigationsButtons.Length - 1;
        
    }
    void Update()
    {
        print("max: " + maxlocal);
        pixelAjustpoint = RectTransformUtility.PixelAdjustPoint(Vector2.up, rt, canvas);
        print(pixelAjustpoint);

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

        // foreach (RectTransform i in AllNavigationsButtons){
        //     print(i.anchoredPosition);
        // }
        
    }
    void VerifyLocal()
    {
        try
        {
             rt.position = AllNavigationsButtons[local].position + (Vector3.left * 90);
        }
        catch (System.IndexOutOfRangeException)
        {
            throw;
        }
    }
}
