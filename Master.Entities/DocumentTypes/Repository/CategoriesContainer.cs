//-----------------------------------------------------------------------
// <copyright file="CategoriesContainer.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{
	using System.Collections.Generic;

	using Vega.USiteBuilder;
	using Vega.USiteBuilder.Types;

	/// <summary>
    /// This class is "Categories Container for all category pages.
	/// </summary>
    [DocumentType(IconUrl = "chart_organisation.png",
		AllowedChildNodeTypes = new[] { typeof(Category)},
        Description = "Categories Container.")]
    public class CategoriesContainer : Base
	{
	}
}
