using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using SwinAdventure;

public class TestIdentifiableObject
{
    private IdentifiableObject myObject;

    [SetUp]
    public void  SetUp()
    {
        myObject  = new  IdentifiableObject(new string[] { "Fred", "Bob" });
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void TestAreYou()
    {
        Assert.That(myObject.AreYou("bob"), Is.EqualTo(true));
        Assert.That(myObject.AreYou("fred"), Is.EqualTo(true));

        Assert.Pass();
    }

    [Test]
    public void TestNotAreYou()
    {
        Assert.That(myObject.AreYou("wilma"), Is.EqualTo(false));
        Assert.That(myObject.AreYou("betty"), Is.EqualTo(false));

        Assert.Pass();
    }

    [Test]
    public void TestCaseSensitive()
    {
        Assert.That(myObject.AreYou("FrED"),Is.EqualTo(true));
        Assert.That(myObject.AreYou("BOB"),Is.EqualTo(true));

        Assert.Pass();
    }

    [Test]
    public void TestFirstId()
    {
        Assert.That(myObject.FirstId(), Is.EqualTo("fred"));

        Assert.Pass();
    }

    [Test]
    public void TestFirstIdWithNoId()
    {
        myObject  = new  IdentifiableObject(new string[] { "" });
        Assert.That(myObject.FirstId(), Is.EqualTo(""));
        
        Assert.Pass();
    }

    [Test]
    public void TestAddId()
    {
        myObject.AddIdentifier("wilma");

        Assert.That(myObject.AreYou("bob"), Is.EqualTo(true));
        Assert.That(myObject.AreYou("fred"), Is.EqualTo(true));
        Assert.That(myObject.AreYou("wilma"), Is.EqualTo(true));

        Assert.Pass();
    }

    [Test]
    public void TestPrivateEscalation()
    {
        myObject.PrivilegeEscalation("5488");

        Assert.That(myObject.FirstId(), Is.EqualTo("104415488"));

        Assert.Pass();
    }

    [Test]
    public void TestRemoveIdentifier()
    {
        myObject.RemoveIdentifier("bob");

        Assert.That(myObject.AreYou("fred"), Is.EqualTo(true));

        myObject.RemoveIdentifier("fred");

        Assert.That(myObject.AreYou("fred"), Is.EqualTo(true));
        Assert.That(myObject.AreYou("bob"), Is.EqualTo(false));

        Assert.Pass();
    }
}