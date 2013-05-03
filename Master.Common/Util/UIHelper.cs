//-----------------------------------------------------------------------
// <copyright file="UIHelper.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Common.Util
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.HtmlControls;
	using System.Web.UI.WebControls;

	using Master.Common;

	/// <summary>
	/// Provides methods for UI.
	/// </summary>
	public static class UIHelper
	{
		#region [PublicMethods]
		/// <summary>
		/// Adds the CSS class.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="classNameToAdd">The class name to add.</param>
		public static void AddCssClass(Control control, string classNameToAdd)
		{
			string cssClasses;
			if (control is HtmlControl)
			{
				cssClasses = ((HtmlControl)control).Attributes[Constants.HtmlAttributes.Class];
			}
			else if (control is WebControl)
			{
				cssClasses = ((WebControl)control).CssClass;
			}
			else
			{
				throw new NotSupportedException("Type '" + control.GetType() + "' is not supported!");
			}

			if (String.IsNullOrEmpty(cssClasses))
			{
				cssClasses = String.Empty;
			}

			cssClasses += " " + classNameToAdd;
			if (control is HtmlControl)
			{
				((HtmlControl)control).Attributes[Constants.HtmlAttributes.Class] = cssClasses;
			}
			else if (control is WebControl)
			{
				((WebControl)control).CssClass = cssClasses;
			}
		}

		/// <summary>
		/// Replaces the quotes.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>string with changed quotes</returns>
		public static string ReplaceQuotes(string input)
		{
			return input.Replace("'", "\\'");
		}

		/// <summary>
		/// Inserts or updates the querry parameter in URL.
		/// </summary>
		/// <param name="originalUrl">The URL parameter.</param>
		/// <param name="paramName">Name of the param.</param>
		/// <param name="paramValue">The param value.</param>
		/// <returns>Url with query parameter.</returns>
		public static string SetQuerryParameter(string originalUrl, string paramName, string paramValue)
		{
			string retVal = originalUrl;

			List<string> keyValuePairs = new List<string>();

			for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
			{
				if (HttpContext.Current.Request.QueryString.Keys[i].Equals(paramName))
				{
					keyValuePairs.Add(string.Format("{0}={1}", paramName, paramValue));
				}
				else
				{
					keyValuePairs.Add(string.Format("{0}={1}", HttpContext.Current.Request.QueryString.Keys[i], HttpContext.Current.Request.QueryString[i]));
				}
			}

			if (string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[paramName]))
			{
				keyValuePairs.Add(string.Format("{0}={1}", paramName, paramValue));
			}

			for (int i = 0; i < keyValuePairs.Count; i++)
			{
				if (i == 0)
				{
					retVal += "?" + keyValuePairs[i];
				}
				else
				{
					retVal += "&" + keyValuePairs[i];
				}
			}

			return retVal;
		}

		/// <summary>
		/// Adds the inline style.
		/// </summary>
		/// <param name="control">The control.</param>
		/// <param name="attribName">Name of the attrib.</param>
		/// <param name="attribValue">The attrib value.</param>
		public static void AddInlineStyle(HtmlControl control, string attribName, string attribValue)
		{
			string styles = control.Attributes[Constants.HtmlAttributes.Style];
			string newStyle = attribName + ":" + attribValue;
			if (!String.IsNullOrEmpty(styles))
			{
				styles += " ;" + newStyle;
			}
			else
			{
				styles = newStyle;
			}

			control.Attributes[Constants.HtmlAttributes.Style] = styles;
		}

		/// <summary>
		/// Gets the shorter text.
		/// </summary>
		/// <param name="text">The text that need to be smaller.</param>
		/// <param name="numberOfChars">The number of chars.</param>
		/// <returns>Substring of text if text lenght is grater that numberOfChars, otherwise returns text.</returns>
		public static string GetShorterText(string text, int numberOfChars)
		{
			if (text.Length > numberOfChars)
			{
				string retVal = String.Empty;
				List<string> values = new List<string>();
				values = text.Split(' ').ToList();

				for (int i = 0; i < values.Count; i++)
				{
					if (retVal.Length + values[i].Length < numberOfChars)
					{
						retVal += " " + values[i];
					}
					else
					{
						break;
					}
				}

				return retVal + " ...";
			}
			else
			{
				return text;
			}
		}

		/// <summary>
		/// Inserts or updates the querry parameter in absolutePath.
		/// </summary>
		/// <param name="absolutePath">The absolute path.</param>
		/// <param name="paramName">Name of the parameter.</param>
		/// <param name="paramValue">The parameter value.</param>
		/// <returns>Url with query parameter.</returns>
		public static string SetQuerryParameterInAbsolutePath(string absolutePath, string paramName, string paramValue)
		{
			string retVal = absolutePath.Split('?')[0];

			List<string> keyValuePairs = new List<string>();

			string queryParams = absolutePath.Substring(absolutePath.LastIndexOf('?') + 1);
			if (queryParams != absolutePath)
			{
				string[] paramKey = queryParams.Split('&');
				int j = 0;
				bool isInQuery = false;
				for (int i = 0; i < paramKey.Length; i++)
				{
					retVal += j < 1 ? "?" : "&";
					j++;
					if (paramKey[i].Split('=')[0] == paramName)
					{
						retVal += paramKey[i].Split('=')[0] + "=" + paramValue;
						isInQuery = true;
					}
					else
					{
						retVal += paramKey[i];
					}
				}

				if (!isInQuery)
				{
					retVal += "&" + paramName + "=" + paramValue;
				}
			}
			else
			{
				retVal += "?" + paramName + "=" + paramValue;
			}

			return retVal;
		}

		/// <summary>
		/// Gets the thumb image URL from large picture url.
		/// </summary>
		/// <param name="url">The URL of large image.</param>
		/// <returns>Returnts thumbnail image url from Media folder.</returns>
		public static string GetThumbImageUrl(string url)
		{
			string retVal = String.Empty;
			int dotPosition = url.LastIndexOf('.');
			retVal = url.Insert(dotPosition, "_thumb");
			return retVal;
		}

		/// <summary>
		/// Gets the parameter value.
		/// </summary>
		/// <param name="paramName">Name of the param.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>If exist returns query strin parameter, otherwise returns default value.</returns>
		public static string GetParameterValue(string paramName, string defaultValue)
		{
			string retVal = defaultValue;

			if (!String.IsNullOrEmpty(HttpContext.Current.Request[paramName]))
			{
				retVal = HttpContext.Current.Request[paramName];
			}

			return retVal;
		}

		/// <summary>
		/// Appends the request parameter.
		/// </summary>
		/// <param name="originalUrl">The original URL.</param>
		/// <param name="paramName">Name of the param.</param>
		/// <param name="paramValue">The param value.</param>
		/// <returns>Original url appended with request parameter.</returns>
		public static string AppendRequestParameter(string originalUrl, string paramName, string paramValue)
		{
			StringBuilder retVal = new StringBuilder(originalUrl);

			string separator = "?";
			if (originalUrl.Contains("?"))
			{
				separator = "&";
			}

			retVal.Append(separator);
			retVal.Append(paramName);
			retVal.Append("=");
			paramValue = HttpUtility.UrlEncode(paramValue);
			retVal.Append(paramValue);

			return retVal.ToString();
		}

		#region [IsIPad]
		/// <summary>
		/// Determines whether user agants contains iPad.
		/// </summary>
		/// <returns>
		/// <c>true</c> if iPad; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsIPad()
		{
			return HttpContext.Current.Request.UserAgent.ToLower().Contains("ipad");
		}
		#endregion

		#region [CookieMethos]
		/// <summary>
		/// Adds the article id to visited articles.
		/// </summary>
		/// <param name="articleId">The article id.</param>
		public static void AddArticleIdToVisitedArticles(int articleId)
		{
			HttpCookie currentCookie = HttpContext.Current.Request.Cookies[Constants.CookieNames.VisitedArticles];

			DateTime now = DateTime.Now;
			DateTime expireDate = now.AddHours(2);

			if (currentCookie == null)
			{
				HttpCookie newCookie = new HttpCookie(Constants.CookieNames.VisitedArticles, articleId.ToString());
				newCookie.Expires = expireDate;
				HttpContext.Current.Response.Cookies.Add(newCookie);
			}
			else
			{
				StringBuilder value = new StringBuilder();
				value.Append(currentCookie.Value);
				value.Append(",");
				value.Append(articleId.ToString());

				HttpContext.Current.Response.Cookies[Constants.CookieNames.VisitedArticles].Value = value.ToString();
				HttpContext.Current.Response.Cookies[Constants.CookieNames.VisitedArticles].Expires = expireDate;
			}
		}

		/// <summary>
		/// Determines whether articleId is in visited articles Ids.
		/// </summary>
		/// <param name="articleId">The article id.</param>
		/// <returns>
		/// <c>true</c> if [is article id] is in visited articles; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsArticleIdInVisitedArticles(int articleId)
		{
			bool retVal = false;

			HttpCookie currentCookie = HttpContext.Current.Request.Cookies[Constants.CookieNames.VisitedArticles];
			if (currentCookie != null && !String.IsNullOrEmpty(currentCookie.Value))
			{
				string[] visitedArticlesId = currentCookie.Value.Split(',');
				string currentId = articleId.ToString();
				for (int i = 0; i < visitedArticlesId.Length; i++)
				{
					if (visitedArticlesId[i].Equals(currentId))
					{
						retVal = true;
						break;
					}
				}
			}

			return retVal;
		}

		#endregion
		#endregion

		/// <summary>
		/// This method will prepare a value from rich text field to be shown on front-end.
		/// It will remove tilda ("~") character from all img tags and its "src" attribute.
		/// </summary>
		/// <param name="fieldValue">Value from a rich text field.</param>
		/// <returns>Returns processed value ready to be outputted to front-end.</returns>
		public static string ProcessRichTextField(string fieldValue)
		{
			return fieldValue.Replace("src=\"~/", "src=\"/");
		}
	}
}
