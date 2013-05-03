//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="FTN">
//     Copyright (c) FTN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Master.Common
{
	/// <summary>
	/// Represents class with constants that are used in
	/// F web application.
	/// </summary>
	public static class Constants
	{
		#region [NumberOfItems]

		/// <summary>
		/// Image of black arrow for links
		/// </summary>
		public const string LinkArrowBlack = "<img align=\"absmiddle\" alt=\"arrow_right_black\" src=\"/img/arrow_right_black.png\" class=\"inline\"/>";

		/// <summary>
		/// Image of white arrow for links
		/// </summary>
		public const string LinkArrowWhite = "<img align=\"absmiddle\" alt=\"arrow_right_black\" src=\"/img/arrow_right_white.png\" class=\"inline\"/>";

		/// <summary>
		/// Image of red arrow for links
		/// </summary>
		public const string LinkArrowRed = "<img class=\"inline\" alt=\"arrow_right_red\" src=\"/img/arrow_right_red.png\" align=\"absmiddle\"/>";

		/// <summary>
		/// Image of green arrow for links
		/// </summary>
		public const string LinkArrowGreen = "<img class=\"inline\" alt=\"arrow_right_green\" src=\"/img/arrow_right_green.png\" align=\"absmiddle\"/>";

		/// <summary>
		/// Number of persons per colum on persons list page.
		/// </summary>
		public const int NumberOfPersonsPerPage = 16;

		/// <summary>
		/// Number of activities per company
		/// </summary>
		public const int NumberOfActivitiesPerCompany = 1;

		/// <summary>
		/// Number of Images per colum on Large Gallert List item page.
		/// </summary>
		public const int NumberOfImagesPerPage = 16;

		/// <summary>
		/// Number of LargeGalleryListItems per page.
		/// </summary>
		public const int NumberOfLargeGalleryListItemsPerPage = 6;

		/// <summary>
		/// Number of contributors in ContributorListControl.
		/// </summary>
		public const int NumberContributorsPerControl = 8;

		/// <summary>
		/// Numbers of links per column in sitemap.
		/// </summary>
		public const int NumberOfItemsPerColumnInSitemap = 10;

		/// <summary>
		/// Number of themes visible on Themes page.
		/// </summary>
		public const int NumberOfThemesPerPage = 10;

		/// <summary>
		/// Number of activities visible on Home page.
		/// </summary>
		public const int NumberOfActivitiesPerPage = 5;

		/// <summary>
		/// Number of news visible on Home page.
		/// </summary>
		public const int NumberOfNewsPerPage = 5;

		/// <summary>
		/// Number of Tags visible in Tags box in right column on Themes and Theme pages.
		/// </summary>
		public const int NumberOfTagsOnControl = 16;

		/// <summary>
		/// Number of items shown in theme search control (ThemeSearchControl)
		/// </summary>
		public const int MaxNumberOfItemsInThemeSearchControl = 8;

		/// <summary>
		/// Max number of characters in Theme and Article titles on ThemeSearchControl.
		/// </summary>
		public const int SerachThemeControlMaxTextLenght = 18;

		/// <summary>
		/// Number of articles on MostReadArticlesControl.
		/// </summary>
		public const int NumberOfMostReadArticlesOnControl = 4;

		/// <summary>
		/// Number of characters for description.
		/// </summary>
		public const int NumberOfCharactersForDescription = 650;

		#endregion

		#region [AppSettingsKey]
		/// <summary>
		/// AppSetting keys for web.config
		/// </summary>
		public static class AppSettingKeys
		{
			/// <summary>
			/// Cache zuids definition data
			/// </summary>
			public const string CacheZuidsDefData = "CacheZuidsDefData";
		}
		#endregion

		#region [NodeIDs]
		/// <summary>
		/// Contains node IDs.
		/// </summary>
		public static class NodeIDs
		{
			/// <summary>
			/// Node ID of Settings node.
			/// </summary>
			public const int SettingsNodeId = 1128;
		}
		#endregion

		#region [RequestParameters]
		/// <summary>
		/// Contains names of query string parameter.
		/// </summary>
		public static class RequestParameters
		{
			/// <summary>
			/// Category query string parameter.
			/// </summary>
			public const string Category = "category";

			/// <summary>
			/// Show all query string parameter.
			/// </summary>
			public const string ShowAll = "sa";

			/// <summary>
			/// Category query string parameter.
			/// </summary>
			public const string ActivityCategory = "activcategory";

			/// <summary>
			/// Categories query string parameter.
			/// </summary>
			public const string Categories = "categories";

			/// <summary>
			/// Page number query string parameter.
			/// </summary>
			public const string PageNo = "pageno";

			/// <summary>
			/// Sort order query string parameter.
			/// </summary>
			public const string SortOrder = "sortorder";

			/// <summary>
			/// Sort direction query string parameter.
			/// </summary>
			public const string SortDirection = "sortdirection";

			/// <summary>
			/// Search query string parameter.
			/// </summary>
			public const string SearchQuery = "q";

			/// <summary>
			/// Search tag request parameter.
			/// </summary>
			public const string Tag = "tag";

			/// <summary>
			/// Document types string parameter.
			/// </summary>
			public const string DocumentTypeParameter = "dt";

			/// <summary>
			/// Date from request parameter.
			/// </summary>
			public const string DateFrom = "dateFrom";

			/// <summary>
			/// Date to request parameter.
			/// </summary>
			public const string DateTo = "dateTo";

			/// <summary>
			/// Start node id request parameter.
			/// </summary>
			public const string StartNodeID = "startId";

			/// <summary>
			/// Activity type request parameter.
			/// </summary>
			public const string ActivityType = "activityType";

			/// <summary>
			/// Activity location request parameter.
			/// </summary>
			public const string ActivityLocation = "activityLocation";
		}
		#endregion

		#region [Messages]
		/// <summary>
		/// Messages for Util package
		/// </summary>
		public static class Messages
		{
			/// <summary>
			/// In Media helper GetImageByNodeId, if user dont select image this is message wich he will receive
			/// </summary>
			public const string NotSelectedImage = "One or more of Images is not selected correctly in media picker!!";
		}
		#endregion

		#region [SessionKeys]
		/// <summary>
		/// Contains session keys.
		/// </summary>
		public static class SessionKeys
		{
			/// <summary>
			/// Current language session key.
			/// </summary>
			public const string CurrentLanguage = "CurrentLanguage";
		}
		#endregion

		#region [CultureIdentifiers]
		/// <summary>
		/// Culture identifiers.
		/// </summary>
		public static class CultureIdentifiers
		{
			/// <summary>
			/// English culture identifier.
			/// </summary>
			public const string English = "en-GB";

			/// <summary>
			/// Dutch culture identifier.
			/// </summary>
			public const string Dutch = "nl-NL";
		}
		#endregion

		#region [DocumentTypeNames]
		/// <summary>
		/// Document type names. Document type names are in lower case because of Lucene indexer.
		/// </summary>
		public static class DocumentTypeNames
		{
			/// <summary>
			/// The article document type name.
			/// </summary>
			public const string Article = "article";

			/// <summary>
			/// The articles document type name.
			/// </summary>
			public const string Articles = "articles";

			/// <summary>
			/// The theme document type name.
			/// </summary>
			public const string Theme = "theme";

			/// <summary>
			/// The authors document type name.
			/// </summary>
			public const string Authors = "authors";
		}
		#endregion

		#region [DocumentTypeProperties]
		/// <summary>
		/// Document type properties.
		/// </summary>
		public static class DocumentTypeProperties
		{
			/// <summary>
			/// The tags document type property.
			/// </summary>
			public const string Tags = "tags";
		}
		#endregion

		#region [DateFormats]
		/// <summary>
		/// Date formats.
		/// </summary>
		public static class DateFormats
		{
			/// <summary>
			/// Date format on left column large image item.
			/// </summary>
			public const string LeftColLargeItem = "dddd, dd MMMM yyyy";

			/// <summary>
			/// Formating date do three letter word that represents month
			/// </summary>
			public const string MonthShort = "MMM";
		}
		#endregion

		#region [TabNames]
		/// <summary>
		/// Contains tab names for document types.
		/// </summary>
		public static class TabNames
		{
			/// <summary>
			/// This is content tab name.
			/// </summary>
			public const string Content = "Content";

			/// <summary>
			/// This is Page tab name.
			/// </summary>
			public const string Page = "Page";
		}
		#endregion

		#region [Custom Data Types]
		/// <summary>
		/// Contains custom document types names.
		/// </summary>
		public static class CustomDataTypes
		{
			/// <summary>
			/// Related Links With Media data type.
			/// </summary>
			public const string RelatedLinksWithMedia = "Related Links with Media";

			/// <summary>
			/// Activity type data type.
			/// </summary>
			public const string ActivityType = "ActivityType";

			/// <summary>
			/// Activity location data type
			/// </summary>
			public const string ActivityLocation = "ActivityLocation";

			/// <summary>
			/// Image Block Middle Types data type.
			/// </summary>
			public const string ImageBlockMiddleTypes = "Image Block Middle Types";

			/// <summary>
			/// Small Rich text Title data type.
			/// </summary>
			public const string TitleColor = "Title Color";

			/// <summary>
			/// Richtext Editor With Images data type.
			/// </summary>
			public const string RichtextEditorWithIamge = "Richtext Editor With Images";

			/// <summary>
			/// CategoryPicker data type.
			/// </summary>
			public const string CategoryPicker = "CategoryPicker";

			/// <summary>
			/// TextColors data type.
			/// </summary>
			public const string TextColors = "TextColors";

			/// <summary>
			/// BackgroundColors data type.
			/// </summary>
			public const string BackgroundColors = "BackgroundColors";
		}
		#endregion

		#region [Description for Data Types]

		/// <summary>
		/// This class represents constants for description.
		/// </summary>
		public static class DescriptionDataTypes
		{
			/// <summary>
			/// Description for related links with media
			/// </summary>
			public const string DescriptionRelatedLinkWithMedia = "For image selecting use 'Add Media Link'.";
		}
		#endregion

		#region [CookieNames]
		/// <summary>
		/// Cookie names.
		/// </summary>
		public static class CookieNames
		{
			/// <summary>
			/// Visited articles cookie name.
			/// </summary>
			public const string VisitedArticles = "VisitedArticles";
		}
		#endregion

		#region [Cache keys]
		/// <summary>
		/// Cache keys
		/// </summary>
		public static class Cache
		{
			/// <summary>
			/// Default cache expiration time in minutes
			/// </summary>
			public const int ExpirationTime = 30;

			/// <summary>
			/// Prefix for company caching key
			/// </summary>
			public const string CompanyPrefix = "Company_";

			/// <summary>
			/// Company cache expiration time in minutes
			/// </summary>
			public const int CompanyExpirationTime = 30;

			/// <summary>
			/// Prefix for global activity caching key
			/// </summary>
			public const string GlobalActivityPrefix = "GlobalActivity_";

			/// <summary>
			/// Global activity cache expiration time in minutes
			/// </summary>
			public const int GlobalActivityExpirationTime = 30;

			/// <summary>
			/// Prefix for activity caching key
			/// </summary>
			public const string ActivityPrefix = "Activity_";

			/// <summary>
			/// Articles cache expiration time in minutes
			/// </summary>
			public const int ActivityExpirationTime = 30;

			/// <summary>
			/// Prefix for company activity caching key
			/// </summary>
			public const string CompanyActivitiesPrefix = "CompanyActivities_";

			/// <summary>
			/// Company activities cache expiration time in minutes
			/// </summary>
			public const int CompanyActivitiesExpirationTime = 30;

			/// <summary>
			/// Prefix for news caching key
			/// </summary>
			public const string NewsPrefix = "NewsItem_";

			/// <summary>
			/// News cache expiration time in minutes
			/// </summary>
			public const int NewsExpirationTime = 30;
		}
		#endregion

		#region [Dictionary Items Name]
		/// <summary>
		/// This class represents constants for description.
		/// </summary>
		public static class DictionaryItems
		{
			/// <summary>
			/// Home items from dictionary
			/// </summary>
			public static class Home
			{
				/// <summary>
				/// News text item
				/// </summary>
				public const string News = "Home.News";

				/// <summary>
				/// Activities text
				/// </summary>
				public const string Activities = "Home.Activities";

				/// <summary>
				/// Activities text
				/// </summary>
				public const string ReadAllNews = "Home.ReadAllNews";

				/// <summary>
				/// Activities text
				/// </summary>
				public const string ReadMoreActivities = "Home.ReadMoreActivities";
			}

			/// <summary>
			/// Common items from dictionary
			/// </summary>
			public static class Common
			{
				/// <summary>
				/// More information text
				/// </summary>
				public const string MoreInformation = "Common.MoreInformation";

				/// <summary>
				/// Read more text
				/// </summary>
				public const string ReadMore = "Common.ReadMore";

				/// <summary>
				/// Website text
				/// </summary>
				public const string Website = "Common.Website";

				/// <summary>
				/// Send button text
				/// </summary>
				public const string Send = "Contact.Send";

				/// <summary>
				/// Sign me up button
				/// </summary>
				public const string SignMeUp = "NewsletterSignup.SignMeUp";

				/// <summary>
				/// Sign up company button
				/// </summary>
				public const string SignUpCompany = "CompanySignup.SignCompanyUp";
			}
		}
		#endregion

		#region [Crop items]
		/// <summary>
		/// This class represents constants for crop name.
		/// </summary>
		public static class CropName
		{
			/// <summary>
			/// Overview image name for crop image
			/// </summary>
			public const string OverviewImage = "OverviewImage";

			/// <summary>
			/// Carousel image name for crop image
			/// </summary>
			public const string CarouselImage = "CarouselImage";

			/// <summary>
			/// Overview image name for crop image
			/// </summary>
			public const string BannerImage = "BannerImage";

			/// <summary>
			/// Overview image name for crop image on home page
			/// </summary>
			public const string OverviewHomePage = "OverviewHomePage";

			/// <summary>
			/// Activity detail image name for crop image
			/// </summary>
			public const string ActivityDetail = "ActivityDetail";

			/// <summary>
			/// Company image name for crop image
			/// </summary>
			public const string CompanyImage = "CompanyImage";
		}
		#endregion

		#region[MaxCharacters]
		/// <summary>
		/// Maximum number of characters in intro text on Home page for news item.
		/// </summary>
		public static class MaxCharacters
		{
			/// <summary>
			/// Get shorter text for news item home page
			/// </summary>
			public const int GetShorterTextForNewsItemHomePage = 360;

			/// <summary>
			/// Get Shorter Text For News Item News Overview Page
			/// </summary>
			public const int GetShorterTextForNewsItemNewsOverviewPage = 700;

			/// <summary>
			/// Max number of characters for description
			/// </summary>
			public const int ActivitiBannerMaxChars = 130;
		}
		#endregion

		#region[HtmlAttributes]
		/// <summary>
		/// Maximum number of characters in intro text on Home page for news item.
		/// </summary>
		public static class HtmlAttributes
		{
			/// <summary>
			/// Style text
			/// </summary>
			public const string Style = "style";

			/// <summary>
			/// Background color text
			/// </summary>
			public const string BackgroundColor = "background-color";

			/// <summary>
			/// Color text
			/// </summary>
			public const string Color = "color";

			/// <summary>
			/// Href's text
			/// </summary>
			public const string Href = "href";

			/// <summary>
			/// Class text
			/// </summary>
			public const string Class = "class";

			/// <summary>
			/// Css class names
			/// </summary>
			public static class CssClass
			{
				/// <summary>
				/// No background image
				/// </summary>
				public const string NoBackground = "no_bckground";

				/// <summary>
				/// Rounded images
				/// </summary>
				public const string RoundedImages = "rounded-img";

				/// <summary>
				/// Rounded images
				/// </summary>
				public const string RoundedActivityImages = "rounded-activity-img";

				/// <summary>
				/// Small column for activity overview
				/// </summary>
				public const string RightInside = "right_inside";

				/// <summary>
				/// Large column for activity overview
				/// </summary>
				public const string RightInsideBig = "right_inside_big";

				/// <summary>
				/// Message error for validation
				/// </summary>
				public const string ValidateMessageError = "validate-message-error";
			}
		}
		#endregion

		#region[MailMessages]
		/// <summary>
		/// Message's for subject.
		/// </summary>
		public static class MailMessages
		{
			/// <summary>
			/// Messig which will show up in subject of mail sended from contact form of website.
			/// </summary>
			public const string ContactForm = "User's message from HelloZuidas website.";

			/// <summary>
			/// Messig which will show up in subject of mail sended from newsletter signup form of website.
			/// </summary>
			public const string NewsletterSignup = "New user subscribed for newsletter on HelloZuidas website.";

			/// <summary>
			/// Messig which will show up in subject of mail sended from company signup form of website.
			/// </summary>
			public const string CompanySignup = "New Company have registrated on HelloZuidas website.";
		}
		#endregion

		#region[RegularExpresions]
		/// <summary>
		/// Contains names of regular expresion parameters.
		/// </summary>
		public static class RegExpresion
		{
			/// <summary>
			/// Regular expresion for email address.
			/// </summary>
			public const string RegEmailExpresion = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
													 + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                                [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
													 + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
													 + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
		}
		#endregion
	}
}
