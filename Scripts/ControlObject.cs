using UnityEngine;
using UnityEngine.EventSystems;
// Script này giúp ta xử lí việc kéo các game object di chuyển theo pointer (touch/mouse) sử dụng EventSystems
// Với việc áp dụng các hàm pointer, script này sẽ áp dụng cho đa nền tảng mà không cần viết thêm scripts xử lí cho từng nền tảng
public class ControlObject : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public bool isOnCanvas; // xác định xem Object này có thuộc Canvas không

    private Vector3 offset; // offset là tọa độ của object lúc ta chưa kéo đi

    // Hàm xử lí khi ta nhấn vào Game Object
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 pointerPosition = GetPointerPosition(); // Gán pointerPosition vào hàm vector3 GetPointerPosition()
        offset = pointerPosition - transform.position; // Vị trí ban đầu bằng pointerPosition - vị trí hiện tại của Game Object
    }
    // Hàm xử lí khi ta nắm kéo di chuyển Game Object
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pointerPosition = GetPointerPosition(); // Gán pointerPosition vào hàm vector3 GetPointerPosition()
        transform.position = pointerPosition - offset; // di chuyển Game Object một đoạn bằng  pointerPosition - vị trí ban đầu
    }
    private Vector3 GetPointerPosition()
    {
        Vector3 pointerPosition = Vector3.zero;

        if (isOnCanvas)
        {
            // Object trên Canvas có thể dùng toạ độ trên screen
            pointerPosition = Input.mousePosition;
        }
        else
        {
            // Object trong Scene dùng toạ độ World ( phải chuyển đổi tọa độ trên Screen thành tọa độ World)
            pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        pointerPosition.z = 0; //Trong 2D thì ta phải cho tọa độ trục z bằng 0
        return pointerPosition; //trả về giá trị của Vector3 pointerPosition
    }
}