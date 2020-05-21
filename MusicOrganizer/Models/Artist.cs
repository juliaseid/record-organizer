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
    private static int _currentId = 0;
    private static List<Artist> _instances = new List<Artist> { };

    public Artist(string first)
    {
      FirstName = first;
      FullName = first;
      _currentId++;
      Id = _currentId;
      _instances.Add(this);
    }
    public Artist(string first, string last)
    {
      FirstName = first;
      LastName = last;
      FullName = $"{first} {last}";
      _currentId++;
      Id = _currentId;
      _instances.Add(this);
    }
    public void AddRecord(Record record)
    {
      Discography.Add(record);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int id)
    {
      Artist cat = null;
      foreach (Artist c in _instances)
      {
        if (c.Id == id)
        {
          cat = c;
        }
      }
      return cat;
    }

  }
}