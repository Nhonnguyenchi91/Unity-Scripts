using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Graphic_Raycaster_Example : MonoBehaviour //Để sử dụng thì script này phải được add vào Canvas
{
    GraphicRaycaster m_Raycaster; // Khởi tạo biến m_Raycaster là một GraphicRaycaster của Canvas
    PointerEventData m_PointerEventData; // Khởi tạo biến m_PointerEventData là event từ con trỏ pointer (mouse/touch)
    EventSystem m_EventSystem; // Khởi tạo biến m_EventSystem thuộc EventSystem

    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>(); // Gán Component GraphicRaycaster của Canvas vào biến m_Raycaster
        m_EventSystem = GetComponent<EventSystem>(); // Gán Component EventSystem vào biến m_EventSystem
    }

    void Update()
    {
        // Kiểm tra nếu Con trỏ pointer đang ở trên một GameObject
        if (EventSystem.current.IsPointerOverGameObject())
        {
            m_PointerEventData = new PointerEventData(m_EventSystem); // Khởi tạo một Pointer Event mới
            m_PointerEventData.position = Input.mousePosition; // Đặt vị trí của Pointer Event là vị trí của con trỏ
            List<RaycastResult> results = new List<RaycastResult>(); //Tạo một list RatcastResult để lưu các kết quả Raycast
            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results); // Tiến hành Raycast tại vị trí của con trỏ và lưu kết quả trả về vào list RaycastResult
            //Với các kết quả trong list RaycastResult ta sẽ in ra tên các GameObject mà phép Raycast đã phát hiện ra.
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name); // Log ra tên Game Object mà phép Raycast đã phát hiện ra
            }
        }
    }
}
