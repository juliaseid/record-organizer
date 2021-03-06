using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {

    public void Dispose()
    {
      Record.ClearAll();
    }

    public RecordTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    // [TestMethod]
    // public void Record_TestConstructor_Record()
    // {
    //   Record newRecord = new Record("hi");
    //   Assert.AreEqual(typeof(Record), newRecord.GetType());
    // }
    // [TestMethod]
    // public void Record_TestConstructorHasNameProperty_String()
    // {
    //   string thing = "hi";
    //   Record newRecord = new Record(thing);
    //   Assert.AreEqual(thing, newRecord.Name);
    // }

    //     [TestMethod]
    // public void SetName_SetName_string()
    // {
    //   //Arrange
    //   string recordName = "Walk the dog";
    //   Record newRecord = new Record(recordName);

    //   //Act
    //   string newRecordName = "Do the dishes";
    //   newRecord.Name = newRecordName;
    //   string result = newRecord.Name;

    //   //Assert
    //   Assert.AreEqual(newRecordName, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_RecordList()
    {
      // Arrange
      List<Record> newList = new List<Record> { };

      // Act
      List<Record> result = Record.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_RecordList()
    {
      //Arrange
      string name01 = "Mow the lawn";
      string name02 = "Sweep the porch";
      Record newRecord1 = new Record(name01);
      newRecord1.Save();
      Record newRecord2 = new Record(name02);
      newRecord2.Save();
      List<Record> newList = new List<Record> {newRecord1, newRecord2};

      //Act
      List<Record> result = Record.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetId_RecordsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string recordName = "Walk the dog";
    //   Record newRecord = new Record(recordName);

    //   //Act
    //   int result = newRecord.Id;

    //   //Assert
    //   Assert.AreEqual(1, result);
    // }

  [TestMethod]
    public void Find_ReturnsCorrectRecordFromDatabase_Record()
    {
      //Arrange
      Record newRecord = new Record("Mow the lawn");
      newRecord.Save();
      Record newRecord2 = new Record("Wash dishes");
      newRecord2.Save();

      //Act
      Record foundRecord = Record.Find(newRecord.Id);
      //Assert
      Assert.AreEqual(newRecord, foundRecord);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Record()
    {
      //Arrange, Act
      Record firstRecord = new Record ("Mow the lawn!");
      Record secondRecord = new Record ("Mow the lawn!");

      //Assert
      Console.WriteLine("Record1");
      Assert.AreEqual(firstRecord, secondRecord);
    }

    [TestMethod]
    public void Save_SavesToDatabase_RecordList()
    {
      //Arrange
      Record testRecord = new Record("Mow the lawn");

      //Act
      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record>{testRecord};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

  }
}