//-----------------------------------------------------------------------
// <copyright file="Commentome.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{

	using System;

	using Master.Common;

	using Vega.USiteBuilder;

	/// <summary>
	/// This class is Comment for all comments.
	/// </summary>
	[DocumentType(IconUrl = "comments.png",
		AllowedChildNodeTypes = new[] { typeof(Comment) },
		Description = "Comment page.")]
	public class Comment : Base
	{
		#region
		/// <summary>
		/// Gets or sets the name of author.
		/// </summary>
		/// <value>The name of author.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
					  Tab = Constants.TabNames.Content,
					  Name = "NameOfAuthor",
					  Description = "NameOfAuthor",
					  Mandatory = false)]
		public string NameOfAuthor { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[DocumentTypeProperty(UmbracoPropertyType.TextboxMultiple,
					  Tab = Constants.TabNames.Content,
					  Name = "CommentText",
					  Description = "Comment",
					  Mandatory = true)]
		public string CommentText { get; set; }

		/// <summary>
		/// Gets or sets the video time.
		/// </summary>
		/// <value>The video time.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Numeric,
					  Tab = Constants.TabNames.Content,
					  Name = "VideoTime",
					  Description = "VideoTime",
					  Mandatory = false)]
		public int VideoTime { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[DocumentTypeProperty(UmbracoPropertyType.DatePicker,
			  Tab = Constants.TabNames.Content,
			  Name = "CommentDate",
			  Description = "Date when the comment was posted",
			  Mandatory = true)]
		public DateTime CommentDate { get; set; }
		#endregion
	}
}
