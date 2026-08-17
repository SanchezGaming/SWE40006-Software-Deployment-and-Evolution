using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;


public class TestItem
{

    Item entity;

    [SetUp]
    public void  SetUp()
    {
        entity = new Item(new string[] {"gun"}, "a gun", "ranged weapon, dangerous");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestIsIdentifiable()
    {
        Assert.That(entity.AreYou("sword"), Is.EqualTo(false));
        Assert.That(entity.AreYou("gun"), Is.EqualTo(true));
        
        Assert.Pass();
    }

    [Test]
    public void TestShortDescription()
    {
        Assert.That(entity.ShortDescription, Is.EqualTo("a gun (gun)"));

        Assert.Pass();
    }

    [Test]
    public void TestLongDescription()
    {
        Assert.That(entity.LongDescription, Is.EqualTo("ranged weapon, dangerous"));

        Assert.Pass();
    }

    [Test]
    public void TestPrivateEscalation()
    {
        entity.PrivilegeEscalation("5488");

        Assert.That(entity.FirstId(), Is.EqualTo("104415488"));

        Assert.Pass();
    }
}