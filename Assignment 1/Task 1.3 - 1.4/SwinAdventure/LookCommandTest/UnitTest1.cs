using SwinAdventure;

namespace LookCommandTest;

public class Tests
{

    private Item scythe;
    private Item dagger;
    private Player player;
    private Bag bag;
    private LookCommand lookCommand;

    [SetUp]
    public void Setup()
    {
        scythe = new Item(new string[] {"scythe"}, "A Scythe", "a sharp rounded blade on a long pole\n");
        dagger = new Item(new string[] {"dagger"}, "A Dagger", "a short sharp blade with a hilt\n");
        player = new Player("Test Player", "A test player");
        bag = new Bag(new string[] {"bag"}, "A Bag", "Seemingly bottomless bag");
        lookCommand = new LookCommand();
    }

    [Test]
    public void LookAtPlayer()
    {
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "player"}), Is.EqualTo(player.LongDescription));
        Assert.Pass();
    }

    [Test]
    public void LookAtItem()
    {
        player.Inventory.Put(scythe);
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "scythe"}), Is.EqualTo(scythe.LongDescription));
        Assert.Pass();
    }

    [Test]
    public void LookAtNothing()
    {
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "nothing"}), Is.EqualTo("I cannot find the nothing"));
        Assert.Pass();
    }

    [Test]
    public void LookAtItemInPlayer()
    {
        player.Inventory.Put(scythe);
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "scythe"}), Is.EqualTo(scythe.LongDescription));
        Assert.Pass();
    }

    [Test]
    public void LookAtItemInBag()
    {
        player.Inventory.Put(bag);
        bag.Inventory.Put(scythe);
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "scythe", "in", "bag"}), Is.EqualTo(scythe.LongDescription));
        Assert.Pass();
    }

    [Test]
    public void LookAtItemInNoBag()
    {
        bag.Inventory.Put(dagger);
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "dagger", "in", "bag"}), Is.EqualTo("I cannot find the bag"));
        Assert.Pass();
    }
    
    [Test]
    public void InvalidLook()
    {
        Assert.That(lookCommand.Execute(player, new string[] {"look", ""}), Is.EqualTo("I don't know how to look for that"));
        Assert.That(lookCommand.Execute(player, new string[] {"Hello", "student", "104415488"}), Is.EqualTo("Error in look input"));
        Assert.That(lookCommand.Execute(player, new string[] {"look", "at", "your", "name", "id"}), Is.EqualTo("What do you want to look in?"));
        Assert.Pass();
    }
}
