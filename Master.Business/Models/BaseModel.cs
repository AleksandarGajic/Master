//-----------------------------------------------------------------------
// <copyright file="BaseModel.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Models
{
	using System;

	using Master.Entities.DocumentTypes;

	/// <summary>
	/// Base model class
	/// </summary>
	public class BaseModel
	{
		/// <summary>
		/// Gets or sets the seo title.
		/// </summary>
		/// <value>The seo title.</value>
		public string SeoTitle { get; set; }
	}
}
