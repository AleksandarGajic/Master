//-----------------------------------------------------------------------
// <copyright file="Page.Master.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Web.Masterpages
{
    using System;

	/// <summary>
    /// Page master page.
    /// </summary>
    public partial class Page : Vega.USiteBuilder.TemplateBase<Master.Entities.DocumentTypes.Base>
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
