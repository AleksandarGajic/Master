//-----------------------------------------------------------------------
// <copyright file="Category.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{
	using System.Collections.Generic;

	using Vega.USiteBuilder;
	using Vega.USiteBuilder.Types;

	/// <summary>
	/// This class is category for category pages.
	/// </summary>
    [DocumentType(IconUrl = "chart_organisation.png",
		AllowedChildNodeTypes = new[] { typeof(User)},
        Description = "Category.")]
    public class Category : Base
	{
	}
}
