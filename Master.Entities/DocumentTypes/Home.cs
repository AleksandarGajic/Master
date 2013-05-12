//-----------------------------------------------------------------------
// <copyright file="Home.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{
	using System.Collections.Generic;

	using Vega.USiteBuilder;
	using Vega.USiteBuilder.Types;

	/// <summary>
	/// This class is base for all content pages.
	/// </summary>
	[DocumentType(IconUrl = "house.png",
		AllowedChildNodeTypes = new[] { typeof(User), typeof(CategoriesContainer)},
		Description = "Home page.")]
	public class Home : Base
	{
	}
}
