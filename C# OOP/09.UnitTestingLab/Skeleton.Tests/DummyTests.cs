using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void InitializeDummy()
    {
        dummy = new Dummy(10, 10);
        dummy.TakeAttack(5);
    }
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Assert.AreEqual(5, dummy.Health);
    }
    [Test]
    public void DeadDummThrowsExceptionIfAttacked()
    {
        dummy.TakeAttack(5);

        Assert.That(() => dummy.TakeAttack(5),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dummy is dead."));
    }
    [Test]
    public void DeadDummyCanGiveXP()
    {
        dummy.TakeAttack(5);

        Assert.That(dummy.GiveExperience(), Is.EqualTo(10));
    }
    [Test]
    public void AliveDummyCanNotGiveXP()
    {
        Assert.That(() => dummy.GiveExperience(),
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
