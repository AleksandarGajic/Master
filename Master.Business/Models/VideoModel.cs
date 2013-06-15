//-----------------------------------------------------------------------
// <copyright file="VideoModel.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Models
{
	using System;

	using Master.Entities.DocumentTypes;

	using Vega.USiteBuilder;
	using Master.Business.Helpers;

	/// <summary>
	/// Video model class
	/// </summary>
	public class VideoModel : BaseModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VideoModel"/> class.
		/// </summary>
		/// <param name="videoPage">The video page.</param>
		public VideoModel(Video videoPage)
		{
			this.Id = videoPage.Id.ToString();
			this.Title = videoPage.Title;
			this.VideoLink = videoPage.VideoLink;
			this.VideoDate = videoPage.VideoDate;
			this.VideoDescription = videoPage.VideoDescription;
			this.VideoAuthor = new UserModel(ContentHelper.GetByNodeId<User>(videoPage.ParentId));
			this.SeoTitle = videoPage.Title;
			this.VideoImage = String.Empty;

			if (videoPage.VideoImage.HasValue)
			{
				this.VideoImage = MediaHelper.GetMediaUrlById(videoPage.VideoImage.Value);
			}
			if (videoPage.VideoLinkBO.HasValue)
			{
				this.VideoLink = MediaHelper.GetMediaUrlById(videoPage.VideoLinkBO.Value);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="VideoModel"/> class.
		/// </summary>
		public VideoModel()
		{
		}

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>The id.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the video link.
		/// </summary>
		/// <value>The video link.</value>
		public string VideoLink { get; set; }

		/// <summary>
		/// Gets or sets the video date.
		/// </summary>
		/// <value>The video date.</value>
		public DateTime VideoDate { get; set; }

		/// <summary>
		/// Gets or sets the video description.
		/// </summary>
		/// <value>The video description.</value>
		public string VideoDescription { get; set; }

		/// <summary>
		/// Gets or sets the video author.
		/// </summary>
		/// <value>The video author.</value>
		public UserModel VideoAuthor { get; set; }

		/// <summary>
		/// Gets or sets the video image.
		/// </summary>
		/// <value>The video image.</value>
		public string VideoImage { get; set; }
	}
}
