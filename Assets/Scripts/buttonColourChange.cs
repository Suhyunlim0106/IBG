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

    private Color defaultColor = Color.clear;      // 기본 색상 (투명)
    private Color activeColor;                     // 눌림 색상 (#00D7C4)
    [Range(0f, 1f)] public float activeAlpha = 0.4f; // 눌림색 투명도 (0~1)

    void Start()
    {
        // 태그로 버튼 그룹 자동 할당
        bl = GameObject.FindGameObjectsWithTag("BL");
        br = GameObject.FindGameObjectsWithTag("BR");
        ar = GameObject.FindGameObjectsWithTag("AR");
        al = GameObject.FindGameObjectsWithTag("AL");

        // 눌림 색상 지정 + 투명도 적용
        ColorUtility.TryParseHtmlString("#00D7C4", out activeColor);
        activeColor.a = activeAlpha;

        // 버튼 클릭 리스너 등록
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
        // 그룹 내 버튼 색상 초기화
        foreach (GameObject obj in group)
        {
            Image img = obj.GetComponent<Image>();
            if (img != null)
                img.color = defaultColor;
        }

        // 클릭된 버튼만 눌림 색상 적용
        Image clickedImg = clickedButton.GetComponent<Image>();
        if (clickedImg != null)
            clickedImg.color = activeColor;
    }
}
