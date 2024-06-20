using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace تذكرتك_علينا.Models;

public class Searchmodel
{
    public List<infomodel>? Match { get; set; } ///Movies
    public SelectList? name { get; set; }  // Genres
    public string? Type { get; set; }// MovieG
    public string? SearchString { get; set; }//SearchString
}