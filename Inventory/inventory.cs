class Inventory {
    private Armors _inventoryArmors; 
    private Weapons _inventoryWeapons;
    private Gloves _inventoryGloves;
    private int _totalItems;


    public Inventory(Armors inventoryArmors, Weapons inventoryWeapons, Gloves inventoryGloves) {
        _inventoryArmors = new inventoryArmors();
        _inventoryWeapons = new inventoryWeapons();
        _inventoryGloves = new inventoryGloves();
        _totalItems = 1000;
    }

    public int checkItems() {
        return _totalItems;
    }

    public Armors checkArmors() {
        return _inventoryArmors;
    }
    public Weapons checkWeapons() {
        return _inventoryWeapons;
    }
    public Gloves checkGloves() {
        return _inventoryGloves;
    }
}