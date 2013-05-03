//-----------------------------------------------------------------------
// <copyright file="MediaHelper.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Business.Helpers
{
	using System;
	using System.Xml.XPath;

	/// <summary>
	/// Provide methods for media.
	/// </summary>
	public static class MediaHelper
	{
		/// <summary>
		/// Gets the media URL by id.
		/// </summary>
		/// <param name="mediaId">The media id.</param>
		/// <returns>Media node id.</returns>
		public static string GetMediaUrlById(int mediaId)
		{
			string retVal = String.Empty;
			try
			{
				XPathNodeIterator xpathNodeIterator = umbraco.library.GetMedia(mediaId, false);
				if (xpathNodeIterator != null && mediaId != 0)
				{
					xpathNodeIterator.MoveNext();
					retVal = xpathNodeIterator.Current.SelectSingleNode("umbracoFile").Value;
				}
			}
			catch
			{
			}

			return retVal;
		}

		/// <summary>
		/// Gets the crop media URL by id.
		/// </summary>
		/// <param name="mediaId">The media id.</param>
		/// <param name="cropName">Name of the crop.</param>
		/// <returns>Url to the image from crop</returns>
		public static string GetCropMediaUrlById(int mediaId, string cropName)
		{
			string retVal = String.Empty;
			try
			{
				XPathNodeIterator xpathNodeIterator = umbraco.library.GetMedia(mediaId, false);
				if (xpathNodeIterator != null && mediaId != 0)
				{
					xpathNodeIterator.MoveNext();
					retVal = xpathNodeIterator.Current.SelectSingleNode("umbracoFile").Value;
					retVal = retVal.Substring(0, retVal.LastIndexOf('.'));
					retVal = retVal + "_" + cropName + ".jpg";
				}
			}
			catch
			{
			}

			return retVal;
		}
	}
}
