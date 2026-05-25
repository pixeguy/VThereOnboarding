using Tomo.UI.ButtonSystem;
using UnityEngine;

public class FurnitureInstanceButton : MonoBehaviour
{
    private Button m_furnitureButton;
    private Furniture m_furniture;
    private FurnitureView m_view;

    private void Awake()
    {
        m_furnitureButton = GetComponent<Button>();
    }

    public void SetFurniture(Furniture furniture, FurnitureView view)
    {
        this.m_furniture = furniture;
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = furniture.furnitureName;
        this.m_view = view;
        m_furnitureButton.OnClick2 += () => this.m_view.SelectFurniture(furniture);
    }

    private void OnDestroy()
    {
        if (m_furniture != null)
            m_furnitureButton.OnClick2 -= () => m_view.SelectFurniture(m_furniture);
    }
}
