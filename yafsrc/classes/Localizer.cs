using System;
using System.Xml;

namespace yaf
{
	/// <summary>
	/// Summary description for Localizer.
	/// </summary>
	public class Localizer
	{
		private XmlDocument _doc = null;
		private XmlNode _pagePointer = null;
		private string _fileName = "";
		private string _currentPage = "";
		
		public Localizer()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public Localizer( string FileName )
		{
			_fileName = FileName;
			LoadFile();
		}

		private void LoadFile()
		{
			if( _fileName == "" || !System.IO.File.Exists( _fileName ) )
				throw( new ApplicationException( "Invalid language file " + _fileName ) );

			if( _doc == null )
				_doc = new XmlDocument();

			_doc.Load( _fileName );
			try
			{
				_doc.Load( _fileName );
			}
			catch
			{
				_doc = null;
			}
		}

		public void LoadFile( string FileName )
		{
			_fileName = FileName;
			LoadFile();
		}

		public void SetPage( string Page )
		{
			if(_currentPage==Page)
				return;

			_pagePointer = null;
			_currentPage = "";

			if( _doc != null )
			{
				_pagePointer = _doc.SelectSingleNode( string.Format( "//page[@name='{0}']", Page.ToUpper() ) );
				_currentPage = Page;
			}
		}

		public string GetText( string text )
		{
			if( _doc == null )
				return "";

			XmlNode el = null;

#if DEBUG
			if( _pagePointer == null )
				throw new Exception("Missing page pointer: " + text);
#endif

			if( _pagePointer != null )
			{
				el = _pagePointer.SelectSingleNode( string.Format( "Resource[@tag='{0}']", text.ToUpper() ) );
				// if in page subnode the text doesn't exist, try in whole file
				if( el == null )
					el = _doc.SelectSingleNode( string.Format( "//Resource[@tag='{0}']", text.ToUpper() ) );
			}
			else
			{
				el = _doc.SelectSingleNode( string.Format( "//Resource[@tag='{0}']", text.ToUpper() ) );
			}

			if( el != null )
				return el.InnerText;
			else
				throw new Exception(String.Format("Missing language item {0}",text));
				//return "";
		}

		public string GetText( string page, string text )
		{
			SetPage( page );
			return GetText( text );
		}
	}
}
