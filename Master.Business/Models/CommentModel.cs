//-----------------------------------------------------------------------
// <copyright file="CommentModel.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Models
{
	using System;

	using Master.Entities.DocumentTypes;

	/// <summary>
	/// Video model class
	/// </summary>
	public class CommentModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommentModel"/> class.
		/// </summary>
		/// <param name="commentPage">The comment page.</param>
		public CommentModel(Comment commentPage)
		{
			this.NameOfAuthor = commentPage.NameOfAuthor;
			this.CommentText = commentPage.CommentText;
			this.CommentDate = commentPage.CommentDate;
		}

		/// <summary>
		/// Gets or sets the name of author.
		/// </summary>
		/// <value>The name of author.</value>
		public string NameOfAuthor { get; set; }

		/// <summary>
		/// Gets or sets the comment text.
		/// </summary>
		/// <value>The comment text.</value>
		public string CommentText { get; set; }

		/// <summary>
		/// Gets or sets the comment date.
		/// </summary>
		/// <value>The comment date.</value>
		public DateTime CommentDate { get; set; }	
	}
}
