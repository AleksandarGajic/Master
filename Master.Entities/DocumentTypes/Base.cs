//-----------------------------------------------------------------------
// <copyright file="Base.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{
	using Vega.USiteBuilder;

	using Master.Common;

	/// <summary>
	/// Main document type
	/// </summary>
	[DocumentType(IconUrl = "doc4.gif", Description = "This is base document type for all document types.")]
	public class Base : Vega.USiteBuilder.DocumentTypeBase
	{
		#region [Page]
		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Tab = Constants.TabNames.Page,
							  Name = "Title",
							  Description = "Title",
							  Mandatory = true)]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the page title.
		/// </summary>
		/// <value>The page title.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Name = "SEO-Title",
							  Tab = Constants.TabNames.Page,
							  Description = "Page title in meta tag.")]
		public string SeoTitle { get; set; }

		/// <summary>
		/// Gets or sets the page keywords.
		/// </summary>
		/// <value>The page keywords.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Name = "SEO-Keywords",
							  Tab = Constants.TabNames.Page,
							  Description = "Page keywords in meta tag.")]
		public string SeoKeywords { get; set; }

		/// <summary>
		/// Gets or sets the page description.
		/// </summary>
		/// <value>The page description.</value>
		[DocumentTypeProperty(UmbracoPropertyType.TextboxMultiple,
							  Name = "SEO-Description",
							  Tab = Constants.TabNames.Page,
							  Description = "Page description in meta tag.")]
		public string SeoDescription { get; set; }

		/// <summary>
		/// Gets or sets the page author.
		/// </summary>
		/// <value>The page author.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Name = "SEO-Author",
							  Tab = Constants.TabNames.Page,
							  Description = "Page author in meta tag.")]
		public string SeoAuthor { get; set; }
		#endregion

		#region [Umbraco]
		/// <summary>
		/// Gets or sets a value indicating whether should be hidden in navigation or not.
		/// </summary>
		/// <value><c>true</c> if node is hidden in navigation; otherwise, <c>false</c>.</value>
		[DocumentTypeProperty(UmbracoPropertyType.TrueFalse,
							  Name = "Umbraco Navigation Hide",
							  Description = "This 'True/False' property will hide pages from the navigation when they are set to true")]
		public bool UmbracoNaviHide { get; set; }

		/// <summary>
		/// Gets or sets the umbraco redirect page.
		/// </summary>
		/// <value>The umbraco redirect page id.</value>
		[DocumentTypeProperty(UmbracoPropertyType.ContentPicker,
							  Name = "Umbraco Redirect",
							  Description = "Choose a node ID that you want the page to redirect to.")]
		public int? UmbracoRedirect { get; set; }

		/// <summary>
		/// Gets or sets the name of the umbraco URL.
		/// </summary>
		/// <value>The name of the umbraco URL.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Name = "Umbraco Url Name",
							  Description = "This property allows you to change the URL of the node without changing the name of the node/page you have created.")]
		public string UmbracoUrlName { get; set; }

		/// <summary>
		/// Gets or sets the umbraco URL alias.
		/// </summary>
		/// <value>The umbraco URL alias.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
							  Name = "Umbraco Url Alias",
							  Description = "This property allows you to give the node multiple URLs using a textstring property.")]
		public string UmbracoUrlAlias { get; set; }
		#endregion
	}
}
