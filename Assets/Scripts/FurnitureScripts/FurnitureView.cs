using System.Collections.Generic;
using Tomo.Core;
using Tomo.UI.ButtonSystem;
using UnityEngine;

public class FurnitureView : ReadyableMonobehaviour
{
    private List<Furniture> m_currentShowingFurnitures = new List<Furniture>();
    private List<GameObject> m_furnitureButtons = new List<GameObject>();

    public GameObject FurnitureButtonUI;
    public Transform FurnitureButtonHolder;

    [Space(10)]
    public GameObject ButtonPrefab;

    [Space(10)]
    public Button FurnitureTypeFilterButton;
    public GameObject FurnitureTypeGroup;
    public Button ChairFilterButton;
    public Button TableFilterButton;
    public Button BedFilterButton;

    [Space(10)]
    public Button ColourTypeFilterButton;
    public GameObject ColourTypeGroup;
    public Button RedFilterButton;
    public Button BlueFilterButton;
    public Button GreenFilterButton;

    [Space(10)]
    public TMPro.TextMeshProUGUI FurnitureNameText;
    private Furniture m_currentFurniture;

    //binds buttons to their respective filters
    private void Awake()
    {
        FurnitureTypeFilterButton.OnClick2 += ShowFurnitureTypeFilter;
        ColourTypeFilterButton.OnClick2 += ShowColourTypeFilter;

        ChairFilterButton.OnClick2 += () => FilterByType(FurnitureType.Chair);
        TableFilterButton.OnClick2 += () => FilterByType(FurnitureType.Table);
        BedFilterButton.OnClick2 += () => FilterByType(FurnitureType.Bed);

        RedFilterButton.OnClick2 += () => FilterByColor(Colours.Red);
        BlueFilterButton.OnClick2 += () => FilterByColor(Colours.Blue);
        GreenFilterButton.OnClick2 += () => FilterByColor(Colours.Green);

        SetToReady();
    }

    private void OnDestroy()
    {
        FurnitureTypeFilterButton.OnClick2 -= ShowFurnitureTypeFilter;
        ColourTypeFilterButton.OnClick2 -= ShowColourTypeFilter;

        ChairFilterButton.OnClick2 -= () => FilterByType(FurnitureType.Chair);
        TableFilterButton.OnClick2 -= () => FilterByType(FurnitureType.Table);
        BedFilterButton.OnClick2 -= () => FilterByType(FurnitureType.Bed);

        RedFilterButton.OnClick2 -= () => FilterByColor(Colours.Red);
        BlueFilterButton.OnClick2 -= () => FilterByColor(Colours.Blue);
        GreenFilterButton.OnClick2 -= () => FilterByColor(Colours.Green);
    }

    public void SelectFurniture(Furniture furniture)
    {
        m_currentFurniture = furniture;
        FurnitureNameText.text = m_currentFurniture.furnitureName;
    }

    public void ShowFurnitureTypeFilter()
    {
        m_currentShowingFurnitures.Clear();
        ResetFurnitureButtons();

        FurnitureTypeGroup.SetActive(true);
        ColourTypeGroup.SetActive(false);

        FurnitureButtonUI.SetActive(false);
    }

    public void ShowColourTypeFilter()
    {
        m_currentShowingFurnitures.Clear();
        ResetFurnitureButtons();

        ColourTypeGroup.SetActive(true);
        FurnitureTypeGroup.SetActive(false);

        FurnitureButtonUI.SetActive(false);
    }

    public void FilterByType(FurnitureType type)
    {
        m_currentShowingFurnitures = FurnitureController.Instance.GetAllFurnitureByType(type);

        FurnitureButtonUI.SetActive(true);

        ResetFurnitureButtons();
        InitNewFurnitureButtons();
    }

    public void FilterByColor(Colours c)
    {
        m_currentShowingFurnitures = FurnitureController.Instance.GetAllFurnitureByColor(c);

        FurnitureButtonUI.SetActive(true);

        ResetFurnitureButtons();
        InitNewFurnitureButtons();
    }

    private void ResetFurnitureButtons()
    {
        foreach (var button in m_furnitureButtons)
        {
            Destroy(button);
        }
        m_furnitureButtons.Clear();
    }

    private void InitNewFurnitureButtons()
    {
        foreach (var furniture in m_currentShowingFurnitures)
        {
            var button = Instantiate(ButtonPrefab, FurnitureButtonHolder);
            var buttonText = button.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            buttonText.text = furniture.furnitureName;
            m_furnitureButtons.Add(button);

            var buttonScript = button.GetComponent<FurnitureInstanceButton>();
            buttonScript.SetFurniture(furniture, this);
        }
    }
}
