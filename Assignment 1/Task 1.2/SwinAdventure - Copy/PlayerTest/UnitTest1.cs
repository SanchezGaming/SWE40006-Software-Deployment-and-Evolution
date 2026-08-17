namespace PlayerTest;
using NUnit.Framework;
using SwinAdventure;

public class Tests
{

    private Item _scythe;
    private Item _dagger;
    private Player _testPlayer;

    [SetUp]
    public void Setup()
    {
        _testPlayer = new Player("Maeve", "A Soldier");

        _scythe = new Item(new string[] {"scythe"}, "a scythe", "a sharp rounded blade on a long pole");
        _dagger = new Item(new string[] {"dagger"}, "a dagger", "a short sharp blade with a hilt");

        _testPlayer.Inventory.Put(_scythe);
        _testPlayer.Inventory.Put(_dagger);
    }

    [Test]
    public void TestPlayerIsIdentifiable()
    {
        Assert.That(_testPlayer.AreYou("player"), Is.EqualTo(true));
        Assert.That(_testPlayer.AreYou("inventory"), Is.EqualTo(true));
        Assert.Pass();
    }

    [Test]
    public void TestPlayerLocatesItself()
    {
        GameObject? found = _testPlayer.Locate("player");

        Assert.That(found, Is.EqualTo(_testPlayer));
        Assert.Pass();
    }

    [Test]
    public void TestPlayerLocatesItems()
    {
        GameObject? found = _testPlayer.Locate("scythe");

        Assert.That(found, Is.EqualTo(_scythe));
        Assert.Pass();
    }

    [Test]
    public void TestPlayerLocatesNothing()
    {
        GameObject? found = _testPlayer.Locate("sword");
        Assert.That(found, Is.EqualTo(null));

        Assert.Pass();
    }

    [Test]
    public void TestPlayerLongDescription()
    {
        string LongDescription = _testPlayer.LongDescription;
        Assert.That(LongDescription.Contains("Maeve"), Is.EqualTo(true));
        Assert.That(LongDescription.Contains("A Soldier"), Is.EqualTo(true));
        Assert.That(LongDescription.Contains(_scythe.ShortDescription), Is.EqualTo(true));
        Assert.That(LongDescription.Contains(_dagger.ShortDescription), Is.EqualTo(true));
        Assert.That(LongDescription.Contains("You are carrying:"), Is.EqualTo(true));
        Assert.That(LongDescription.Contains("a scythe (scythe)"), Is.EqualTo(true));
        Assert.That(LongDescription.Contains("a dagger (dagger)"), Is.EqualTo(true));
        Assert.Pass();
    }

    [Test]
    public void TestPlayerSaveTo()
    {
        StreamWriter writer = new StreamWriter("TestPlayer2.txt");
        try
        {
            _testPlayer.SaveTo(writer);
        }
        finally
        {
            writer.Close();
        }

        Assert.That(File.ReadAllBytes("testPlayer2.txt").Length > 0, Is.EqualTo(true));
        Console.WriteLine(File.ReadAllBytes("testPlayer2.txt").Length);
        Assert.Pass();
    }
}
