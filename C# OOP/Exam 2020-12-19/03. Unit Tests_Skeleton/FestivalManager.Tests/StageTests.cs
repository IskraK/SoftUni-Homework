// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[SetUp]
		public void Setup()
        {
			stage = new Stage();
        }
		[Test]
	    public void AddPerformer_ThrowsException_WhenPerformerIsNull()
	    {
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}

		[Test]
		public void AddPerformer_ThrowsException_WhenPerformerAgeIsLessThan18()
		{
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("A","A",5)));
		}

		[Test]
		public void AddPerformer_WorksCorrect_WhenPerformerIsValid()
		{
		Performer performer = new Performer("A", "A", 20);
			stage.AddPerformer(performer);
			Assert.That(stage.Performers.Count == 1);
            Assert.That(stage.Performers.Any(p => p.FullName == "A A" && p.Age == 20), Is.True);
		}


		[Test]
		public void AddSong_ThrowsException_WhenSongIsNull()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}

		[Test]
		public void AddSong_ThrowsException_WhenSongDurationIsLessThan1Minute()
		{
			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("S",new TimeSpan(0,0,23))));
		}

		[Test]
		public void AddSong_WorksCorrect_WhenSongIsValid()
		{
			Song song = new Song("S", new TimeSpan(0, 1, 23));
			stage.AddSong(song);
			Performer performer = new Performer("A", "A", 20);
			stage.AddPerformer(performer);
			performer.SongList.Add(song);
			Assert.That(performer.SongList.Count, Is.EqualTo(1));
            Assert.That(performer.SongList.Any(s => s.Name == "S"), Is.True);
        }

		[Test]
		public void AddSongToPerformer_ThrowsException_WhenPerformerDoesNotExist()
        {
			Song song = new Song("S", new TimeSpan(0, 1, 23));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("S", "P"));
        }

		[Test]
		public void AddSongToPerformer_ThrowsException_WhenSongDoesNotExist()
		{
			Performer performer = new Performer("A", "A", 20);
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("S", "A A"));
		}

		[Test]
		public void AddSongToPerformer_WorksCorrect_WhenDataAreValid()
		{
			Song song = new Song("S", new TimeSpan(0, 1, 23));
			Performer performer = new Performer("A", "A", 20);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			stage.AddSongToPerformer("S", performer.FullName.ToString());
			Assert.That(performer.SongList.Count, Is.EqualTo(1));
			Assert.That(performer.SongList.Any(s => s.Name == "S"), Is.True);
		}

		[Test]
		public void AddSongToPerformer_ReturnCorrectString()
		{
			Song song = new Song("S", new TimeSpan(0, 1, 23));
			Performer performer = new Performer("A", "A", 20);
			stage.AddPerformer(performer);
			stage.AddSong(song);
			string actualResult = stage.AddSongToPerformer("S", performer.FullName.ToString());
			string expectedResult = $"{song} will be performed by {performer.FullName.ToString()}";
			Assert.AreEqual(expectedResult, actualResult);
		}

		[Test]
		public void Play_ReturnCorrectString()
		{
			Song song1 = new Song("S1", new TimeSpan(0, 1, 23));
			Song song2 = new Song("S2", new TimeSpan(0, 2, 23));
			Performer performer1 = new Performer("A", "A", 20);
			Performer performer2 = new Performer("B", "B", 20);
			stage.AddPerformer(performer1);
			stage.AddPerformer(performer2);
			stage.AddSong(song1);
			stage.AddSong(song2);
			stage.AddSongToPerformer("S1", performer1.FullName.ToString());
			stage.AddSongToPerformer("S2", performer2.FullName.ToString());
			int totalSongs = stage.Performers.Sum(p => p.SongList.Count);
			string actual = stage.Play();
			string expected = "2 performers played 2 songs";
			Assert.That(2, Is.EqualTo(totalSongs));
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}