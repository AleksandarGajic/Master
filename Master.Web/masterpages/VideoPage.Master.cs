//-----------------------------------------------------------------------
// <copyright file="VideoPage.Master.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Web.masterpages
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using umbraco.BusinessLogic;
	using umbraco.cms.businesslogic.web;
	using Master.Entities.DocumentTypes;
	using Vega.USiteBuilder;
	using Master.Business.Helpers;

	/// <summary>
	/// Video page template
	/// </summary>
	public partial class VideoPage : Vega.USiteBuilder.TemplateBase<Master.Entities.DocumentTypes.Video>
	{
		#region [Members]
		/// <summary>
		/// Private property for link url
		/// </summary>
		private string _linkUrl;

		/// <summary>
		/// Gets or sets the link URL.
		/// </summary>
		/// <value>The link URL.</value>
		public string LinkUrl
		{
			get { return this._linkUrl; }
			set { this._linkUrl = value; }
		}

		#endregion
		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			string friendlyLink = "http://www.youtube.com/v/" + this.CurrentContent.VideoLink.Split('=')[1] + "?autohide=1&version=3&autoplay=1";
			//http://vimeo.com/moogaloop.swf?clip_id=61487989&amp;autoplay=1"
			string script = String.Format("var videoLink = '{0}'", friendlyLink);
			ScriptManager.RegisterStartupScript(this, this.GetType(), "VideoJSDefinitions", script, true);
			this.btnPostComment.Click += new EventHandler(this.BtnPostCommentClick);
			this.InitComments();
		}

		/// <summary>
		/// Inits the comments.
		/// </summary>
		private void InitComments()
		{
			List<Comment> comments = this.CurrentContent.GetChildren<Comment>(true);
			rptComment.DataSource = comments;
			rptComment.ItemDataBound += new RepeaterItemEventHandler(this.RptCommentItemDataBound);
			rptComment.DataBind();
		}

		/// <summary>
		/// RPTs the comment item data bound.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> instance containing the event data.</param>
		private void RptCommentItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			Comment comment = (Comment)e.Item.DataItem;
			if (comment != null)
			{
				Literal litCommentTime = (Literal)e.Item.FindControl("litCommentTime");
				Literal litCommentText = (Literal)e.Item.FindControl("litCommentText");

				litCommentText.Text = comment.CommentText;
				litCommentTime.Text = comment.CommentDate.ToString();
			}
		}

		/// <summary>
		/// BTNs the post comment click.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void BtnPostCommentClick(object sender, EventArgs e)
		{
			DocumentType comment = DocumentType.GetByAlias("Comment");
			umbraco.BusinessLogic.User author = umbraco.BusinessLogic.User.GetUser(0);
			Document doc = Document.MakeNew("Comment", comment, author, this.CurrentContent.Id);
			doc.getProperty("title").Value = "Comment";
			doc.getProperty("commentText").Value = this.tbxComment.Text;
			doc.getProperty("commentAuthor").Value = 1054;
			doc.getProperty("commentDate").Value = DateTime.Now;
			this.tbxComment.Text = String.Empty;
				
			doc.Publish(author);
			umbraco.library.UpdateDocumentCache(doc.Id);
			doc.Save();

			this.InitComments();
		}
	}
}