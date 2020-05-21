using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Name {get; set;}
    public int Id {get;}
    private static int _currentId = 0;
    private static List<Record> _instances = new List<Record> {};
  
  public Record (string name  )
  {
    Name = name;
    _currentId++;
    Id = _currentId;
    _instances.Add(this);
  }
  

  }

  
}