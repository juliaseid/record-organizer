using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Name { get; set; }
    public int Id { get; set; }
 
    public Record(string name)
    {
      Name = name;
    }

    public Record(string name, int id)
    {
      Name = name;
      Id = id;
    }

    public override bool Equals(System.Object otherRecord)
    {
      if (!(otherRecord is Record))
      {
        return false;
      }
      else
      {
        Record newRecord = (Record) otherRecord;
        bool idEquality = (this.Id == newRecord.Id);
        bool nameEquality = (this.Name == newRecord.Name);
        return (idEquality && nameEquality);
      }
    }


    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM records;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordName = rdr.GetString(1);
        Record newRecord = new Record(recordName, recordId);
        allRecords.Add(newRecord);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRecords;
    }

    public static Record Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `records` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int recordId = 0;
      string recordName = "";
      while (rdr.Read())
      {
        recordId = rdr.GetInt32(0);
        recordName = rdr.GetString(1);
      }
      Record foundRecord= new Record(recordName, recordId);

      
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRecord;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM records;";
      cmd.ExecuteNonQuery(); //ALTER, ADD, DELETE, UPDATE, DROP, INSERT
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO records (recordName) VALUES (@RecordName);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@RecordName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);    
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;
      // End new code
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

    }

  }



}