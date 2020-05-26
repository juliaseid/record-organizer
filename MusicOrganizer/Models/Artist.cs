using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public List<Record> Discography = new List<Record> { };
    public int Id { get; }
    private static List<Artist> _instances = new List<Artist> { };

    public Artist(string first)
    {
      FirstName = first;
      FullName = first;
      _instances.Add(this);
      Id = _instances.Count;
    }
    public Artist(string first, string last)
    {
      FirstName = first;
      LastName = last;
      FullName = $"{first} {last}";
      _instances.Add(this);
      Id = _instances.Count;
    }
    public void AddRecord(Record record)
    {
      Discography.Add(record);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

  }
}