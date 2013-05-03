//-----------------------------------------------------------------------
// <copyright file="Video.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{

	using System;

	using Master.Common;

	using Vega.USiteBuilder;

	/// <summary>
	/// This class is Video for all video pages.
	/// </summary>
	[DocumentType(IconUrl = "camera.png",
		AllowedChildNodeTypes = new[] { typeof(Comment) },
		Description = "Video page.")]
	public class Video : Base
	{
		#region [Content]
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[DocumentTypeProperty(UmbracoPropertyType.TextboxMultiple,
			  Tab = Constants.TabNames.Content,
			  Name = "VideoDescription",
			  Description = "Description",
			  Mandatory = true)]
		public string VideoDescription { get; set; }

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		[DocumentTypeProperty(UmbracoPropertyType.DatePicker,
							  Tab = Constants.TabNames.Content,
							  Name = "VideoDate",
							  Description = "Date.",
							  Mandatory = true)]
		public DateTime VideoDate { get; set; }

		/// <summary>
		/// Gets or sets the video link.
		/// </summary>
		/// <value>The video link.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Tab = Constants.TabNames.Content,
							  Name = "Video Link",
							  Description = "Video Link.")]
		public string VideoLink { get; set; }
		#endregion
	}
}
