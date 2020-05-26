using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> artistList = Artist.GetAll();
      return View(artistList);
    }

    [HttpGet("artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string firstName, string lastName)
    {
      Artist newArtist = new Artist(firstName, lastName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Record> discography = selectedArtist.Discography;
      model.Add("artist", selectedArtist);
      model.Add("records", discography);
      return View(model);
    }

    [HttpPost("/artists/{artistId}/records")]
    public ActionResult Create(int artistId, string recordName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Record newRecord = new Record(recordName);
      newRecord.Save();
      foundArtist.AddRecord(newRecord);
      List<Record> discography = foundArtist.Discography;
      model.Add("records", discography);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }


  }

}