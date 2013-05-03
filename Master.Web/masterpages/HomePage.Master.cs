//-----------------------------------------------------------------------
// <copyright file="HomePage.Master.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Web.Masterpages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Linq;

    using Vega.USiteBuilder;

    /// <summary>
    /// Home Page template.
    /// </summary>
    public partial class HomePage : Vega.USiteBuilder.TemplateBase<Master.Entities.DocumentTypes.Home>
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
