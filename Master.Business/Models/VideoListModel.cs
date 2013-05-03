//-----------------------------------------------------------------------
// <copyright file="VideoListModel.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Models
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Video list model class
	/// </summary>
	public class VideoListModel
	{
		/// <summary>
		/// Gets or sets the videos.
		/// </summary>
		/// <value>The videos.</value>
		public List<VideoModel> Videos { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has more.
		/// </summary>
		/// <value><c>true</c> if this instance has more; otherwise, <c>false</c>.</value>
		public bool HasMore { get; set; }

		/// <summary>
		/// Gets or sets the total count.
		/// </summary>
		/// <value>The total count.</value>
		public int TotalCount { get; set; }
	}
}
