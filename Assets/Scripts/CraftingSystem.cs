using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public GameObject CraftingUI;
    public GameObject WeaponCraftingUI;
    public GameObject ArmorCraftingUI;
    public GameObject FoodCraftingUI;

    public List<string> inventoryItems = new List<string>();

    //UIButtons -- for openning UI
    Button WeaponButton;
    Button ArmorButton;
    Button FoodButton;

    //Go Back Button on every UI
    Button WeaponBackButton;
    Button ArmorBackButton;
    Button FoodBackButton;

    //CraftButton -- for crafting items
    Button CraftSpearButton;
    Button CraftWoodenSwordButton;
    Button CraftIronSpearButton;
    Button CraftIronSwordButton;
    Button CraftSimpleHelmetButton;
    Button CraftSimpleArmorButton;
    Button CraftSimpleBootButton;
    Button CraftSimpleGloveButton;
    Button CraftIronHelmetButton;
    Button CraftIronArmorButton;
    Button CraftIronBootButton;
    Button CraftIronGloveButton;
    Button CraftSoupButton;
    Button CraftBreadButton;
    //Requirment
    TextMeshProUGUI SpearReq1, SpearReq2;
    TextMeshProUGUI WoodenSwordReq1;
    TextMeshProUGUI IronSpearReq1, IronSpearReq2;
    TextMeshProUGUI IronSwordReq1, IronSwordReq2;
    TextMeshProUGUI SimpleHelmetReq1;
    TextMeshProUGUI SimpleArmorReq1;
    TextMeshProUGUI SimpleBootReq1;
    TextMeshProUGUI SimpleGloveReq1;
    TextMeshProUGUI IronHelmetReq1, IronHelmetReq2;
    TextMeshProUGUI IronArmorReq1, IronArmorReq2;
    TextMeshProUGUI IronBootReq1, IronBootReq2;
    TextMeshProUGUI IronGloveReq1, IronGloveReq2;
    TextMeshProUGUI SoupReq1, SoupReq2;
    TextMeshProUGUI BreadReq1;


    bool isOpen;

    //CraftItems

    //Weapons
    public CraftItems SpearBP = new("Spear", 2, "Mushroom", 2,"Wood", 3);
    public CraftItems WoodenSwordBP = new("WoodenSword", 1, "Wood", 6,"",0);
    public CraftItems IronSpearBP = new("IronSpear", 2, "Iron", 2, "Wood", 3);
    public CraftItems IronSwordBP = new("IronSword", 2, "Iron", 6, "Wood", 2);
    //Armors
    public CraftItems SimpleHelmetBP = new("SimpleHelmet", 1, "Wood", 4, "", 0);
    public CraftItems SimpleArmorBP = new("SimpleArmor", 1, "Wood", 14, "", 0);
    public CraftItems SimpleBootBP = new("SimpleBoot", 1, "Wood", 4, "", 0);
    public CraftItems SimpleGloveBP = new("SimpleGlove", 1, "Wood", 8, "", 0);
    public CraftItems IronHelmetBP = new("IronHelmet", 2, "Iron", 4, "Wood", 4);
    public CraftItems IronArmorBP = new("IronArmor", 2, "Iron", 10, "Wood", 6);
    public CraftItems IronBootBP = new("IronBoot", 2, "Iron", 2, "Wood", 2);
    public CraftItems IronGloveBP = new("IronGlove", 2, "Iron", 2, "Wood", 4);
    //Food
    public CraftItems SoupBP = new("Soup", 2, "Flower", 2, "Mushroom", 4);
    public CraftItems BreadBP = new("Bread", 1, "Egg", 6, "", 0);


    public static CraftingSystem instance { get; set; }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    void Start()
    {
        CraftingUI.SetActive(false);
        isOpen = false;

        //UIButtons
        WeaponButton = CraftingUI.transform.Find("WeaponButton").GetComponent<Button>();
        WeaponButton.onClick.AddListener(delegate { OpenWeaponCraftingUI(); });

        ArmorButton = CraftingUI.transform.Find("ArmorButton").GetComponent<Button>();
        ArmorButton.onClick.AddListener(delegate { OpenArmorCraftingUI(); });

        FoodButton = CraftingUI.transform.Find("FoodButton").GetComponent<Button>();
        FoodButton.onClick.AddListener(delegate { OpenFoodCraftingUI(); });



        //Go Back Buttons
        //From Weapon/Armor/Food category go back to main crafting page
        WeaponBackButton = WeaponCraftingUI.transform.Find("BackButton").GetComponent<Button>();
        WeaponBackButton.onClick.AddListener(delegate { GoBackToCraftingUI(); });

        ArmorBackButton = ArmorCraftingUI.transform.Find("BackButton").GetComponent<Button>();
        ArmorBackButton.onClick.AddListener(delegate { GoBackToCraftingUI(); });

        FoodBackButton = FoodCraftingUI.transform.Find("BackButton").GetComponent<Button>();
        FoodBackButton.onClick.AddListener(delegate { GoBackToCraftingUI(); });


        //Spear
        SpearReq1 = WeaponCraftingUI.transform.Find("SpearButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        SpearReq2 = WeaponCraftingUI.transform.Find("SpearButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftSpearButton = WeaponCraftingUI.transform.Find("SpearButton").GetComponent<Button>();
        CraftSpearButton.onClick.AddListener(delegate { CraftItem(SpearBP); });

        //WoodenSword
        WoodenSwordReq1 = WeaponCraftingUI.transform.Find("WoodenSwordButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        CraftWoodenSwordButton = WeaponCraftingUI.transform.Find("WoodenSwordButton").GetComponent<Button>();
        CraftWoodenSwordButton.onClick.AddListener(delegate { CraftItem(WoodenSwordBP); });

        //IronSpear
        IronSpearReq1 = WeaponCraftingUI.transform.Find("IronSpearButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        IronSpearReq2 = WeaponCraftingUI.transform.Find("IronSpearButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftIronSpearButton = WeaponCraftingUI.transform.Find("IronSpearButton").GetComponent<Button>();
        CraftIronSpearButton.onClick.AddListener(delegate { CraftItem(IronSpearBP); });

        //IronSword
        IronSwordReq1 = WeaponCraftingUI.transform.Find("IronSwordButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        IronSwordReq2 = WeaponCraftingUI.transform.Find("IronSwordButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftIronSwordButton = WeaponCraftingUI.transform.Find("IronSwordButton").GetComponent<Button>();
        CraftIronSwordButton.onClick.AddListener(delegate { CraftItem(IronSwordBP); });


        //SimpleHelmet
        SimpleHelmetReq1 = ArmorCraftingUI.transform.Find("SimpleHelmetButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        CraftSimpleHelmetButton = ArmorCraftingUI.transform.Find("SimpleHelmetButton").GetComponent<Button>();
        CraftSimpleHelmetButton.onClick.AddListener(delegate { CraftItem(SimpleHelmetBP); });

        //SimpleArmor
        SimpleArmorReq1 = ArmorCraftingUI.transform.Find("SimpleArmorButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        CraftSimpleArmorButton = ArmorCraftingUI.transform.Find("SimpleArmorButton").GetComponent<Button>();
        CraftSimpleArmorButton.onClick.AddListener(delegate { CraftItem(SimpleArmorBP); });

        //SimpleBoot
        SimpleBootReq1 = ArmorCraftingUI.transform.Find("SimpleBootButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        CraftSimpleBootButton = ArmorCraftingUI.transform.Find("SimpleBootButton").GetComponent<Button>();
        CraftSimpleBootButton.onClick.AddListener(delegate { CraftItem(SimpleBootBP); });

        //SimpleGlove
        SimpleGloveReq1 = ArmorCraftingUI.transform.Find("SimpleGloveButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        CraftSimpleGloveButton = ArmorCraftingUI.transform.Find("SimpleGloveButton").GetComponent<Button>();
        CraftSimpleGloveButton.onClick.AddListener(delegate { CraftItem(SimpleGloveBP); });

        //IronHelmet
        IronHelmetReq1 = ArmorCraftingUI.transform.Find("IronHelmetButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        IronHelmetReq2 = ArmorCraftingUI.transform.Find("IronHelmetButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftIronHelmetButton = ArmorCraftingUI.transform.Find("IronHelmetButton").GetComponent<Button>();
        CraftIronHelmetButton.onClick.AddListener(delegate { CraftItem(IronHelmetBP); });

        //IronArmor
        IronArmorReq1 = ArmorCraftingUI.transform.Find("IronArmorButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        IronArmorReq2 = ArmorCraftingUI.transform.Find("IronArmorButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftIronArmorButton = ArmorCraftingUI.transform.Find("IronArmorButton").GetComponent<Button>();
        CraftIronArmorButton.onClick.AddListener(delegate { CraftItem(IronArmorBP); });

        //IronBoot
        IronBootReq1 = ArmorCraftingUI.transform.Find("IronBootButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        IronBootReq2 = ArmorCraftingUI.transform.Find("IronBootButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftIronBootButton = ArmorCraftingUI.transform.Find("IronBootButton").GetComponent<Button>();
        CraftIronBootButton.onClick.AddListener(delegate { CraftItem(IronBootBP); });

        //IronGlove
        IronGloveReq1 = ArmorCraftingUI.transform.Find("IronGloveButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        IronGloveReq2 = ArmorCraftingUI.transform.Find("IronGloveButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftIronGloveButton = ArmorCraftingUI.transform.Find("IronGloveButton").GetComponent<Button>();
        CraftIronGloveButton.onClick.AddListener(delegate { CraftItem(IronGloveBP); });

        //Soup
        SoupReq1 = FoodCraftingUI.transform.Find("SoupButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        SoupReq2 = FoodCraftingUI.transform.Find("SoupButton").transform.Find("req2").GetComponent<TextMeshProUGUI>();
        CraftSoupButton = FoodCraftingUI.transform.Find("SoupButton").GetComponent<Button>();
        CraftSoupButton.onClick.AddListener(delegate { CraftItem(SoupBP); });

        //Bread
        BreadReq1 = FoodCraftingUI.transform.Find("BreadButton").transform.Find("req1").GetComponent<TextMeshProUGUI>();
        CraftBreadButton = FoodCraftingUI.transform.Find("BreadButton").GetComponent<Button>();
        CraftBreadButton.onClick.AddListener(delegate { CraftItem(BreadBP); });
    }


    void Update()
    {
        
        //Open/Close Crafting
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            RefreshItems();
            CraftingUI.SetActive(true);
            isOpen = true;
            //Unlock cursor on inventory UI
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            CraftingUI.SetActive(false);
            WeaponCraftingUI.SetActive(false);
            ArmorCraftingUI.SetActive(false);
            FoodCraftingUI.SetActive(false);
            isOpen = false;
            //Lock cursor when we close inventory
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void OpenWeaponCraftingUI()
    {
        CraftingUI.SetActive(false);
        WeaponCraftingUI.SetActive(true);
    }

    void OpenArmorCraftingUI()
    {
        CraftingUI.SetActive(false);
        ArmorCraftingUI.SetActive(true);
    }

    void OpenFoodCraftingUI()
    {
        CraftingUI.SetActive(false);
        FoodCraftingUI.SetActive(true);
    }

    void GoBackToCraftingUI()
    {
        WeaponCraftingUI.SetActive(false);
        ArmorCraftingUI.SetActive(false);
        FoodCraftingUI.SetActive(false);
        CraftingUI.SetActive(true);
    }

    void CraftItem(CraftItems ItemToCraft)
    {
        //remove resources from inventory

        if(ItemToCraft.total_Req == 1)
        {
            InventorySystem.Instance.RemoveItem(ItemToCraft.Req1, ItemToCraft.Req1amount);
        }
        else if(ItemToCraft.total_Req ==2)
        {
            InventorySystem.Instance.RemoveItem(ItemToCraft.Req1, ItemToCraft.Req1amount);
            InventorySystem.Instance.RemoveItem(ItemToCraft.Req2, ItemToCraft.Req2amount);
        }

        //add item to inventory
        InventorySystem.Instance.AddToInventory(ItemToCraft.itemName);
        MusicManager.Instance.PlayCraftItemSound();
        StartCoroutine(calculate());

    }

    public IEnumerator calculate()
    {
        yield return 0;
        InventorySystem.Instance.Calculate();
        RefreshItems();
    }

    public void RefreshItems()
    {
        int Stone_count = 0;
        int Wood_count = 0;
        int Iron_count = 0;
        int Mushroom_count = 0;
        int Egg_count = 0;
        int Flower_count = 0;

        inventoryItems = InventorySystem.Instance.Items;
        foreach(string item in inventoryItems)
        {
            switch(item)
            {
                case "Stone":
                    Stone_count += 1;
                    break;

                case "Wood":
                    Wood_count += 1;
                    break;

                case "Iron":
                    Iron_count += 1;
                    break;

                case "Mushroom":
                    Mushroom_count += 1;
                    break;

                case "Egg":
                    Egg_count += 1;
                    break;

                case "Flower":
                    Flower_count += 1;
                    break;
            }
        }

        // Spear
        SpearReq1.text = "2 Stone[" + Stone_count + "]";
        SpearReq2.text = "3 Wood[" + Wood_count + "]";
        if (Stone_count >= 2 && Wood_count >= 3)
        {
            CraftSpearButton.gameObject.SetActive(true);
        }
        else
        {
            CraftSpearButton.gameObject.SetActive(false);
        }

        //WoodenSword
        WoodenSwordReq1.text = "6 Wood[" + Wood_count + "]";
        if (Wood_count >= 6)
        {
            CraftWoodenSwordButton.gameObject.SetActive(true);
        }
        else
        {
            CraftWoodenSwordButton.gameObject.SetActive(false);
        }

        //IronSpear
        IronSpearReq1.text = "2 Iron[" + Iron_count + "]";
        IronSpearReq2.text = "3 Wood[" + Wood_count + "]";
        if (Iron_count >= 2 && Wood_count >= 3)
        {
            CraftIronSpearButton.gameObject.SetActive(true);
        }
        else
        {
            CraftIronSpearButton.gameObject.SetActive(false);
        }

        //IronSword
        IronSwordReq1.text = "6 Iron[" + Iron_count + "]";
        IronSwordReq2.text = "2 Wood[" + Wood_count + "]";
        if (Iron_count >= 6 && Wood_count >= 2)
        {
            CraftIronSwordButton.gameObject.SetActive(true);
        }
        else
        {
            CraftIronSwordButton.gameObject.SetActive(false);
        }

        //SimpleHelmet
        SimpleHelmetReq1.text = "4 Wood[" + Wood_count + "]";
        if (Wood_count >= 4)
        {
            CraftSimpleHelmetButton.gameObject.SetActive(true);
        }
        else
        {
            CraftSimpleHelmetButton.gameObject.SetActive(false);
        }

        //SimpleArmor
        SimpleArmorReq1.text = "14 Wood[" + Wood_count + "]";
        if (Wood_count >= 14)
        {
            CraftSimpleArmorButton.gameObject.SetActive(true);
        }
        else
        {
            CraftSimpleArmorButton.gameObject.SetActive(false);
        }

        //SimpleBoot
        SimpleBootReq1.text = "4 Wood[" + Wood_count + "]";
        if (Wood_count >= 4)
        {
            CraftSimpleBootButton.gameObject.SetActive(true);
        }
        else
        {
            CraftSimpleBootButton.gameObject.SetActive(false);
        }

        //SimpleGlove
        SimpleGloveReq1.text = "8 Wood[" + Wood_count + "]";
        if (Wood_count >= 8)
        {
            CraftSimpleGloveButton.gameObject.SetActive(true);
        }
        else
        {
            CraftSimpleGloveButton.gameObject.SetActive(false);
        }

        //IronHelmet
        IronHelmetReq1.text = "4 Iron[" + Iron_count + "]";
        IronHelmetReq2.text = "4 Wood[" + Wood_count + "]";
        if (Iron_count >=4 && Wood_count >= 4)
        {
            CraftIronHelmetButton.gameObject.SetActive(true);
        }
        else
        {
            CraftIronHelmetButton.gameObject.SetActive(false);
        }

        //IronArmor
        IronArmorReq1.text = "10 Iron[" + Iron_count + "]";
        IronArmorReq2.text = "6 Wood[" + Wood_count + "]";
        if (Iron_count >= 10 && Wood_count >= 6)
        {
            CraftIronArmorButton.gameObject.SetActive(true);
        }
        else
        {
            CraftIronArmorButton.gameObject.SetActive(false);
        }

        //IronBoot
        IronBootReq1.text = "2 Iron[" + Iron_count + "]";
        IronBootReq2.text = "2 Wood[" + Wood_count + "]";
        if (Iron_count >= 2 && Wood_count >= 2)
        {
            CraftIronBootButton.gameObject.SetActive(true);
        }
        else
        {
            CraftIronBootButton.gameObject.SetActive(false);
        }

        //IronGlove
        IronGloveReq1.text = "2 Iron[" + Iron_count + "]";
        IronGloveReq2.text = "4 Wood[" + Wood_count + "]";
        if (Iron_count >= 2 && Wood_count >= 4)
        {
            CraftIronGloveButton.gameObject.SetActive(true);
        }
        else
        {
            CraftIronGloveButton.gameObject.SetActive(false);
        }

        //Soup
        SoupReq1.text = "2 Flower[" + Flower_count + "]";
        SoupReq2.text = "4 Mushroom[" + Mushroom_count + "]";
        if (Flower_count >= 2 && Mushroom_count >= 4)
        {
            CraftSoupButton.gameObject.SetActive(true);
        }
        else
        {
            CraftSoupButton.gameObject.SetActive(false);
        }

        //Bread
        BreadReq1.text = "6 Egg[" + Egg_count + "]";
        if (Egg_count >= 6)
        {
            CraftBreadButton.gameObject.SetActive(true);
        }
        else
        {
            CraftBreadButton.gameObject.SetActive(false);
        }


    }
}
