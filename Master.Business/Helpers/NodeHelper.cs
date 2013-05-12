//-----------------------------------------------------------------------
// <copyright file="NodeHelper.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Master.Business.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Security.Cryptography;
	using System.Text;
	using Master.Business.Models;
	using Master.Entities.DocumentTypes;
	using umbraco.cms.businesslogic.web;
	using Vega.USiteBuilder;

    /// <summary>
    /// Provides methods to work with content nodes.
    /// </summary>
	public static class NodeHelper
	{
		#region [Pages]
		/// <summary>
		/// Finds the user.
		/// </summary>
		/// <param name="email">The email.</param>
		/// <param name="password">The password.</param>
		/// <returns>Return UserModel if it is founded</returns>
		public static UserModel FindUser(string email, string password)
		{
			List<User> users = ContentHelper.GetChildren<User>(1048);
			UserModel foundUser = null;
			password = NodeHelper.CalculateMD5Hash(password);
			foreach (User user in users)
			{
				if (user.Email.Equals(email) && user.Password.Equals(password))
				{
					foundUser = new UserModel(user);
					break;
				}
			}

			return foundUser;
		}

		/// <summary>
		/// Calculates the M d5 hash.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>MD5 hash value</returns>
		public static string CalculateMD5Hash(string input)
		{
			// step 1, calculate MD5 hash from input
			MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}

			return sb.ToString();
		}
		/// <summary>
		/// Gets the Home node.
		/// </summary>
		/// <returns>Instance of <see cref="Home"/> document type.</returns>
		public static DocumentTypeBase GetPageByNodeId(int nodeId)
		{

			DocumentTypeBase retVal = null;
			try
			{
				retVal = ContentHelper.GetByNodeId(nodeId);
			}
			catch (Exception e)
			{
			}

			return retVal;
		}

		/// <summary>
		/// Gets the latest videos.
		/// </summary>
		/// <returns></returns>
		public static List<Video> GetLatestVideos()
		{
			List<Video> retVal = new List<Video>();
			Home home = (Home)NodeHelper.GetPageByNodeId(1048);
			List<User> users = ContentHelper.GetChildren<User>(home.Id);
			foreach (User user in users)
			{
				retVal.AddRange(ContentHelper.GetChildren<Video>(user.Id));
			}

			return retVal;
		}

		/// <summary>
		/// Creates the comment.
		/// </summary>
		/// <param name="parentId">The parent id.</param>
		/// <param name="text">The text.</param>
		/// <param name="name">The name.</param>
		public static void CreateComment(int parentId, string text, string name)
		{
			DocumentType comment = DocumentType.GetByAlias("Comment");
			umbraco.BusinessLogic.User author = umbraco.BusinessLogic.User.GetUser(0);
			Document doc = Document.MakeNew("Comment", comment, author, parentId);
			doc.getProperty("title").Value = "Comment";
			doc.getProperty("commentText").Value = text;
			doc.getProperty("nameOfAuthor").Value = name;
			doc.getProperty("commentDate").Value = DateTime.Now;

			doc.Publish(author);
			umbraco.library.UpdateDocumentCache(doc.Id);
			doc.Save();
		}

        /// <summary>
        /// Creates the video.
        /// </summary>
        /// <param name="parentId">The parent id.</param>
        /// <param name="title">The title.</param>
        /// <param name="text">The text.</param>
        /// <param name="link">The link.</param>
        /// <param name="categories">The categories.</param>
        public static void CreateVideo(int parentId, string title, string text, string link, string categories)
		{
			DocumentType comment = DocumentType.GetByAlias("Video");
			umbraco.BusinessLogic.User author = umbraco.BusinessLogic.User.GetUser(0);
			Document doc = Document.MakeNew(title, comment, author, parentId);
			doc.getProperty("title").Value = title;
			doc.getProperty("videoDescription").Value = text;
			doc.getProperty("videoLink").Value = link;
			doc.getProperty("videoDate").Value = DateTime.Now;
            doc.getProperty("categories").Value = categories.Replace(',',' ');

			doc.Publish(author);
			umbraco.library.UpdateDocumentCache(doc.Id);
			doc.Save();
		}

		/// <summary>
		/// Creates the user.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="text">The text.</param>
		/// <param name="link">The link.</param>
		public static void CreateUser(string name, string lastName, string email, string password)
		{
			DocumentType comment = DocumentType.GetByAlias("User");
			string title = name + " " + lastName;
			umbraco.BusinessLogic.User author = umbraco.BusinessLogic.User.GetUser(0);
			Document doc = Document.MakeNew(title, comment, author, 1048);
			doc.getProperty("title").Value = title;
			doc.getProperty("password").Value = NodeHelper.CalculateMD5Hash(password);
			doc.getProperty("name").Value = name;
			doc.getProperty("lastName").Value = lastName;
			doc.getProperty("email").Value = email;

			doc.Publish(author);
			umbraco.library.UpdateDocumentCache(doc.Id);
			doc.Save();
		}

		/// <summary>
		/// Gets the name of the video author.
		/// </summary>
		/// <param name="video">The video.</param>
		public static UserModel GetVideoAuthorName(Video video)
		{
			UserModel userModel = new UserModel();
			string retVal = String.Empty;
			User user = ContentHelper.GetByNodeId<User>(video.ParentId);
			userModel.Name = user.Name;
			userModel.LastName = user.LastName;
			userModel.Id = user.Id.ToString();

			return userModel;
		}

        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <returns>List of all categories</returns>
        public static List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> retVal = new List<CategoryModel>();
            List<Category> categories = ContentHelper.GetChildren<Category>(1213);
            foreach (Category category in categories)
            {
                retVal.Add(new CategoryModel(category));
            }

            return retVal;
        }

		/// <summary>
		/// Gets the milliseconds.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <returns>Time in milliseconds from 1970.1.1.</returns>
		public static string GetMilliseconds(DateTime time)
		{
			DateTime dt1970 = new DateTime(1970, 1, 1);
			DateTime current = DateTime.Now;
			TimeSpan span = current - dt1970;
			return Math.Floor(span.TotalMilliseconds).ToString();
		}
		#endregion
	}
}
