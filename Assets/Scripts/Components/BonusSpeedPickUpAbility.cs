using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class BonusSpeedPickUpAbility : MonoBehaviour //IAbilityTarget
{
    public List<GameObject> Targets { get; set; }
    public GameObject _UIItem;
    public GameObject UIItem => _UIItem;
    public GameObject ItemMenuPanel;
    private GameObject  DescriptionItemObj;
    private Text DescriptionItemText;
    private string _defaultText = "DESCRIPTION:";

    private void Start()
    {
        DescriptionItemObj = GameObject.FindGameObjectWithTag("ItemDescrption");
        DescriptionItemText = DescriptionItemObj.GetComponent<Text>();
    }


    public void OpenItemMenu()
    {
        Debug.Log("Clicked");
        ItemMenuPanel.SetActive(true);
        DescriptionItemText.text = $"{_defaultText} This item need to upgrade character's speed";
    }
}
