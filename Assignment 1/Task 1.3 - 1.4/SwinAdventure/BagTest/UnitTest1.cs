using SwinAdventure;

namespace BagTest;

public class Tests
{

    private Bag _testWeaponBag;
    private Bag _testPotionBag;

    private Item scythe;
    private Item dagger;
    private Item healthPotion;

    [SetUp]
    public void Setup()
    {
        _testWeaponBag = new Bag(new string[] {"weapon bag"}, "Weapon Bag", "A bag for weapons");
        _testPotionBag = new Bag(new string[] {"potion bag"}, "Potion Bag", "A bag for potions");

        scythe = new Item(new string[] {"scythe"}, "a scythe", "a sharp rounded blade on a long pole");
        dagger = new Item(new string[] {"dagger"}, "a dagger", "a small blade");
        healthPotion = new Item(new string[] {"health potion"}, "a health potion", "a red liquid that restores health");

        _testWeaponBag.Inventory.Put(scythe);
        _testPotionBag.Inventory.Put(healthPotion);
    }

    [Test]
    public void TestBagLocatesItems()
    {
        GameObject? item = _testWeaponBag.Locate("scythe");
        Assert.That(item, Is.EqualTo(scythe));
        Assert.That(_testWeaponBag.Inventory.HasItem("scythe"), Is.EqualTo(true));
        Assert.Pass();
    }

    
    [Test]
    public void TestBagLocatesItself()
    {
        var bag = _testWeaponBag.Locate("weapon bag");
        Assert.That(bag, Is.EqualTo(_testWeaponBag));
        Assert.Pass();
    }

    
    [Test]
    public void TestBagLocatesNothing()
    {
        var item = _testWeaponBag.Locate("dagger");
        Assert.That(item, Is.EqualTo(null));
        Assert.Pass();
    }

    
    [Test]
    public void TestBagLongDescription()
    {
        string description = _testWeaponBag.LongDescription;
        Assert.That(description.Contains("In the Weapon Bag you can see: a scythe"), Is.EqualTo(true));
        Assert.Pass();
    }

    
    [Test]
    public void TestBagInBag()
    {
        _testWeaponBag.Inventory.Put(_testPotionBag);
        _testWeaponBag.Inventory.Put(dagger);
        Assert.That(_testWeaponBag.Inventory.HasItem("potion bag"), Is.EqualTo(true));
        Assert.That(_testWeaponBag.Inventory.HasItem("scythe"), Is.EqualTo(true));
        Assert.That(_testWeaponBag.Inventory.HasItem("dagger"), Is.EqualTo(true));

        var nestedItem = new Item(new string[] {"nested item"}, "a nested item", "an item inside the potion bag");
        _testPotionBag.Inventory.Put(nestedItem);
        Assert.That(_testWeaponBag.Locate("nested item"), Is.Null);
        Assert.Pass();
    }

    
    [Test]
    public void TestBagInBagWithPrivilegeEscalation()
    {
        var pass = new Item(new string[] {"pass"}, "a pass", "a pass that grants access secrets");
        pass.PrivilegeEscalation("5488");
        _testWeaponBag.Inventory.Put(_testPotionBag);
        _testPotionBag.Inventory.Put(pass);
        Assert.That(_testWeaponBag.Locate("104415488"), Is.Null);
        Assert.Pass();
    }

    [Test]
    public void TestBagIsEmpty()
    {
        Assert.That(_testWeaponBag.IsEmpty, Is.EqualTo(false));
        Assert.That(_testPotionBag.IsEmpty, Is.EqualTo(false));

        var emptyBag = new Bag(new string[] {"empty bag"}, "Empty Bag", "A bag that is empty");
        Assert.That(emptyBag.IsEmpty, Is.EqualTo(true));

        emptyBag.Inventory.Put(scythe);
        Assert.That(emptyBag.IsEmpty, Is.EqualTo(false));
        Assert.Pass();
    }
}
