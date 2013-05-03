//-----------------------------------------------------------------------
// <copyright file="Footer.ascx.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Web.usercontrols
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using Vega.USiteBuilder;

	/// <summary>
	/// Footer template
	/// </summary>
	public partial class Footer : Vega.USiteBuilder.WebUserControlBase<Master.Entities.DocumentTypes.Base>
	{
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}
