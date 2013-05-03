//-----------------------------------------------------------------------
// <copyright file="SearchHelper.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Master.Web.search
{
	using System;
	using System.Collections.Generic;
	
	using Examine;
	using Examine.LuceneEngine.SearchCriteria;
	using Master.Business.Models;

    /// <summary>
    /// Provides methods to work with search.
    /// </summary>
	public static class SearchHelper
	{
		public static List<VideoModel> SearchSite(string term)
		{
			List<VideoModel> videos = new List<VideoModel>();
			var Searcher = ExamineManager.Instance.SearchProviderCollection["WebsiteSearcher"];
			var searchCriteria = Searcher.CreateSearchCriteria(UmbracoExamine.IndexTypes.Content);
			var filter = searchCriteria.GroupedOr(new string[] { "title", "videoDescription" }, term);
			filter = filter.And().Field("__NodeTypeAlias", "Video");

			var results = Searcher.Search(filter.Compile());

			foreach (SearchResult item in results)
			{
				VideoModel video = new VideoModel();
				video.Id = item.Fields["id"];
				video.Title = item.Fields["title"];
				video.VideoLink = item.Fields["videoLink"];
				DateTime date = DateTime.Now;
				if (DateTime.TryParse(item.Fields["videoDate"], out date))
				{
					video.VideoDate = date;
				}
				else
				{
					video.VideoDate = DateTime.Now;
				}

				video.VideoDescription = item.Fields["videoDescription"];
				video.SeoTitle = item.Fields["title"];

				videos.Add(video);
			}

			return videos;
		}
	}
}