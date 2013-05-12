//-----------------------------------------------------------------------
// <copyright file="SearchHelper.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Master.Web.search
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	using Examine;
    using Examine.LuceneEngine.SearchCriteria;

	using Master.Business.Models;

    /// <summary>
    /// Provides methods to work with search.
    /// </summary>
	public static class SearchHelper
	{
        public static List<VideoModel> SearchSite(string term, string searchedCategories)
		{
			List<VideoModel> videos = new List<VideoModel>();
            string[] categories = null;
            if (!String.IsNullOrEmpty(searchedCategories))
            {
                categories = searchedCategories.Split(',');
            }

			ISearchResults results;
			var Searcher = ExamineManager.Instance.SearchProviderCollection["WebsiteSearcher"];
			var searchCriteria = Searcher.CreateSearchCriteria(UmbracoExamine.IndexTypes.Content);
			term = term.Trim();
			if (term.IndexOf(' ') == -1)
			{
				var filter = searchCriteria.GroupedOr(new string[] { "title", "videoDescription" }, term.MultipleCharacterWildcard());
				filter = filter.And().Field("__NodeTypeAlias", "Video");
                
                /*
                if (categories != null && categories.Length > 0)
                {
                    foreach (string category in categories)
                    {
                        filter = filter.And().Field("categories", category.MultipleCharacterWildcard());
                    }
                }*/
                if (categories!= null && categories.Length > 0) {
                    filter = filter.And().GroupedOr(new string[] { "categories" }, categories);
                }

				results = Searcher.Search(filter.Compile());
			}
			else
			{
				List<string> searchTerm = term.Split(' ').ToList();
				var filter = searchCriteria.GroupedOr(new string[] { "title", "videoDescription" }, searchTerm[0].MultipleCharacterWildcard());
				for (int i = 1; i < searchTerm.Count; i++) {
					filter.And().GroupedOr(new string[] { "title", "videoDescription" }, searchTerm[i].MultipleCharacterWildcard());
				}

				filter = filter.And().Field("__NodeTypeAlias", "Video");

                if (categories != null && categories.Length > 0)
                {
                    filter = filter.And().GroupedOr(new string[] { "categories" }, categories);
                }



    			results = Searcher.Search(filter.Compile());
			}

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