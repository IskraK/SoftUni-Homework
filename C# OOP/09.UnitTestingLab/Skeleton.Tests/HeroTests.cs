using Moq;
using NUnit.Framework;
using Skeleton;

[TestFixture]
public class HeroTests
{
    [Test]
    public void Attack_HeroGainsXP_WhenTargetIsDead()
    {
        Mock<IWeapon> fakeAxe = new Mock<IWeapon>();
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(t => t.IsDead()).Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(20);
        Hero hero = new Hero("Pesho", fakeAxe.Object);
        hero.Attack(fakeTarget.Object);
        Assert.That(hero.Experience, Is.EqualTo(20));
    }
}