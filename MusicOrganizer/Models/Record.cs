using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Name { get; set; }
    public int Id { get; }
    //public Artist ThisArtist { get; set; }
    private static int _currentId = 0;
    private static List<Record> _instances = new List<Record> { };

    public Record(string name)
    {
      Name = name;
      _currentId++;
      Id = _currentId;
      _instances.Add(this);
    }

    public static List<Record> GetAll()
    {
      return _instances;
    }

    public static Record Find(int id)
    {
      Record cat = null;
      foreach (Record c in _instances)
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