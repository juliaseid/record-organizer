using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Tests
{

  [TestClass]
  public class ArtistTests
  {
    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtistWithOneName_String()
    {
      string fName = "Prince";
      Artist testArtist = new Artist(fName);
      Assert.AreEqual(fName, testArtist.FirstName);
    }
    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtistBothNames_String()
    {
      string fName = "Michael";
      string lName = "Jackson";
      Artist testArtist = new Artist(fName, lName);
      Assert.AreEqual(fName, testArtist.FirstName);
      Assert.AreEqual(lName, testArtist.LastName);
    }

    [TestMethod]
    public void FullName_CreatesFullNameFromFirstAndLast_String()
    {
      string fName = "Michael";
      string lName = "Jackson";
      string fullName = fName + " " + lName;
      Artist testArtist01 = new Artist(fName);
      Artist testArtist02 = new Artist(fName, lName);

      Assert.AreEqual(fName, testArtist01.FullName);
      Assert.AreEqual(fullName, testArtist02.FullName);

    }
  }
}