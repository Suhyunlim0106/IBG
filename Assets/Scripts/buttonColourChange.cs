using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonColourChange : MonoBehaviour
{
    [SerializeField] GameObject[] bl;
    [SerializeField] GameObject[] br;
    [SerializeField] GameObject[] ar;
    [SerializeField] GameObject[] al;

    private Color defaultColor = Color.clear;      // �⺻ ���� (����)
    private Color activeColor;                     // ���� ���� (#00D7C4)
    [Range(0f, 1f)] public float activeAlpha = 0.4f; // ������ ���� (0~1)

    void Start()
    {
        // �±׷� ��ư �׷� �ڵ� �Ҵ�
        bl = GameObject.FindGameObjectsWithTag("BL");
        br = GameObject.FindGameObjectsWithTag("BR");
        ar = GameObject.FindGameObjectsWithTag("AR");
        al = GameObject.FindGameObjectsWithTag("AL");

        // ���� ���� ���� + ���� ����
        ColorUtility.TryParseHtmlString("#00D7C4", out activeColor);
        activeColor.a = activeAlpha;

        // ��ư Ŭ�� ������ ���
        AddButtonListeners(bl);
        AddButtonListeners(br);
        AddButtonListeners(ar);
        AddButtonListeners(al);
    }

    void AddButtonListeners(GameObject[] buttonGroup)
    {
        foreach (GameObject obj in buttonGroup)
        {
            Button btn = obj.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(() => OnButtonClicked(obj, buttonGroup));
            }
        }
    }

    void OnButtonClicked(GameObject clickedButton, GameObject[] group)
    {
        // �׷� �� ��ư ���� �ʱ�ȭ
        foreach (GameObject obj in group)
        {
            Image img = obj.GetComponent<Image>();
            if (img != null)
                img.color = defaultColor;
        }

        // Ŭ���� ��ư�� ���� ���� ����
        Image clickedImg = clickedButton.GetComponent<Image>();
        if (clickedImg != null)
            clickedImg.color = activeColor;
    }
}
