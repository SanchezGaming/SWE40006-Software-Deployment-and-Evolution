using SwinAdventure;

namespace SwinAdventure;

public class Test
{
    Item gun;
    Item sword;
    Item magicMissile;
    Inventory i;

    [SetUp]
    public void Setup()
    {
        gun = new Item(new string[] {"gun"}, " a gun", "ranged weapon, dangerous");
        sword = new Item(new string[] {"sword"}, " a sword", "melee weapon, dangerous up close");
        magicMissile = new Item(new string[] {"magic missile"}, " a magic missile", "explosive, kaboom");
        i = new Inventory();
        i.Put(gun);
        i.Put(sword);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestFindItem()
    {
        Assert.That(i.HasItem("gun"), Is.EqualTo(true));

        Assert.Pass();
    }

    [Test]
    public void TestNoItemFind()
    {
        Assert.That(i.HasItem("dagger"), Is.EqualTo(false));

        Assert.Pass();
    }

    [Test]
    public void TestFetchItem()
    {
        Item? fetchItem = i.Fetch(gun.FirstId());
        Assert.That((fetchItem == gun), Is.EqualTo(true));
        Assert.That(i.HasItem(gun.FirstId()));

        Assert.Pass();
    }

    [Test]
    public void TestTakeItem()
    {
        i.Take(gun.FirstId());
        Assert.That(i.HasItem(gun.FirstId()), Is.EqualTo(false));

        Assert.Pass();
    }

    [Test]
    public void TestItemList()
    {
        Assert.That(i.ItemList, Is.EqualTo(" a gun (gun),  a sword (sword)"));
    }

    [Test]
    public void TestItemWithLimit()
    {
        Assert.That(i.Put_ItemWithLimit(magicMissile), Is.True);
        Assert.That(i.Put_ItemWithLimit(magicMissile), Is.True);

        Console.WriteLine(i.ItemList);

        Assert.Pass();
    }
}
