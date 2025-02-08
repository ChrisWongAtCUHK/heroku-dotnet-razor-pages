﻿using DotNetRazorPages.Models;

namespace DotNetRazorPages.Paging;
public class MovieList
{
    public required IEnumerable<Movie> Movies { get; set; }
    public required PagingInfo PagingInfo { get; set; }
}
