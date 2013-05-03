//-----------------------------------------------------------------------
// <copyright file="User.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Entities.DocumentTypes
{
	using System.Collections.Generic;

	using Vega.USiteBuilder;
	using Vega.USiteBuilder.Types;
	using Master.Common;

	/// <summary>
	/// This class is user class for all users.
	/// </summary>
	[DocumentType(IconUrl = "member.gif",
		AllowedChildNodeTypes = new[] { typeof(Video) },
		Description = "User page.")]
	public class User : Base
	{
		#region [Content]
		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
					  Tab = Constants.TabNames.Content,
					  Name = "Password",
					  Description = "Password",
					  Mandatory = true)]
		public string Password { get; set; }
		#endregion

		#region [Page]
		/// <summary>
		/// Name of this content item.
		/// </summary>
		/// <value></value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
					  Tab = Constants.TabNames.Content,
					  Name = "Name",
					  Description = "Name",
					  Mandatory = true)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>The last name.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
					  Tab = Constants.TabNames.Content,
					  Name = "Last Name",
					  Description = "Last Name",
					  Mandatory = true)]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		[DocumentTypeProperty(UmbracoPropertyType.Textstring,
					  Tab = Constants.TabNames.Content,
					  Name = "Email",
					  Description = "Email",
					  Mandatory = true)]
		public string Email { get; set; }
		#endregion
	}
}
