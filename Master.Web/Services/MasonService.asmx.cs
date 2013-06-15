//-----------------------------------------------------------------------
// <copyright file="MasonService.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Web.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Script.Serialization;
	using System.Web.Script.Services;
	using System.Web.Services;
	using Master.Business.Helpers;
	using Master.Business.Models;
	using Master.Entities.DocumentTypes;
	using Vega.USiteBuilder;

	/// <summary>
	/// Summary description for WebService1
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class MasonService : System.Web.Services.WebService
	{
		/// <summary>
		/// Gets the video page details.
		/// </summary>
		/// <param name="videoId">The video id.</param>
		/// <returns>Video page details</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString=false)]
		public string GetVideoPageDetails(string videoId)
		{
			int videoID = 0;
			Video video = null;
			VideoModel videoModel = null;
			if (Int32.TryParse(videoId, out videoID))
			{
				video = ContentHelper.GetByNodeId<Video>(videoID);
				videoModel = new VideoModel(video);
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(videoModel);
		}

		/// <summary>
		/// Gets the video page comments.
		/// </summary>
		/// <param name="videoId">The video id.</param>
		/// <returns>List of the comments for video page</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public string GetVideoPageComments(string videoId)
		{
			List<Comment> comments = new List<Comment>();
			int videoID = 0;
			if (Int32.TryParse(videoId, out videoID))
			{
				Video video = ContentHelper.GetByNodeId<Video>(videoID);
				comments = ContentHelper.GetChildren<Comment>(videoID);
				comments = comments.OrderByDescending(c => c.CommentDate).ToList();
			}

			List<CommentModel> commentModels = new List<CommentModel>();
			foreach (Comment comment in comments)
			{
				commentModels.Add(new CommentModel(comment));
			}

			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(commentModels);
		}

		/// <summary>
		/// Gets the latest videos.
		/// </summary>
		/// <returns>List of latest videos</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public string GetLatestVideos()
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			List<Video> videos = NodeHelper.GetLatestVideos();
			videos = videos.OrderByDescending(v => v.VideoDate).Take(10).ToList();

			List<VideoModel> videoModels = new List<VideoModel>();
			foreach (Video video in videos)
			{
				videoModels.Add(new VideoModel(video));
			}

			return serializer.Serialize(videoModels);
		}

		/// <summary>
		/// Creates the comment.
		/// </summary>
		/// <param name="videoId">The video id.</param>
		/// <param name="text">The text.</param>
		/// <param name="name">The name.</param>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public void CreateComment(string videoId, string text, string name, string time)
		{
			int videoID = 0;
			if (Int32.TryParse(videoId, out videoID))
			{
				NodeHelper.CreateComment(videoID, text, name, time);
			}
		}

        /// <summary>
        /// Creates the video.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="link">The link.</param>
        /// <param name="categories">The categories.</param>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public void CreateVideo(string userId, string title, string text, string link, string categories)
		{
			int userID = 0;
			if (Int32.TryParse(userId, out userID))
			{
                NodeHelper.CreateVideo(userID, title, text, link, categories);
			}
		}

		/// <summary>
		/// Creates the user.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="lastName">The last name.</param>
		/// <param name="email">The email.</param>
		/// <param name="password">The password.</param>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public void CreateUser(string name, string lastName, string email, string password)
		{
			NodeHelper.CreateUser(name, lastName, email, password);
		}
		
		/// <summary>
		/// Gets the user page details.
		/// </summary>
		/// <param name="userId">The user id.</param>
		/// <returns></returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public string GetUserPageDetails(string userId)
		{
			int userID = 0;
			User user = null;
			if (Int32.TryParse(userId, out userID))
			{
				user = ContentHelper.GetByNodeId<User>(userID);
			}

			UserModel userModel = new UserModel(user);
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(userModel);
		}

		/// <summary>
		/// Gets the user videos.
		/// </summary>
		/// <param name="userId">The user id.</param>
		/// <param name="page">The page.</param>
		/// <returns>List of user videos</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public string GetUserVideos(string userId, string page)
		{
			int userID = 0;
			User user = null;
			List<Video> videos = new List<Video>();
			if (Int32.TryParse(userId, out userID))
			{
				user = ContentHelper.GetByNodeId<User>(userID);
				videos = ContentHelper.GetChildren<Video>(userID);
				videos = videos.OrderByDescending(v => v.VideoDate).ToList();
			}

			List<VideoModel> videoModels = new List<VideoModel>();
			foreach (Video video in videos)
			{
				videoModels.Add(new VideoModel(video));
			}

			int pageNumber = 0;
			VideoListModel videoListModel = new VideoListModel();
			if (Int32.TryParse(page, out pageNumber))
			{
				videoListModel.Videos = videoModels.Skip(9 * pageNumber).Take(9).ToList();
				videoListModel.HasMore = videoModels.Count > 9 * pageNumber + 9;
				videoListModel.TotalCount = videoModels.Count;
			}
			
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			return serializer.Serialize(videoListModel);
		}

        /// <summary>
        /// Searches the site.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <param name="page">The page.</param>
        /// <param name="categories">The categories.</param>
        /// <returns>List of video models</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public string SearchSite(string term, string page, string categories)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<VideoModel> videoModels = SearchHelper.SearchSite(term, categories);
			int pageNumber = 0;
			VideoListModel videoListModel = new VideoListModel();
			if (Int32.TryParse(page, out pageNumber))
			{
				videoListModel.Videos = videoModels.Skip(10 * pageNumber).Take(10).ToList();
				videoListModel.HasMore = videoModels.Count > 10 * pageNumber + 10;
				videoListModel.TotalCount = videoModels.Count;
			}

			return serializer.Serialize(videoListModel);
		}

        /// <summary>
        /// Searches the site preview.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <param name="categories">The categories.</param>
        /// <returns>List of video model</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public string SearchSitePreview(string term, string categories)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<VideoModel> videoModels = SearchHelper.SearchSite(term, categories);
			VideoListModel videoListModel = new VideoListModel();
			videoListModel.Videos = videoModels.Take(5).ToList();
			return serializer.Serialize(videoListModel);
		}

		/// <summary>
		/// Logins the specified email.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <param name="password">The password.</param>
		/// <returns>User model of logged in user</returns>
		[WebMethod]
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
		public string Login(string email, string password)
		{
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			UserModel user = NodeHelper.FindUser(email, password);
			return serializer.Serialize(user);
		}

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>All categories</returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public string GetAllCategories()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<CategoryModel> retVal = NodeHelper.GetAllCategories();

            return serializer.Serialize(retVal);
        }
	}
}
