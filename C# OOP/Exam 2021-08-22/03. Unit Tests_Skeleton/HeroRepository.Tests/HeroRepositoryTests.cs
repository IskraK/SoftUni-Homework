using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void Ctor_InitializeCollection()
    {
        Assert.That(heroRepository.Heroes, Is.Not.Null);
    }

    [Test]
    public void Create_ThrowsException_WhenHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void Create_ThrowsException_WhenHeroExists()
    {
        Hero hero = new Hero("Name", 5);
        heroRepository.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero));
    }

    [Test]
    public void Create_WorksCorrect()
    {
        Hero hero = new Hero("Name", 5);
        heroRepository.Create(hero);
        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(1));
    }

    [Test]
    public void Create_ReturnsCorrectMessage()
    {
        Hero hero = new Hero("Name", 5);
        string result = heroRepository.Create(hero);
        string expected= $"Successfully added hero {hero.Name} with level {hero.Level}";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Remove_ThrowsException_WhenHeroNameIsNull()
    {
        Hero hero = new Hero(null, 5);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void Remove_WorksCorrect()
    {
        Hero hero = new Hero("Name", 5);
        heroRepository.Create(hero);
        heroRepository.Remove("Name");
        Assert.That(heroRepository.Heroes.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetHeroWithHighestLevel_WorksCorrect()
    {
        Hero hero = new Hero("Name", 5);
        Hero hero2 = new Hero("Name2", 2);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        Assert.That(heroRepository.GetHeroWithHighestLevel, Is.EqualTo(hero));
    }

    [Test]
    public void GetHero_WorksCorrect()
    {
        Hero hero = new Hero("Name", 5);
        Hero hero2 = new Hero("Name2", 2);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        Assert.That(heroRepository.GetHero("Name"), Is.EqualTo(hero));
    }
}