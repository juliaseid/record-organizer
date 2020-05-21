using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Name {get; set;}
    public int Id {get;}
    public Artist ThisArtist {get; set;}
    private static int _currentId = 0;
    private static List<Record> _instances = new List<Record> {};
  
  public Record (string name, Artist artist )
  {
    Name = name;
    ThisArtist = artist;
    _currentId++;
    Id = _currentId;
    _instances.Add(this);
  }
  public Record (string name)
  {
    Name = name;
   // ThisArtist = new Artist("Unknown");
    _currentId++;
    Id = _currentId;
    _instances.Add(this);
  }

  }

  
}