using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class MusicOrganizerTests
  {
    [TestMethod]
    public void Record_TestConstructor_Record()
    {
      Record newRecord = new Record("hi");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }
    [TestMethod]
    public void Record_TestConstructorHasNameProperty_String()
    {
      string thing = "hi";
      Record newRecord = new Record(thing);
      Assert.AreEqual(thing, newRecord.Name);
    }


  }
}