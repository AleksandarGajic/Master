//-----------------------------------------------------------------------
// <copyright file="UserModel.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Models
{
	using System;
	using Master.Entities.DocumentTypes;

	/// <summary>
	/// User model class
	/// </summary>
	public class UserModel : BaseModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserModel"/> class.
		/// </summary>
		/// <param name="userPage">The user page.</param>
		public UserModel(User userPage)
		{
			this.Id = userPage.Id.ToString();
			this.Name = userPage.Name;
			this.LastName = userPage.LastName;
			this.SeoTitle = userPage.Name + " " + userPage.LastName;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UserModel"/> class.
		/// </summary>
		public UserModel()
		{
		}

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>The id.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }


		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>The last name.</value>
		public string LastName { get; set; }
	}
}
