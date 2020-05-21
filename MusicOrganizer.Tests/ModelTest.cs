using Microsoft.VisualStudio.TestTools.UnitTests;
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
  }
}