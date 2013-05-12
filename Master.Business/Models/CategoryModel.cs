//-----------------------------------------------------------------------
// <copyright file="CategoryModel.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Models
{
	using System;

	using Master.Entities.DocumentTypes;

	using Vega.USiteBuilder;

	/// <summary>
    /// Category model class
	/// </summary>
	public class CategoryModel : BaseModel
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryModel"/> class.
        /// </summary>
        /// <param name="categoryPage">The category page.</param>
		public CategoryModel(Category categoryPage)
		{
            this.Id = categoryPage.Id.ToString();
            this.Title = categoryPage.Title;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="VideoModel"/> class.
		/// </summary>
        public CategoryModel()
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
	}
}
